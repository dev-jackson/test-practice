DROP database shop_user;
GO
CREATE DATABASE shop_user;
GO
use shop_user;
GO
CREATE TABLE [user](
    UserId INT IDENTITY(1,1) NOT NULL,
    FristName VARCHAR(255) NOT NULL, 
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Phone TEXT NOT NULL,
    Password VARCHAR(500) NOT NULL,
    CreatedAt DATETIME2 DEFAULT(SYSDATETIME()) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED(
        UserId ASC
    )
);
GO
CREATE TABLE [product](
    ProductId INT IDENTITY(1,1) NOT NULL,
    Name VARCHAR(500) UNIQUE NOT NULL,
    Amount INT DEFAULT(0) NOT NULL,
    Price MONEY DEFAULT(0) NOT NULL,
    ImageUrl VARCHAR(2000) DEFAULT('https://opel.navigation.com/static/WFS/Shop-Site/-/Shop/en_US/Product%20Not%20Found.png') NOT NULL,
    CreatedAt DATETIME2 DEFAULT(SYSDATETIME()) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED(
        ProductId ASC
    )
);
GO
CREATE TABLE [invoice](
    InvoiceId INT IDENTITY(1, 1) NOT NULL,
    UserId INT NOT NULL,
    TotalPrice FLOAT,
    Status INT DEFAULT(0),
    CreatedAt DATETIME2 DEFAULT(SYSDATETIME()) NOT NULL,
    CONSTRAINT [PK_Inovice] PRIMARY KEY CLUSTERED(
        InvoiceId ASC
    )
);
GO
CREATE TABLE [product_invoice](
    ProductId INT, 
    InvoiceId INT
);
GO
ALTER TABLE [product_invoice]
ADD CONSTRAINT FK_Product_Invoice
FOREIGN KEY(ProductId) REFERENCES product(ProductId),
FOREIGN KEY(InvoiceId) REFERENCES invoice(InvoiceId);
GO
ALTER TABLE [invoice]
ADD CONSTRAINT FK_User
FOREIGN KEY(UserId) REFERENCES [dbo].[user](UserId);
GO
-- Data test


INSERT INTO [dbo].[user](LastName, FristName,Email,Phone, Password)
    VALUES('Angel', 'Sanches','sangel@gmail.com','0993421844' ,'angel537')
GO

INSERT INTO [dbo].[product](Name, Amount,Price, ImageUrl) VALUES
    ('Mouse', 8, 10.50, 'https://image.shutterstock.com/image-photo/modern-computer-mouse-on-white-600w-1090541303.jpg'),
    ('Keyboard', 20, 45.50, 'https://image.shutterstock.com/image-vector/modern-aluminum-computer-keyboard-on-600w-497124178.jpg'),
    ('SmartTV', 10, 10, 'https://image.shutterstock.com/image-photo/mobile-phone-charger-on-orange-600w-773099164.jpg'),
    ('Charger', 60, 40, 'https://image.shutterstock.com/image-photo/mobile-phone-charger-on-orange-600w-773099164.jpg'),
    ('Mainboard', 30, 100.50, 'https://image.shutterstock.com/image-photo/computer-mainboard-motherboard-blue-cpu-600w-1725705859.jpg'),
    ('Processor', 200, 400.50, 'https://image.shutterstock.com/image-photo/bangkokthailand-19-2021-intel-core-600w-2116164491.jpg');


-- Stored Produres
GO
-- show all productos
CREATE PROCEDURE [dbo].[Product_GetAll]
AS
    BEGIN
        SELECT * FROM [dbo].[product];
    END
GO

-- Update amount product 
CREATE PROCEDURE [dbo].[Product_UpdateAmount]
    @ProductId INT,
    @Mount INT
AS
    BEGIN
        UPDATE [dbo].[product]
        SET  [Amount] = [Amount] - @Mount
        WHERE [ProductId] = @ProductId;
    END
GO