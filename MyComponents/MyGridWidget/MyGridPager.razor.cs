using Microsoft.AspNetCore.Components;
using MyComponents.Interfaces;
using MyComponents.Shared.Params;

namespace MyComponents.MyGridWidget;

public partial class MyGridPager : ComponentBase
{
    #region Variables
    [CascadingParameter] public PagerParams PagerParams { get; set; }
    [CascadingParameter] public ICriteriaComponent CriteriaComponent { get; set; }

    protected bool AfterRender = false;
    #endregion

    #region Lifecycle Functions
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            AfterRender = true;
            StateHasChanged();
        }
    }
    #endregion

    #region Event Handlers
    protected async Task PageSizeChanged(ChangeEventArgs e)
    {
        PagerParams.PageNumber = 1;
        PagerParams.PageSize = Convert.ToInt32(e.Value);

        await CriteriaComponent.CriteriaChangedAsync();
    }
    protected async Task PreviousPageClicked()
    {
        if (PagerParams.PageSize > 0 && PagerParams.PageNumber > 1)
        {
            PagerParams.PageNumber--;

            await CriteriaComponent.CriteriaChangedAsync();
        }
    }
    protected async Task NextPageClicked()
    {
        if (PagerParams.PageSize > 0 && !PagerParams.LastPage)
        {
            PagerParams.PageNumber++;

            await CriteriaComponent.CriteriaChangedAsync();
        }
    }
    #endregion

    #region Private Functions
    #endregion
}
