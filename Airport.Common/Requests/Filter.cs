using System;

namespace Airport.Common.Requests
{
    using Airport.Common.Enums;

    public class Filter
    {
        private int page;
        private int pageSize;

        public Filter() { }

        public Filter(string searchString)
        {
            SearchString = searchString;
        }

        public Filter(int page, int pageSize, OrderBy orderBy)
        {
            Page = page;
            PageSize = pageSize;
            OrderBy = orderBy;
        }

        public int PageSize
        {
            get => pageSize == 0 ? 5 : pageSize;
            set => pageSize = value <= 5 ? value : 5;
        }

        public int Page
        {
            get => page == 0 ? 1 : page;
            set => page = value;
        }

        public OrderBy OrderBy { get; set; }

        public string SearchString { get; set; } = String.Empty;
    }
}
