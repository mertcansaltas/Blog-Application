using DATA.Concrete;
using Microsoft.EntityFrameworkCore;
using REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Concrete
{
    public class KullaniciKonuREPO
    {

        private readonly AppDbContext db;

        public KullaniciKonuREPO(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> TakipEdiliyorMu(string userId, int konuId)
        {
            return await db.KullaniciKonular
                .AnyAsync(kk => kk.UserId == userId && kk.KonuId == konuId);
        }

        public async Task TakipEt(string userId, int konuId)
        {
            var yeniTakip = new KullaniciKonu { UserId = userId, KonuId = konuId };
            db.KullaniciKonular.Add(yeniTakip);
            await db.SaveChangesAsync();
        }
        public async Task<KullaniciKonu> GetKullaniciKonuAsync(string userId, int konuId)
        {
            return await db.KullaniciKonular.FirstOrDefaultAsync(kk => kk.UserId == userId && kk.KonuId == konuId);
        }

    }
}
