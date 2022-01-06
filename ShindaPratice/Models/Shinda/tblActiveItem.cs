using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShindaPratice.Models.Shinda
{
    public partial class TblActiveItem
    {
        [Key]
        public int CItemId { get; set; }
        [Column(TypeName = "NVARCHAR(20)")]
        public string CItemName { get; set; }
        [Column(TypeName = "NVARCHAR(20)")]
        public string CActiveDt { get; set; }
    }
}
