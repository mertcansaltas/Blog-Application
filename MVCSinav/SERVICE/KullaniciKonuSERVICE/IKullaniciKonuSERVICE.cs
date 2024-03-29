using DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.KullaniciKonuSERVICE
{
    public interface IKullaniciKonuSERVICE
    {
        Task<bool> TakipEdiliyorMu(string userId, int konuId);
        Task TakipEt(string userId, int konuId);
        Task<KullaniciKonu> GetKullaniciKonuAsync(string userId, int konuId);
    }
}
