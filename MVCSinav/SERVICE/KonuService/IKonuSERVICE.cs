using DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.KonuService
{
    public interface IKonuSERVICE
    {
        int Create(Konu model);
        int Update(Konu model);
        Task<int> Delete(int id);
        Task<List<Konu>> GetAllKonu();
        Task<Konu> GetKonu(int id);
    }
}
