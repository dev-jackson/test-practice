using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace shop_backend.Services;

public class TokenService : ITokenService {
     private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
    }
 
    public string CreateToken(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, username)
        };
 
        //Creating credentials. Specifying which type of Security Algorithm we are using
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
 
        //Creating Token description
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };
 
        var tokenHandler = new JwtSecurityTokenHandler();
 
        var token = tokenHandler.CreateToken(tokenDescriptor);
 
        //Finally returning the created token
        return tokenHandler.WriteToken(token);
    }
}

public interface ITokenService {
    public string CreateToken(string username);
}