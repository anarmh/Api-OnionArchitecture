using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entites;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entites = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity));

            await _entites.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

       

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _entites.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> expression= null)
        {
            return expression !=null ? await _entites.Where(expression).ToListAsync() : await _entites.ToListAsync(); 
        }

        public async Task<T> FindAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            return await _entites.FindAsync(id) ?? throw new NullReferenceException(nameof(id));
        }

        public async Task SoftDeleteAsync( int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            T? entity =await _entites.FindAsync(id);

            if (entity is null) throw new NullReferenceException();

            entity.SoftDelete=true; 
            
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _entites.Update(entity);

            await _context.SaveChangesAsync();
        }




    }
}
