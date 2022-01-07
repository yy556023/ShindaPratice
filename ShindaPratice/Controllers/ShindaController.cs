using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShindaPratice.Models.Shinda;
using System.Collections.Generic;
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

        public async Task<ActionResult> Index()
        {
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
        public async Task<ActionResult> Post([FromBody] Sign model)
        {
            TblSignup Item = new TblSignup()
            {
                CMobile = model.phone,
                CName = model.name,
                CEmail = model.email,
                CCreateDt = System.DateTime.Now
            };

            _context.TblSignup.Add(Item);
            await _context.SaveChangesAsync();

            var data = await _context.TblSignup.Where(x => x.CName == model.name && x.CEmail == model.email).FirstOrDefaultAsync();

            var itemls = model.items.Split(',');

            foreach (var item in itemls)
            {
                TblSignupItem signItem = new TblSignupItem()
                {
                    CSignupId = data.CId,
                    CItemId = int.Parse(item)
                };

                _context.TblSignupItem.Add(signItem);
            }

            _context.SaveChanges();

            var showls = (from o in _context.TblSignup
                          join o2 in _context.TblSignupItem
                          on o.CId equals o2.CSignupId
                          join o3 in _context.TblActiveItem
                          on o2.CItemId equals o3.CItemId
                          group o3 by new { o.CId, o2.CSignupId, o.CName, o.CEmail, o.CMobile } into g
                          select new Sign()
                          {
                              Id = g.Key.CId,
                              name = g.Key.CName,
                              phone = g.Key.CMobile,
                              email = g.Key.CEmail,
                              items = ""
                          }).ToList();

            foreach (var item in showls)
            {
                var temp = (from o2 in _context.TblSignupItem
                            join o3 in _context.TblActiveItem
                            on o2.CItemId equals o3.CItemId
                            where o2.CSignupId == item.Id
                            select o3.CItemName).ToList();

                item.items = string.Join(',', temp);
            }

            ViewBag.show = showls;

            var s = JsonConvert.SerializeObject(showls, Formatting.None);

            return Ok(s);
        }
    }
}
