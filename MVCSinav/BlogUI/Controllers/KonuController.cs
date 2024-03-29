using BlogUI.Models.VMs;
using DATA.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REPO.Context;
using SERVICE.KonuService;
using SERVICE.KullaniciKonuSERVICE;
using SERVICE.MakaleService;

namespace BlogUI.Controllers
{
    public class KonuController : Controller
    {
        private readonly IKullaniciKonuSERVICE kullaniciKonuSERVICE;
        private readonly UserManager<User> userManager;
        private readonly IKonuSERVICE konuSERVICE;
        private readonly AppDbContext db;
        private readonly IKullaniciKonuSERVICE kullaniciKonuService;


        public KonuController(IKullaniciKonuSERVICE kullaniciKonuSERVICE, UserManager<User> userManager, IKonuSERVICE konuSERVICE, AppDbContext db, IKullaniciKonuSERVICE kullaniciKonuService)
        {
            this.kullaniciKonuSERVICE = kullaniciKonuSERVICE;
            this.userManager = userManager;
            this.konuSERVICE = konuSERVICE;
            this.db = db;
            this.kullaniciKonuService = kullaniciKonuService;
        }

        public async Task<IActionResult> Index()
        {
            var konular = await konuSERVICE.GetAllKonu();
            return View(konular);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> TakipEt(int konuId)
        {

            var userId = userManager.GetUserId(User);


            var zatenTakipEdiliyorMu = await kullaniciKonuSERVICE.TakipEdiliyorMu(userId, konuId);
            if (!zatenTakipEdiliyorMu)
            {

                await kullaniciKonuSERVICE.TakipEt(userId, konuId);
                TempData["Bildirim"] = "Konu başarıyla takip edildi.";
            }
            else
            {
                TempData["Bildirim"] = "Bu konuyu zaten takip ediyorsunuz!";
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> TakiptenCik(int konuId)
        {
            var userId = userManager.GetUserId(User);

            var takip = await kullaniciKonuSERVICE.GetKullaniciKonuAsync(userId, konuId);
            if (takip != null)
            {
                
                db.KullaniciKonular.Remove(takip);
                await db.SaveChangesAsync();

                TempData["Bildirim"] = "Konu başarıyla takipten çıkarıldı.";
            }
            else
            {
                TempData["Bildirim"] = "Takip edilen konu bulunamadı.";
            }

            return RedirectToAction("Index","User"); 
        }
    }


}
