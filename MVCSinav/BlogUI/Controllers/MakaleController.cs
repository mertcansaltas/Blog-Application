using BlogUI.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using REPO.Concrete;
using SERVICE.MakaleService;
using BlogUI.Models;
using DATA.Concrete;
using REPO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using SERVICE.UserService;
using SERVICE.MakaleKonuService;

namespace BlogUI.Controllers
{
    public class MakaleController : Controller
    {
        private readonly IMakaleSERVICE makaleSERVICE;
        private readonly AppDbContext db;
        private readonly UserManager<User> userManager;
        private readonly IUserSERVICE userSERVICE;
        private readonly IMakaleKonuSERVICE makaleKonuSERVICE;

        public MakaleController(IMakaleSERVICE makaleSERVICE, AppDbContext db, UserManager<User> userManager, IUserSERVICE userSERVICE, IMakaleKonuSERVICE makaleKonuSERVICE)
        {
            this.makaleSERVICE = makaleSERVICE;
            this.db = db;
            this.userManager = userManager;
            this.userSERVICE = userSERVICE;
            this.makaleKonuSERVICE = makaleKonuSERVICE;
        }
        [HttpGet]
        public async Task<IActionResult> MakaleOkuma(int id)
        {
            var makale=await makaleSERVICE.GetMakale(id);
            await makaleSERVICE.IncreaseOkunmaSayisi(id);

            if (makale == null)
            {
                return NotFound(); 
            }

            var user=await userSERVICE.GetUser(id);
            if (user == null)
            {
                return NotFound(); 
            }


            var yazarAdi = $"{user.Ad} {user.Soyad}";
            var userid = user.Id;

            var makaleOkumaVM = new MakaleOkumaVM()
            {
                Baslik = makale.Baslik,
                Icerik = makale.Icerik,
                YazarAdi = yazarAdi, 
                YayınTarihi = makale.YayınTarihi,
                OkumaSuresi = makale.OkumaSuresi,
                UserId= userid,
                OkunmaSayisi= makale.OkunmaSayisi
                
                
            };
            
            return View(makaleOkumaVM);
        }
        public async Task<IActionResult> Ekle()
        {
            var tumKonular = await db.Konular
                .Select(k => new SelectListItem { Text = k.KonuAdi, Value = k.Id.ToString() })
                .ToListAsync();

            var viewModel = new MakaleEklemeVM
            {
                TumKonular = tumKonular
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Ekle(MakaleEklemeVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                var makale = new Makale
                {
                    Baslik = model.Baslik,
                    Icerik = model.Icerik,
                    UserId = user?.Id,
                    YayınTarihi=model.YayinTarihi,
                    OkumaSuresi=model.OkumaSuresi,
                    OkunmaSayisi=model.OkunmaSayisi
                    
                };

                makaleSERVICE.Create(makale);
            

          
                foreach (var konuId in model.SecilenKonular)
                {
                    var makaleKonu = new MakaleKonu { MakaleID = makale.Id, KonuID = konuId };
                   makaleKonuSERVICE.Create(makaleKonu);
    
                }
     

                return RedirectToAction("Ekle");
            }

            
            model.TumKonular = await db.Konular
                .Select(k => new SelectListItem { Text = k.KonuAdi, Value = k.Id.ToString() })
                .ToListAsync();

            return View(model);
        }
        public async Task<IActionResult> Liste()
        {
            var userId =  userManager.GetUserId(User);
            var makaleler = await makaleSERVICE.GetMakalelerByUserId(userId);


            return View(makaleler);
        }
        public async Task<IActionResult> MakaleleriGor(int id)
        {
            var makaleler = await makaleKonuSERVICE.GetMakalelerByKonuIdAsync(id);

            return View(makaleler);
        }

    }
}
