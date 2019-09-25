using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.Services;
using ParcelDelivery.Domain.ValueObjects;

namespace ParcelDelivery.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HandlerController : ControllerBase
    {
        private readonly IParcelHandlerService _handlerService;
        private readonly ICollection<Department> _departments;

        public HandlerController(IParcelHandlerService handlerService)
        {
            _handlerService = handlerService;

            // Setup fake departments
            _departments = new List<Department>();
            _departments.Add(CreateFakeDepartment(name: "Mail", weightMax: 1));
            _departments.Add(CreateFakeDepartment(name: "Regular", weightMin: 1, weightMax: 10));
            _departments.Add(CreateFakeDepartment(name: "Heavy", weightMin: 10));
            _departments.Add(CreateFakeDepartment(name: "Insurance", valueMin: 1000));
        }


        // GET: api/Handle
        [HttpGet]
        public ActionResult GetDepartmentToHandle([FromBody] Parcel parcel)
        {
            if (parcel == null)
                return BadRequest();

            Department department = _handlerService.HandleParcelToDepartment(_departments, parcel);

            if (department == null)
                return NotFound();

            return Ok(department);
        }


        private Department CreateFakeDepartment(string name, decimal? weightMin = null, decimal? weightMax = null, decimal? valueMin = null, decimal? valueMax = null)
        {
            Department department = new Department(name);

            if (weightMin.HasValue || weightMax.HasValue)
                department.WeightCriteria = new Interval(weightMin, weightMax);

            if (valueMin.HasValue || valueMax.HasValue)
                department.ValueCriteria = new Interval(valueMin, valueMax);

            return department;
        }

    }
}