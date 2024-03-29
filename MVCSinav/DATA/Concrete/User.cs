using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Concrete
{
    public class User:IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string? Resim { get; set; }  
        public ICollection<KullaniciKonu> KullaniciKonulari { get; set; }
        public virtual ICollection<Makale> Makaleler { get; set; }
    }
}
