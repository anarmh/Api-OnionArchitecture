using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Company;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepo,IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CompanyCreateDto model)
        {
           Company res=_mapper.Map<Company>(model);

            await _companyRepo.CreateAsync(res);

        }

        public async Task DeleteAsync(int? id)
        {
            Company company= await _companyRepo.FindAsync(id);

            await _companyRepo.DeleteAsync(company);
        }

        public async Task<List<CompanyDto>> GetAllAsync()
        {
            List<Company> res = await _companyRepo.FindAllAsync();

            List<CompanyDto> dto=_mapper.Map<List<CompanyDto>>(res);

            return dto;
        }

        public async Task<Company> GetByIdAsync(int? id)
        {
          Company company= await _companyRepo.FindAsync(id);
          return company;
        }

        public async Task<List<Company>> Search(string searchText)
        {
          return  await _companyRepo.FindAllAsync(m=>m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim()));
        }

        public async Task UpdateAsync(int? id, CompanyUpdateDto model)
        {
           Company company=await _companyRepo.FindAsync(id);

            _mapper.Map(model,company);

            await _companyRepo.UpdateAsync(company);
        }

        
    }
}
