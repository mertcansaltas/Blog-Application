using DATA.Concrete;
using Microsoft.EntityFrameworkCore;
using REPO.Abstract;
using REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Concrete
{
    public class MakaleKonuREPO : BaseREPO<MakaleKonu>, IMakaleKonuREPO
    {
        private readonly AppDbContext db;
        public MakaleKonuREPO(AppDbContext db) : base(db)
        {
            this.db=db;
        }
        public async Task<List<Makale>> GetMakalelerByKonuIdAsync(int konuId)
        {
            return await db.makaleKonular
                           .Where(mk => mk.KonuID == konuId)
                           .Select(mk => mk.Makale)
                           .ToListAsync();
        }
    }
}
