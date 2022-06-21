namespace shop_backend.Controllers;

using shop_backend.Models;
using shop_backend.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class ProductController : Controller {
    private readonly IProductService _productService;

    public ProductController(IProductService productService){
        this._productService = productService;
    }
    
    [HttpGet]
    public IActionResult Get(){
        try{
            return Ok(this._productService.GetProducts());
        }catch(Exception e){
            return NotFound(e);
        }
    }

    [HttpPost]
    [Route("update-amount")]
    public IActionResult Post([FromBody] Product product){
        try{
            this._productService.UpdateAmount(product);
            return Ok(Json("Cantidad de producto '"+ product.Name +" actualziada"));
        }catch(Exception e){
            return NotFound(e.Message);
        }
    }
}