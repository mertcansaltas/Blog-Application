using BlogUI.Models.VMs;
using DATA.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REPO.Context;

namespace BlogUI.Controllers
{
    
    public class UserController : Controller
    {
        private readonly AppDbContext db;
        private readonly UserManager<User> _userManager;

        public UserController(AppDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            List<KonuVM> konuVM = new List<KonuVM>();

            if (userId != null)
            {
         
                  konuVM=  await db.KullaniciKonular
             .Where(kk => kk.UserId == userId)
             .Select(kk => new KonuVM
             {
                 Id = kk.Konu.Id,
                 KonuAdi = kk.Konu.KonuAdi
             }).ToListAsync();
              
            }

            return View(konuVM);
        }
        [HttpGet]
        public async Task<IActionResult> Detay(string id)
        {
            var user = db.Users.FirstOrDefault(x=>x.Id==id);
            var makaleler =  db.Makaleler.Where(x=>x.UserId==id).OrderByDescending(x=>x.YayınTarihi).ToList();
            YazarDetayVM yazarDetayVM = new YazarDetayVM()
            {
                Makaleler = makaleler,
                User = user,
            };
            return View(yazarDetayVM);

        }
    }
}
