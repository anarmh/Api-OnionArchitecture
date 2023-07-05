using AutoMapper;
using Domain.Entities;
using Service.DTOs.Company;
using Service.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyDto>().ForMember(dest => dest.CompanyName,opt=>opt.MapFrom(src=>src.Name));
            CreateMap<CompanyUpdateDto,Company>();
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.Company.Name));
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
