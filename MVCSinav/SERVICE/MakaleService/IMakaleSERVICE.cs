using DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.MakaleService
{
    public interface IMakaleSERVICE
    {
        int Create(Makale model);
        int Update(Makale model);
        Task<int> Delete(int id);
        Task<List<Makale>> GetAllMakale();
        Task<Makale> GetMakale(int id);
        Task<List<Makale>> GetMakalelerByUserId(string userId);
        Task IncreaseOkunmaSayisi(int id);


    }
}
