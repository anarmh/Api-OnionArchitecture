using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using Service.DTOs.Company;
using Service.Services.Interfaces;

namespace Api_OnionArchitecture.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService= companyService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _companyService.CreateAsync(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _companyService.GetAllAsync());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] CompanyUpdateDto request,[FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _companyService.UpdateAsync(id,request);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int? id)
        {
            await _companyService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery]string searchTerm)
        {
            var searchResults = await _companyService.Search(searchTerm);
            if (searchResults.Count == 0)
            {
                return NotFound();
            }
            return Ok(searchResults);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            try
            {
                var company = await _companyService.GetByIdAsync(id);
                return Ok(company);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
