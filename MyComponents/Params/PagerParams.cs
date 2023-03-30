namespace MyComponents.Shared.Params;

public class PagerParams
{
    #region Variables
    public bool PagerVisible { get; set; } = true;
    public bool BottomPagerVisible { get; set; } = true;
    public bool ShowPageNavigation { get; set; } = true;
    public bool ShowPageSizes { get; set; } = true;

    public string PagerMessage { get; set; }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;

    public IList<int> PageSizeValues = new List<int>() { 3, 5, 10, 50, 100 };

    public int TotalRecords { get; set; } = 0;
    #endregion

    #region Properties
    public string PagingVerbiage
    {
        get
        {
            if (TotalRecords > 0)
            {
                if (ShowPageNavigation)
                {
                    if (PageSize > 0)
                    {
                        var start = ((PageNumber - 1) * PageSize) + 1;
                        var end = start + PageSize - 1;

                        if (LastPage)
                        {
                            end = TotalRecords;
                        }
                        return $"Row {start:n0} - {end:n0} of {TotalRecords:n0}";
                    }
                    else
                    {
                        return $"1 - {TotalRecords:n0} of {TotalRecords:n0}";
                    }
                }
                else
                {
                    if (TotalRecords > 1)
                    {
                        return $"{TotalRecords:n0} rows";
                    }
                    else
                    {
                        return "1 row";
                    }
                }
            }
            else
            {
                return "0 rows";
            }
        }
    }

    public bool FirstPage
    {
        get { return PageNumber == 1; }
    }
    public bool LastPage
    {
        get
        {
            var lastPage = false;

            if (PageSize == 0 || ((PageNumber * PageSize) >= TotalRecords))
            {
                lastPage = true;
            }
            return lastPage;
        }
    }
    #endregion

    #region Methods
    #endregion
}
