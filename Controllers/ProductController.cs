using EatForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EatForm.Controllers;
[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetAll()
    {
        var productDtos = _productService.GetAllProducts();
        return Ok(productDtos);
    }
    
    [HttpGet ("{id}")]
    public ActionResult<IEnumerable<ProductDto>> GetById([FromRoute] int id)
    {
        var productDtos = _productService.GetProductsByIds(id);
        return Ok(productDtos);
    }
    
    [HttpPost]
    public ActionResult CreateProduct([FromBody] CreateProductDto dto)
    {
        var id = _productService.CreateProduct(dto);
        return Created($"/api/products/{id}", null);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateProduct([FromBody] CreateProductDto dto, [FromRoute] int id)
    {
        _productService.UpdateProduct(dto, id);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteProduct([FromRoute] int id)
    {
        _productService.DeleteProduct(id);
        return NoContent();
    }
}