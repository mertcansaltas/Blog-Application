using DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Concrete
{
    public class MakaleKonu: BaseClass
    {
        public int MakaleID { get; set; }
        public Makale Makale { get; set; }
        public int KonuID { get; set; }
        public Konu Konu { get; set; }
    }
}
