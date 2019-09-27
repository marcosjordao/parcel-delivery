using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.Services;

namespace ParcelDelivery.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();

            return Ok(departments);
        }


        // GET: api/Department/5
        [HttpGet("{id}", Name = "GetDepartment")]
        public async Task<ActionResult> GetByIdAsync(string id)
        {

            var department = await _departmentService.GetDepartmentByIdAsync(id);

            if (department != null)
                return Ok(department);
            else
                return NotFound();
        }

        // POST: api/Department
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department item)
        {
            if (item == null)
                return BadRequest();
            else
            {
                try
                {
                    await _departmentService.AddDepartmentAsync(item);

                    return CreatedAtRoute("GetDepartment", new { id = item.Id }, item);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }

        // PUT: api/Department
        [HttpPut]
        public async Task<ActionResult<Department>> Update([FromBody] Department item)
        {
            if (item == null)
                return BadRequest();

            try
            {
                await _departmentService.UpdateDepartmentAsync(item);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var department = await _departmentService.GetDepartmentByIdAsync(id);

                if (department == null)
                    return NotFound();

                await _departmentService.DeleteDepartmentAsync(department);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}