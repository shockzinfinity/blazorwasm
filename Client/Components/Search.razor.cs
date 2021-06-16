using Microsoft.AspNetCore.Components;

namespace blazorwasm.Client.Components
{
  public partial class Search
  {
    public string SearchTerm { get; set; }

    [Parameter] public EventCallback<string> OnSearchChanged { get; set; }
  }
}