using MyComponents.Enums;

namespace MyComponents.Shared.Params;

public class ListParams : PagerParams
{
    #region Variables
    private string _OrderBy = String.Empty;
    private SortOrder _SortOrder = SortOrder.Unspecified;
    private string _SearchFilter = String.Empty;
    #endregion

    #region Properties
    /// <summary>
    /// Single field order by
    /// </summary>
    public string OrderBy
    {
        get => _OrderBy;
        set
        {
            if (value != _OrderBy)
            {
                PageNumber = 1;
            }
            _OrderBy = value;
        }
    }
    public SortOrder SortOrder
    {
        get => _SortOrder;
        set
        {
            if (value != _SortOrder)
            {
                PageNumber = 1;
            }
            _SortOrder = value;
        }
    }
    /// <summary>
    /// Search all string fields for value
    /// </summary>
    public string SearchFilter
    {
        get => _SearchFilter;
        set
        {

            if (value != _SearchFilter)
            {
                PageNumber = 1;
            }
            _SearchFilter = value;
        }
    }
    #endregion

    #region Methods
    public void DetermineSortOrder()
    {
        switch (SortOrder)
        {
            case SortOrder.Ascending: SortOrder = SortOrder.Descending; break;

            case SortOrder.Descending:
                // Time to reset sorts and start over from defaults
                OrderBy = String.Empty;
                SortOrder = SortOrder.Unspecified;
                break;

            case SortOrder.Unspecified: SortOrder = SortOrder.Ascending; break;
        }
    }
    #endregion
}