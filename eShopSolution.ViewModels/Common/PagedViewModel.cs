using System.Collections.Generic;

namespace eShopSolution.ViewModels.Common
{
    public class PagedViewModel<T> where T : class
    {
        public List<T> Items { get; set; }
        public int TotalPage { get; set; }
    }
}