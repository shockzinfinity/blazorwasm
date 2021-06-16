using blazorwasm.Client.HttpRepository;
using blazorwasm.Shared;
using blazorwasm.Shared.RequestFeatures;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blazorwasm.Client.Pages
{
  public partial class Products
  {
    public List<Product> ProductList { get; set; } = new List<Product>();
    public MetaData MetaData { get; set; } = new MetaData();
    private ProductParameters _productParameters = new ProductParameters();

    [Inject] public IProductHttpRepository ProductRepo { get; set; }

    protected async override Task OnInitializedAsync()
    {
      //ProductList = await ProductRepo.GetProducts();
      ////just for testing
      //foreach (var product in ProductList) {
      //  Console.WriteLine(product.Name);
      //}

      await GetProducts();
    }

    private async Task SelectedPage(int page)
    {
      _productParameters.PageNumber = page;
      await GetProducts();
    }

    private async Task GetProducts()
    {
      var pagingResponse = await ProductRepo.GetPagingProducts(_productParameters);
      ProductList = pagingResponse.Items;
      MetaData = pagingResponse.MetaData;
    }

    private async Task SearchChanged(string searchTerm)
    {
      Console.WriteLine(searchTerm);
      _productParameters.PageNumber = 1;
      _productParameters.SearchTerm = searchTerm;

      await GetProducts();
    }

    private async Task SortChanged(string orderBy)
    {
      Console.WriteLine(orderBy);
      _productParameters.OrderBy = orderBy;

      await GetProducts();
    }
  }
}