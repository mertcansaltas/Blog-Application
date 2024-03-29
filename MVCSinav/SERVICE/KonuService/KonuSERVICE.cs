using DATA.Concrete;
using REPO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.KonuService
{
    public class KonuSERVICE : IKonuSERVICE
    {
        private readonly IKonuREPO konuREPO;

        public KonuSERVICE(IKonuREPO konuREPO)
        {
            this.konuREPO = konuREPO;
        }

        public int Create(Konu model)
        {
            return konuREPO.Create(model);
        }
        public int Update(Konu model)
        {
            
            return konuREPO.Update(model);
        }

        public async Task<int> Delete(int id)
        {
            var konu = await konuREPO.GetByIdAsync(id);
            return konuREPO.Delete(konu);
        }

        public async Task<List<Konu>> GetAllKonu()
        {
            var konular = await konuREPO.GetFilteredListAsync(select: x => new Konu() {KonuAdi=x.KonuAdi,Id=x.Id}, orderBy: x => x.OrderBy(x => x.KonuAdi));
            return konular;
        }

        public async Task<Konu> GetKonu(int id)
        {
            var konu = await konuREPO.GetByIdAsync(id);
            return new Konu() { KonuAdi=konu.KonuAdi};
        }


       
    }
}
