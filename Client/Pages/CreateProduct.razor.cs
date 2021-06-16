using blazorwasm.Client.HttpRepository;
using blazorwasm.Client.Shared;
using blazorwasm.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace blazorwasm.Client.Pages
{
  public partial class CreateProduct
  {
    private Product _product = new Product();
    [Inject] public IProductHttpRepository ProductRepository { get; set; }
    private SuccessNotification _notification;

    private async Task Create()
    {
      await ProductRepository.CreateProduct(_product);
      _notification.Show();
    }
  }
}