using Microsoft.AspNetCore.Components;
using MyComponents.Enums;
using MyComponents.Interfaces;
using MyComponents.Shared.Params;

namespace MyComponents.MyGridWidget;

public partial class MyGridColumn : ComponentBase
{
    #region Variables
    [Parameter] public string ColumnName { get; set; }
    [Parameter] public string DisplayName { get; set; }
    [Parameter] public TextAlignment TextAlignment { get; set; } = TextAlignment.Left;
    [Parameter] public bool DisableSort { get; set; }
    [Parameter] public int RowSpan { get; set; } = 1;
    [Parameter] public int ColSpan { get; set; } = 1;
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// MinWidth - Give number measured in rem's
    /// </summary>
    [Parameter] public decimal MinWidth { get; set; } = 0;

    /// <summary>
    /// Width - Give number measured in rem's
    /// </summary>
    [Parameter] public decimal Width { get; set; } = 0;

    [CascadingParameter] public ICriteriaComponent CriteriaComponent { get; set; }

    [CascadingParameter] public ListParams GridParams { get; set; }
    #endregion

    #region Event Handlers
    protected async Task NameClicked()
    {
        if (GridParams.OrderBy == ColumnName)
        {
            DetermineSortOrder();
        }
        else
        {
            GridParams.OrderBy = ColumnName;
            GridParams.SortOrder = SortOrder.Ascending;
        }
        await CriteriaComponent.CriteriaChangedAsync();
    }
    #endregion

    #region Methods
    protected string GetAlignmentCss()
    {
        return TextAlignment switch
        {
            TextAlignment.Center => "justify-content-center",
            TextAlignment.Right => "justify-content-end",
            _ => "justify-content-start",
        };
    }
    #endregion

    #region Private Functions
    private void DetermineSortOrder()
    {
        switch (GridParams.SortOrder)
        {
            case SortOrder.Ascending: GridParams.SortOrder = SortOrder.Descending; break;

            case SortOrder.Descending:
                // Time to reset sorts and start over from defaults
                GridParams.OrderBy = String.Empty;
                GridParams.SortOrder = SortOrder.Unspecified;
                break;

            case SortOrder.Unspecified: GridParams.SortOrder = SortOrder.Ascending; break;
        }
    }
    #endregion
}