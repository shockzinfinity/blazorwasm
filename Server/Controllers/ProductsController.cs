using blazorwasm.Server.Repository;
using blazorwasm.Shared;
using blazorwasm.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace blazorwasm.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductParameters productParameters)
    {
      #region non paging

      //var products = await _repository.GetProducts();

      #endregion non paging

      var products = await _repository.GetPagingProducts(productParameters);

      Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(products.MetaData));

      return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
      if (product == null)
        return BadRequest();

      //model validation…
      await _repository.CreateProduct(product);

      return Created("", product);
    }
  }
}