using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class PagedViewModel<T> where T: class
    {
        public List<T> Items { get; set; }
        public int TotalPage { get; set; }
    }
}
