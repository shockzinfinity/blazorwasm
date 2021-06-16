using blazorwasm.Server.Data;
using blazorwasm.Server.Extensions;
using blazorwasm.Server.Paging;
using blazorwasm.Shared;
using blazorwasm.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blazorwasm.Server.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Product>> GetProducts() => await _context.Products.ToListAsync();

    public async Task<PagedList<Product>> GetPagingProducts(ProductParameters productParameters)
    {
      var products = await _context.Products.Search(productParameters.SearchTerm).ToListAsync();

      return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
    }
  }
}