using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class ElementPage
    {
        public ElementPage() { }
        public ElementPage(int _total, int _page, int _pageSize)
        {
            Total = _total;
            Page = _page;
            PageSize = _pageSize;
        }

        public int? Total { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set;}
    }
}
