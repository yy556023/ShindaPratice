using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShindaPratice.Models.Shinda
{
    public partial class TblSignup
    {
        [Key]
        public int CId { get; set; }
        public string CMobile { get; set; }
        public string CName { get; set; }
        public string CEmail { get; set; }
        public DateTime CCreateDt { get; set; }
    }
}
