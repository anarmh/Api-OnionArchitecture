using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Company;
using Service.DTOs.Employee;
using Service.Services;
using Service.Services.Interfaces;

namespace Api_OnionArchitecture.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res= await _employeeService.GetAllWithIncludeAsync();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _employeeService.CreateAsync(request);
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            return Ok(await _employeeService.GetByIdAsync(id));
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] EmployeeUpdateDto request, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _employeeService.UpdateAsync(id, request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchTerm)
        {
            var searchResults = await _employeeService.Search(searchTerm);
            if (searchResults.Count == 0)
            {
                return NotFound();
            }
            return Ok(searchResults);
        }

    }
}
