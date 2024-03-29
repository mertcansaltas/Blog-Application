using BlogUI.Models;
using BlogUI.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using SERVICE.KonuService;
using SERVICE.MakaleService;
using System.Diagnostics;

namespace BlogUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMakaleSERVICE makaleSERVICE;
        private readonly IKonuSERVICE   konuSERVICE;

        public HomeController(IKonuSERVICE konuSERVICE, IMakaleSERVICE makaleSERVICE)
        {
            this.konuSERVICE = konuSERVICE;
            this.makaleSERVICE = makaleSERVICE;
        }

        public async Task<IActionResult> Index()
        {
            var makaleKonuVM = new MakaleKonuVM()
            {
                Konular = await konuSERVICE.GetAllKonu(),
                Makaleler = await makaleSERVICE.GetAllMakale()
            };
            return View(makaleKonuVM);
        }
        public IActionResult Hakkimizda()
        {
            return View();  
        }
      
    }
}
