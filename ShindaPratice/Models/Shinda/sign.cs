using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShindaPratice.Models.Shinda
{
    public class Sign
    {
        public int Id { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string items { get; set; }
    }

    public class Evevt
    {
        public int iid { get; set; }
        public string item { get; set; }
    }
}
