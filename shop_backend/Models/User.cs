namespace shop_backend.Models;
public class User
{
    public int UserId { get; set; }
    public string FristName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone {get;set;}
    public string Password { get; set; }
    public DateTime? CreatedAt { get; set; }

}

public class UserLogin {
    public string Email {get;set;}
    public string Password {get;set;}
}