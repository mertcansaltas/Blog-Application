using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Concrete
{
    public class KullaniciKonu
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int KonuId { get; set; }
        public Konu Konu { get; set; }

    }
}
