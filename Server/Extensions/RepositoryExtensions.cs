using blazorwasm.Shared;
using System.Linq;

namespace blazorwasm.Server.Extensions
{
  public static class RepositoryExtensions
  {
    public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTearm)
    {
      if (string.IsNullOrWhiteSpace(searchTearm))
        return products;

      var lowerCaseSearchTerm = searchTearm.Trim().ToLower();

      return products.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
    }
  }
}