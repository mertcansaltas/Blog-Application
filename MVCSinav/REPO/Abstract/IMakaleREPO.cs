using BurgerREPO.Abstract;
using DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Abstract
{
    public interface IMakaleREPO:IBaseREPO<Makale>
    {
        Task<List<Makale>> GetMakalelerByUserId(string userId);
        Task IncreaseOkunmaSayisi(int id);
    }
}
