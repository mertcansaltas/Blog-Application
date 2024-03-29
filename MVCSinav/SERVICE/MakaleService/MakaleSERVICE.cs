using DATA.Concrete;
using REPO.Abstract;
using REPO.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.MakaleService
{
    public class MakaleSERVICE:IMakaleSERVICE
    {
        private readonly IMakaleREPO makaleREPO;

        public MakaleSERVICE(IMakaleREPO makaleREPO)
        {
            this.makaleREPO = makaleREPO;
        }

        public int Create(Makale model)
        {
            return makaleREPO.Create(model);
        }
        public int Update(Makale model)
        {

            return makaleREPO.Update(model);
        }

        public async Task<int> Delete(int id)
        {
            var konu = await makaleREPO.GetByIdAsync(id);
            return makaleREPO.Delete(konu);
        }

        public async Task<List<Makale>> GetAllMakale()
        {
            var makaleler = await makaleREPO.GetFilteredListAsync(orderBy: q => q.OrderByDescending(x => x.OkunmaSayisi), select: x => new Makale() { Baslik=x.Baslik, Icerik=x.Icerik, OkumaSuresi=x.OkumaSuresi, OkunmaSayisi=x.OkunmaSayisi, YayınTarihi=x.YayınTarihi,Id=x.Id});
            return makaleler;
        }

        public async Task<Makale> GetMakale(int id)
        {
            var makale = await makaleREPO.GetByIdAsync(id);
            return new Makale() { Id=makale.Id, Baslik = makale.Baslik, Icerik = makale.Icerik, OkumaSuresi = makale.OkumaSuresi, OkunmaSayisi = makale.OkunmaSayisi, YayınTarihi = makale.YayınTarihi, UserId=makale.UserId };
            
        }

        public async Task<List<Makale>> GetMakalelerByUserId(string userId)
        {
            return await makaleREPO.GetMakalelerByUserId(userId);
        }
        public async Task IncreaseOkunmaSayisi(int id)
        {
            await makaleREPO.IncreaseOkunmaSayisi(id);
        }
    }
}
