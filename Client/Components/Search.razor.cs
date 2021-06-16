using Microsoft.AspNetCore.Components;
using System.Threading;

namespace blazorwasm.Client.Components
{
  public partial class Search
  {
    private Timer _timer;
    public string SearchTerm { get; set; }
    [Parameter] public EventCallback<string> OnSearchChanged { get; set; }

    private void SearchChanged()
    {
      if (_timer != null)
        _timer.Dispose();

      _timer = new Timer(OnTimeElapsed, null, 500, 0);
    }

    private void OnTimeElapsed(object sender)
    {
      OnSearchChanged.InvokeAsync(SearchTerm);
      _timer.Dispose();
    }
  }
}