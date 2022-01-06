using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShindaPratice.Models.Shinda
{
    public partial class TblSignup
    {
        [Key]
        public int CId { get; set; }
        [Column(TypeName = "VARCHAR(10)")]
        public string CMobile { get; set; }
        [Column(TypeName = "NVARCHAR(20)")]
        public string CName { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string CEmail { get; set; }
        public DateTime CCreateDt { get; set; }
    }
}
