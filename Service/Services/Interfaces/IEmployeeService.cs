using Domain.Entities;
using Service.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllWithIncludeAsync();
        Task CreateAsync(EmployeeCreateDto model);
        Task<Employee> GetByIdAsync(int? id);
        Task DeleteAsync(int? id);
        Task<List<Employee>> Search(string searchText);
        Task UpdateAsync(int? id, EmployeeUpdateDto model);
    }
}
