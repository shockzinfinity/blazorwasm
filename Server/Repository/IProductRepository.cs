using blazorwasm.Server.Paging;
using blazorwasm.Shared;
using blazorwasm.Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blazorwasm.Server.Repository
{
  public interface IProductRepository
  {
    Task<IEnumerable<Product>> GetProducts();

    Task<PagedList<Product>> GetPagingProducts(ProductParameters productParameters);
  }
}