using shop_backend.Models;
using shop_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace shop_backend.Controllers;

[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
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