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

            var list = await (from o in _context.TblActiveItem
                        select new TblActiveItem()
                        {
                            CItemId = o.CItemId,
                            CItemName = o.CItemName,
                            CActiveDt = o.CActiveDt
                        }).ToListAsync();

            ViewBag.list = list;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Sign model)
        {
            //var count = 0;

            //TblSignup Item = new TblSignup()
            //{
            //    CMobile = model.phone,
            //    CName = model.name,
            //    CEmail = model.email,
            //    CCreateDt = System.DateTime.Now
            //};

            //_context.TblSignup.Add(Item);
            //await _context.SaveChangesAsync();

            //var data = await _context.TblSignup.Where(x => x.CName == model.name && x.CEmail == model.email).FirstOrDefaultAsync();

            //_context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
