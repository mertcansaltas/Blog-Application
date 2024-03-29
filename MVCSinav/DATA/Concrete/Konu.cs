using DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Concrete
{
    public class Konu:BaseClass
    {
        public string KonuAdi { get; set; }
        public ICollection<KullaniciKonu> KullaniciKonulari { get; set; }
        public ICollection<MakaleKonu> MakaleKonular{ get; set; }
    }
}
