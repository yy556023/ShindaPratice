using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShindaPratice.Models.Shinda
{
    public partial class TblActiveItem
    {
        public int CItemId { get; set; }
        public string CItemName { get; set; }
        public string CActiveDt { get; set; }
    }
}
