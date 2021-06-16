using Microsoft.AspNetCore.Components;

namespace blazorwasm.Client.Pages
{
  public partial class CustomNotFound
  {
    [Inject] public NavigationManager NavigationManager { get; set; }

    public void NavigateToHome()
    {
      NavigationManager.NavigateTo("/");
    }
  }
}