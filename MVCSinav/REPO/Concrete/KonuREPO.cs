using BurgerREPO.Abstract;
using DATA.Concrete;
using REPO.Abstract;
using REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Concrete
{
    public class KonuREPO : BaseREPO<Konu>, IKonuREPO
    {
        public KonuREPO(AppDbContext db) : base(db)
        {
        }
    }
}
