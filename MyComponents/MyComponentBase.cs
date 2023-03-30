using Microsoft.AspNetCore.Components;

namespace MyComponents;

public abstract class MyComponentBase : ComponentBase
{
    #region Variables
    // Start off showing busy when component is initially loaded
    private bool _Busy = true;
    #endregion

    #region Properties
    public bool IsBusy => _Busy;
    #endregion

    #region Methods
    public void HideBusy() => _Busy = false;
    protected string GetBusyCss() => _Busy ? "busy-blur" : String.Empty;
    #endregion
}