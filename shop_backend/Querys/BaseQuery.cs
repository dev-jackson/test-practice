
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace shop_backend.Querys;

public class BaseQuery
{
    internal string __connectionString;

    private readonly IConfiguration _configuration;

    public BaseQuery(IConfiguration configuration)
    {
        __connectionString = configuration.GetConnectionString("dbConnection");
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(__connectionString);
    }

    public class BaseResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ObjectId { get; set; }
    }

    internal List<T> Query<T>(string v, CommandType commandType)
    {
        throw new NotImplementedException();
    }
}