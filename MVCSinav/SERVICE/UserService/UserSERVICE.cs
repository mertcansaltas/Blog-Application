using DATA.Concrete;
using REPO.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.UserService
{
    public class UserSERVICE:IUserSERVICE
    {
        private readonly UserREPO userREPO;

        public UserSERVICE(UserREPO userREPO)
        {
            this.userREPO = userREPO;
        }

        public async Task<User> GetUser(int id)
        {
           return await userREPO.GetUser(id); 
        }
    }
}
