using DATA.Concrete;
using Microsoft.EntityFrameworkCore;
using REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Concrete
{
    public class UserREPO
    {
        public readonly AppDbContext db;

        public UserREPO(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<User> GetUser(int id)
        {
            var makale = db.Makaleler.FirstOrDefault(x=>x.Id==id);
            return await db.Users.FirstOrDefaultAsync(x => x.Id == makale.UserId);
        }
    }
}
