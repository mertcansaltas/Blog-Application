using DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.MakaleKonuService
{
    public interface IMakaleKonuSERVICE
    {
        int Create(MakaleKonu model);
        int Update(MakaleKonu model);
        Task<int> Delete(int id);
        Task<List<MakaleKonu>> GetAllMakaleKonu();
        Task<MakaleKonu> GetMakaleKonu(int id);
        Task<List<Makale>> GetMakalelerByKonuIdAsync(int konuId);
    }
}
