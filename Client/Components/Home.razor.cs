using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blazorwasm.Client.Components
{
  public partial class Home
  {
    [Parameter] public string Title { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; }
    [CascadingParameter(Name = "HeadingColor")] public string Color { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment AdditionalComment { get; set; }

    // 1. ]] 컴포넌트 생성 이후 1 번 life cycle, ParameterView object 에 저장
    public override Task SetParametersAsync(ParameterView parameters)
    {
      return base.SetParametersAsync(parameters);
    }

    // 2. ]]
    protected override void OnInitialized()
    {
      base.OnInitialized();
    }

    // 2. ]]
    protected override Task OnInitializedAsync()
    {
      return base.OnInitializedAsync();
    }

    // 3. ]] 파라미터에 세팅되면 계속 실행
    protected override void OnParametersSet()
    {
      base.OnParametersSet();
    }

    // 3. ]] 파라미터에 세팅되면 계속 실행
    protected override Task OnParametersSetAsync()
    {
      return base.OnParametersSetAsync();
    }

    // 4. ]] 랜더링 이후 실행, 추가적인 초기화 작업은 여기서, firstRender 는 초기 1회만 true, 그 이후는 false
    protected override void OnAfterRender(bool firstRender)
    {
      base.OnAfterRender(firstRender);
    }

    // 4. ]] 랜더링 이후 실행, 추가적인 초기화 작업은 여기서, firstRender 는 초기 1회만 true, 그 이후는 false
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
      return base.OnAfterRenderAsync(firstRender);
    }

    // * ]] StateHasChanged() 재 랜더링이 필요한 부분에서 호출

    // * ]] UI refreshing 을 막고자 할때 여기서 false 반환
    protected override bool ShouldRender()
    {
      return base.ShouldRender();
    }

    // * ]] 컴포넌트 삭제 시에 취해야 하는 행동은 IDisposable 을 구현하여 호출
    public void Dispose()
    {
      // destroy something
    }
  }
}