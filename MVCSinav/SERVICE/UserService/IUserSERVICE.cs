using DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.UserService
{
    public interface IUserSERVICE
    {
        Task<User> GetUser(int id);
    }
}
