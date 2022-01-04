using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShindaPratice.Models.Shinda
{
    public class Sign
    {
        [Required(ErrorMessage = "請輸入手機")]
        public string phone { get; set; }

        [Required(ErrorMessage = "請輸入姓名")]
        public string name { get; set; }

        [Required(ErrorMessage = "請輸入信箱")]
        public string email { get; set; }

        [Required(ErrorMessage = "請至少選取一項")]
        public List<Event> Event { get; set; }
    }

    public class Event : TblActiveItem
    {
        [Required(ErrorMessage = "請至少選取一項")]
        public bool selected { get; set; }
        public string cItem { get; set; }
    }
}
