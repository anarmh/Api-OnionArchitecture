using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Employee
{
    public class EmployeeCreateDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
