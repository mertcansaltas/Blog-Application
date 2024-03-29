using BurgerREPO.Abstract;
using DATA.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using REPO.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Concrete
{
    public class BaseREPO<T> : IBaseREPO<T> where T : BaseClass
    {
        private AppDbContext db;
        private DbSet<T> table;

        public BaseREPO(AppDbContext db)
        {
            this.db = db;
            table = db.Set<T>(); //Hangi table gönderiyorsam Set ifadesi DbSete gidip o table i bulur.Örneğin T, category ise Set ifadesi DbSete gidip DbSet<Category> getirir.
        }

        public int Create(T entity)
        {
            table.Add(entity);
            return db.SaveChanges();
        }

        public int Delete(T entity)
        {
            table.Remove(entity);
            return db.SaveChanges();
        }

        public int Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await table.AnyAsync(expression); //await,senkron yapıyla koordinasyonu bekletme görevini sağlar.
        }

        public async Task<TResult> GetFilteredFirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = table; //Sıralı dönmek için IQueryable T tipinde sıralanabilen bir liste yapıyorum.
            if (join != null)
            {
                query = join(query); //İki tabloyu birleştirip tekrar querye attık
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(select).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(select).FirstOrDefaultAsync();
            }
        }

        public async Task<List<TResult>> GetFilteredListAsync<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = table; //Sıralı dönmek için IQueryable T tipinde sıralanabilen bir liste yapıyorum.
            if (join != null)
            {
                query = join(query); //İki tabloyu birleştirip tekrar querye attık
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(select).ToListAsync();  //Metodun Geriye dönüş tipi list olduğundan tolist yaptık.
            }

            else
            {
                return await query.Select(select).ToListAsync();
            }
        }
       
    }
}
