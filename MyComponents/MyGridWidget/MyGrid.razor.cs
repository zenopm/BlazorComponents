using Microsoft.AspNetCore.Components;
using MyComponents.Shared.Params;

namespace MyComponents.MyGridWidget;

public partial class MyGrid<TItem> : MyComponentBase
{
    #region Variables
    [Parameter] public RenderFragment HeaderContent { get; set; }
    [Parameter] public RenderFragment NoRecordsContent { get; set; }
    [Parameter] public RenderFragment<TItem> RowContent { get; set; }
    [Parameter] public IList<TItem> Items { get; set; }
    [Parameter] public EventCallback GridChanged { get; set; }
    [Parameter] public bool CustomTableBody { get; set; }

    [Parameter] public int MinWidth { get; set; }

    /// <summary>
    /// Cascading value to make GridParams available in all children components, such as GridColumn(s)
    /// </summary>
    public ListParams GridParams = new ListParams();
    #endregion

    #region Methods
    protected string GetMinWidthStyle()
    {
        if (MinWidth > 0)
        {
            return $"min-width: {MinWidth}px;";
        }
        else
        {
            return String.Empty;
        }
    }

    public void Reset()
    {
        GridParams = new ListParams();
    }
    #endregion

    #region ICriteriaComponent Functions
    public async Task CriteriaChangedAsync()
    {
        if (GridChanged.HasDelegate)
        {
            await GridChanged.InvokeAsync(null);
        }
    }
    #endregion
}
