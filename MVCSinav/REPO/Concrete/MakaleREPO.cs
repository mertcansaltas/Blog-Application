using DATA.Concrete;
using Microsoft.EntityFrameworkCore;
using REPO.Abstract;
using REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Concrete
{
    public class MakaleREPO : BaseREPO<Makale>, IMakaleREPO
    {
        private readonly AppDbContext db;
        public MakaleREPO(AppDbContext db) : base(db)
        {
            this.db = db;   
        }
        public async Task<List<Makale>> GetMakalelerByUserId(string userId)
        {
            return await db.Makaleler.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task IncreaseOkunmaSayisi(int id)
        {
            var makale = await db.Makaleler.FindAsync(id);
            if (makale != null)
            {
                makale.OkunmaSayisi++;
                await db.SaveChangesAsync();
            }
        }
    }
}
