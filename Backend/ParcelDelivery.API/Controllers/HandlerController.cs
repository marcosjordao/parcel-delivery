using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        private readonly IDepartmentService _departmentService;
        private readonly IParcelHandlerService _handlerService;
        private readonly IXmlParserService _xmlParserService;

        public HandlerController(IDepartmentService departmentService, IParcelHandlerService handlerService, IXmlParserService xmlParserService)
        {
            _departmentService = departmentService;
            _handlerService = handlerService;
            _xmlParserService = xmlParserService;
        }


        // GET: api/Handler
        [HttpGet]
        public ActionResult<Department> HandleParcelToDepartment([FromBody] Parcel parcel)
        {
            if (parcel == null)
                return BadRequest();

            IEnumerable<Department> departments = _departmentService.GetAllDepartments();

            Department department = _handlerService.HandleParcelToDepartment(departments,
                                                                             parcel);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        // POST: api/Handler/HandleContainerXml
        [HttpPost("HandleContainerXml/", Name = "HandleContainerXml")]
        public ActionResult<List<(Parcel parcel, Department department)>> HandleContainerXml(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file");

            // Accepts XML file
            if (file.ContentType != "text/xml")
                return BadRequest("Invalid file type");

            // Read the XML file
            XDocument xmlDocument = XDocument.Load(file.OpenReadStream());

            // Parse the XML to a Container
            Container container = _xmlParserService.ParseXml(xmlDocument);

            if (container == null)
                return BadRequest("Invalid file content");

            // Handle all Parcels in the Container
            IEnumerable<Department> departments = _departmentService.GetAllDepartments();
            var results = new List<(Parcel parcel, Department department)>();

            foreach (Parcel parcel in container.Parcels)
            {
                Department department = _handlerService.HandleParcelToDepartment(departments,
                                                                                 parcel);

                results.Add((parcel, department));
            }

            return Ok(results);
        }
    }
}