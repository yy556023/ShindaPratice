using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShindaPratice.Models.Shinda;
using System.Linq;
using System.Threading.Tasks;

namespace ShindaPratice.Controllers
{
    public class ShindaController : Controller
    {
        private readonly ShindaContext _context;

        public ShindaController(ShindaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //ViewBag.Item = await _context.TblActiveItem.ToListAsync();

            var newItem = new sign();

            var list = (from o in _context.TblActiveItem
                        select new Event()
                        {
                            CItemId = o.CItemId,
                            CItemName = o.CItemName,
                            CActiveDt = o.CActiveDt,
                            selected = false
                        }).ToList();

            newItem.Event = list;

            //ViewBag.Item = newItem;

            return View(newItem);
        }

        [HttpPost]
        public async Task<IActionResult> Index(sign model)
        {

            return View();
        }
    }
}
