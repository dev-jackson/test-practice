using System.Data;
using Dapper;
using shop_backend.Models;
using shop_backend.Querys;

namespace shop_backend.Services;

public class ProductService : IProductService
{

    private BaseQuery _query;

    public ProductService(IConfiguration configuration)
    {
        this._query = new BaseQuery(configuration);
    }
    public List<Product> GetProducts()
    {
        List<Product> products = new List<Product>();

        using (IDbConnection db = this._query.GetConnection())
        {
            products = db.Query<Product>(
                @"Product_GetAll",
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        return products;
    }

    public void UpdateAmount(Product product)
    {

        using (IDbConnection db = this._query.GetConnection())
        {

            db.Query(@"Product_UpdateAmount", new
            {
                product.ProductId,
                product.Amount
            },
            commandType: CommandType.StoredProcedure
            );
        }

    }
}
public interface IProductService
{
    public List<Product> GetProducts();
    public void UpdateAmount(Product product);
}