using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogUI.Models.VMs
{
    public class MakaleEklemeVM
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public float OkumaSuresi { get; set; }
        public DateTime YayinTarihi { get; set; }
        public int OkunmaSayisi { get; set; }
        public List<int> SecilenKonular { get; set; } = new List<int>();
        public List<SelectListItem> TumKonular { get; set; } = new List<SelectListItem>();
    }
}
