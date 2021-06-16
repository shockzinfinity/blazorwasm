using blazorwasm.Client.Features;
using blazorwasm.Shared;
using blazorwasm.Shared.RequestFeatures;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace blazorwasm.Client.HttpRepository
{
  public class ProductHttpRepository : IProductHttpRepository
  {
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;

    public ProductHttpRepository(HttpClient client)
    {
      _client = client ?? throw new ArgumentNullException(nameof(client));
      _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<Product>> GetProducts()
    {
      var response = await _client.GetAsync("api/products");
      var content = await response.Content.ReadAsStringAsync();

      if (!response.IsSuccessStatusCode) {
        throw new ApplicationException(content);
      }

      var products = JsonSerializer.Deserialize<List<Product>>(content, _serializerOptions);
      return products;
    }

    public async Task<PagingResponse<Product>> GetPagingProducts(ProductParameters productParameters)
    {
      var queryStringParam = new Dictionary<string, string> {
        ["pageNumber"] = productParameters.PageNumber.ToString(),
        ["searchTerm"] = productParameters.SearchTerm == null ? "" : productParameters.SearchTerm,
        ["orderBy"] = productParameters.OrderBy
      };

      var response = await _client.GetAsync(QueryHelpers.AddQueryString("api/products", queryStringParam));
      var content = await response.Content.ReadAsStringAsync();

      if (!response.IsSuccessStatusCode) {
        throw new ApplicationException(content);
      }

      var pagingResponse = new PagingResponse<Product> {
        Items = JsonSerializer.Deserialize<List<Product>>(content, _serializerOptions),
        MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _serializerOptions)
      };

      return pagingResponse;
    }

    public async Task CreateProduct(Product product)
    {
      var content = JsonSerializer.Serialize(product);
      var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
      var postResult = await _client.PostAsync("api/products", bodyContent);
      var postContent = await postResult.Content.ReadAsStringAsync();

      if (!postResult.IsSuccessStatusCode) {
        throw new ApplicationException(postContent);
      }
    }
  }
}