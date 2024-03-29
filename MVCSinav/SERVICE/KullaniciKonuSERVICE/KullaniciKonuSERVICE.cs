using DATA.Concrete;
using REPO.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.KullaniciKonuSERVICE
{
    public class KullaniciKonuSERVICE:IKullaniciKonuSERVICE
    {
        private readonly KullaniciKonuREPO kullaniciKonuREPO;

        public KullaniciKonuSERVICE(KullaniciKonuREPO kullaniciKonuREPO)
        {
            this.kullaniciKonuREPO = kullaniciKonuREPO;
        }

        public async Task<bool> TakipEdiliyorMu(string userId, int konuId)
        {
            return await kullaniciKonuREPO.TakipEdiliyorMu(userId, konuId);
        }

        public async Task TakipEt(string userId, int konuId)
        {
            await kullaniciKonuREPO.TakipEt(userId, konuId);
        }
        public async Task<KullaniciKonu> GetKullaniciKonuAsync(string userId, int konuId)
        {
            return await kullaniciKonuREPO.GetKullaniciKonuAsync(userId, konuId);
        }
    }
}
