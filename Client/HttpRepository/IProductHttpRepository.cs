using blazorwasm.Client.Features;
using blazorwasm.Shared;
using blazorwasm.Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blazorwasm.Client.HttpRepository
{
  public interface IProductHttpRepository
  {
    Task<List<Product>> GetProducts();

    Task<PagingResponse<Product>> GetPagingProducts(ProductParameters productParameters);
  }
}