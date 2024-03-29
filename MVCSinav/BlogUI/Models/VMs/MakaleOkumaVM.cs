using DATA.Concrete;

namespace BlogUI.Models.VMs
{
    public class MakaleOkumaVM
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string YazarAdi { get; set; }
        public DateTime YayınTarihi { get; set; }
        public double OkumaSuresi { get; set; }
        public int OkunmaSayisi { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
