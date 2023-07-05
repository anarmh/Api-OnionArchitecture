using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
