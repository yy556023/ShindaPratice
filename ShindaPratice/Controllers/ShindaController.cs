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

            var newItem = new Sign();

            var list = (from o in _context.TblActiveItem
                        select new Event()
                        {
                            CItemId = o.CItemId,
                            CItemName = o.CItemName,
                            CActiveDt = o.CActiveDt,
                            selected = false
                        }).ToList();

            newItem.Event = list;

            var items = await _context.TblActiveItem.ToListAsync();

            ViewBag.Item = items;

            var signls = (from o in _context.TblSignup
                          join o2 in _context.TblSignupItem
                          on o.CId equals o2.CSignupId
                          join o3 in _context.TblActiveItem
                          on o2.CItemId equals o3.CItemId
                          select new Signls()
                          {
                              phone = o.CMobile,
                              name = o.CName,
                              email = o.CEmail,
                              items = (from x in _context.TblActiveItem
                                       join x2 in _context.TblSignupItem
                                       on x.CItemId equals x2.CItemId
                                       select x.CItemName).ToList()
                          }).ToList();

            foreach (var item in collection)
            {

            }

            ViewBag.ls = signls;

            return View(newItem);
        }

        [HttpPost]
        public async Task<ActionResult> Index(Sign model)
        {
            var count = 0;

            for (int i = 0; i < model.Event.Count; i++)
            {
                if (model.Event[i].selected)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                TempData["alert"] = "測試";
                return RedirectToAction("Index");
            }

            TblSignup Item = new TblSignup()
            {
                CMobile = model.phone,
                CName = model.name,
                CEmail = model.email,
                CCreateDt = System.DateTime.Now
            };

            _context.TblSignup.Add(Item);
            _context.SaveChanges();

            var data = _context.TblSignup.Where(x => x.CName == model.name && x.CEmail == model.email).FirstOrDefault();

            foreach (var item in model.Event)
            {
                if (item.selected)
                {
                    TblSignupItem signupItem = new TblSignupItem()
                    {
                        CSignupId = data.CId,
                        CItemId = item.CItemId
                    };
                    _context.TblSignupItem.Add(signupItem);
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
