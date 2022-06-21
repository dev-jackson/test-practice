namespace shop_backend.Services;

using System.Data;
using shop_backend.Models;
using shop_backend.Querys;
using Dapper;

public class UserService : IUserService{

    private BaseQuery query;

    public UserService(IConfiguration configuration){
        query = new BaseQuery(configuration);
    }

    public User GetUserByEmailAndPassword(UserLogin user){
        User? currentUser;

        using(IDbConnection db = this.query.GetConnection()){
            currentUser = db.Query<User>(@"SELECT * FROM [user]")
                .Where(u => u.Email == user.Email)
                .Where(u => u.Password == user.Password).FirstOrDefault();  
        }
        return currentUser;
    }
}

public interface IUserService{
    public User GetUserByEmailAndPassword(UserLogin user);
}