using System;
using System.Collections.Generic;
using System.Text;

namespace NRuneScape.API
{
    internal class GetItemParams
    {
        public int? Limit { get; set; }
        public int? AfterPageNum { get; set; }
    }
}
