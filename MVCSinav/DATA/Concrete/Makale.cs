using DATA.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Concrete
{
    public class Makale:BaseClass
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public double OkumaSuresi { get; set; }
        public DateTime YayınTarihi { get; set; }
        public int OkunmaSayisi { get; set; }

        public ICollection<MakaleKonu> MakaleKonular { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
