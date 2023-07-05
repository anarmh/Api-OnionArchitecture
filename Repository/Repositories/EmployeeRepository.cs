using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EmployeeRepository : Repository<Employee>,IEmployeeRepository
    {
        private readonly DbSet<Employee> _entites;
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _entites = _context.Set<Employee>();
        }

        public async Task<List<Employee>> GetAllWithIncludeAsync()
        {
            if(_entites == null )  throw new ArgumentNullException(nameof(_entites));
            return await _entites.Include(m => m.Company).ToListAsync();
        }

        
    }
}
