using shop_backend.Models;
using shop_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace shop_backend.Controllers;

[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;

    public UserController(IUserService userService, IConfiguration configuration, ITokenService tokenService)
    {
        this._userService = userService;
        this._configuration = configuration;
        this._tokenService = tokenService;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Post([FromBody] UserLogin user)
    {
        try
        {
            var currentUser = this._userService.GetUserByEmailAndPassword(user);
            if (currentUser != null)
            {
                return Ok(currentUser);
                // var token = this._tokenService.CreateToken(currentUser.FristName);
                // return Ok(new JsonResult(new {
                //     user =  currentUser,
                //     token = token
                // }));
            }
            return NotFound();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }
}