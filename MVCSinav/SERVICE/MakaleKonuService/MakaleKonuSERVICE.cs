using DATA.Concrete;
using REPO.Abstract;
using REPO.Concrete;
using SERVICE.MakaleKonuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.MakaleKonuService
{
    public class MakaleKonuSERVICE : IMakaleKonuSERVICE
    {
        private readonly IMakaleKonuREPO makaleKonuREPO;

        public MakaleKonuSERVICE(IMakaleKonuREPO makaleKonuREPO)
        {
            this.makaleKonuREPO = makaleKonuREPO;
        }

        public int Create(MakaleKonu model)
        {
            return makaleKonuREPO.Create(model);
        }
        public int Update(MakaleKonu model)
        {

            return makaleKonuREPO.Update(model);
        }

        public async Task<int> Delete(int id)
        {
            var konu = await makaleKonuREPO.GetByIdAsync(id);
            return makaleKonuREPO.Delete(konu);
        }

        public async Task<List<MakaleKonu>> GetAllMakaleKonu()
        {
            var makalekonular = await makaleKonuREPO.GetFilteredListAsync(select: x => new MakaleKonu() { Id=x.Id, MakaleID=x.MakaleID,KonuID=x.KonuID });
            return makalekonular;
        }

        public async Task<MakaleKonu> GetMakaleKonu(int id)
        {
            var makalekonu = await makaleKonuREPO.GetByIdAsync(id);
            return new MakaleKonu() {Id=makalekonu.Id, KonuID=makalekonu.KonuID,MakaleID=makalekonu.MakaleID };
        }
        public async Task<List<Makale>> GetMakalelerByKonuIdAsync(int konuId)
        {
            return await makaleKonuREPO.GetMakalelerByKonuIdAsync(konuId);
        }

    }
}
