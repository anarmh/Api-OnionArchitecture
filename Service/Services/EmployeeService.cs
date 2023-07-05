using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Company;
using Service.DTOs.Employee;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(EmployeeCreateDto model)
        {
            Employee employee= _mapper.Map<Employee>(model);

            await _employeeRepo.CreateAsync(employee);
        }

        public async Task<List<EmployeeDto>> GetAllWithIncludeAsync()
        {
           List<Employee> res=await _employeeRepo.GetAllWithIncludeAsync();
           List<EmployeeDto> dtos= _mapper.Map<List<EmployeeDto>>(res);

            return dtos;
        }

        public async Task<Employee> GetByIdAsync(int? id)
        {
            return await _employeeRepo.FindAsync(id);
        }


        public async Task DeleteAsync(int? id)
        {
            Employee employee = await _employeeRepo.FindAsync(id);
            await _employeeRepo.DeleteAsync(employee);
        }



        public async Task<List<Employee>> Search(string searchText)
        {
            return await _employeeRepo.FindAllAsync(m => m.FullName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
        }

        public async Task UpdateAsync(int? id, EmployeeUpdateDto model)
        {
            Employee employee = await _employeeRepo.FindAsync(id);

            _mapper.Map(model, employee);

            await _employeeRepo.UpdateAsync(employee);
        }
    }
}
