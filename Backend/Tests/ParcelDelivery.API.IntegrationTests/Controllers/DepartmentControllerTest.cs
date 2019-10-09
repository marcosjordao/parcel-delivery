using Newtonsoft.Json;
using ParcelDelivery.API.IntegrationTests.Configuration;
using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParcelDelivery.API.IntegrationTests.Controllers
{
    public class DepartmentControllerTest : BaseIntegrationTest
    {
        private const string BASE_URL = "api/v1/department";

        public DepartmentControllerTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task CreateDepartment_GetById_IntegrationTest()
        {
            var newDepartment = await CreateNewDepartment("Test Department");
            await CheckIfNewDepartmentWasAdded(newDepartment);
        }

        [Fact]
        public async Task CreateDepartment_GetAllDepartments_IntegrationTest()
        {
            var initialCount = await GetAllDepartmentsCount();
            var expected = initialCount + 2;

            await CreateNewDepartment("Department 1");
            await CreateNewDepartment("Department 2");

            var countAfterCreate = await GetAllDepartmentsCount();

            Assert.Equal(expected, countAfterCreate);
        }

        [Fact]
        public async Task GetAllDepartments_IntegrationTest()
        {
            var response = await Server
                .CreateRequest(BASE_URL)
                .GetAsync();

            Assert.Equal(200, (int)response.StatusCode);

            var responseObj = JsonConvert.DeserializeObject<List<Department>>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(responseObj);
            Assert.NotEmpty(responseObj);
        }



        private async Task<Department> CreateNewDepartment(string name)
        {
            var department = new Department(name);

            var response = await Server
                .CreateRequest(BASE_URL)
                .And(req => req.Content = GenerateRequestContent(department))
                .PostAsync();

            Assert.Equal(201, (int)response.StatusCode);

            var responseObj = JsonConvert.DeserializeObject<Department>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(response);
            Assert.Equal(name, responseObj.Name);

            return responseObj;
        }

        private async Task CheckIfNewDepartmentWasAdded(Department addedDepartment)
        {
            var response = await Server
                .CreateRequest($"{BASE_URL}/{addedDepartment.Id}")
                .GetAsync();

            Assert.Equal(200, (int)response.StatusCode);

            var responseObj = JsonConvert.DeserializeObject<Department>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(responseObj);
            Assert.Equal(addedDepartment.Id, responseObj.Id);
        }


        private async Task CheckAllAddedDepartments(int expectedCount)
        {
            var response = await Server
                .CreateRequest(BASE_URL)
                .GetAsync();

            Assert.Equal(200, (int)response.StatusCode);

            var responseObj = JsonConvert.DeserializeObject<List<Department>>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(responseObj);
            Assert.NotEmpty(responseObj);
            Assert.Equal(expectedCount, responseObj.Count);
        }


        private async Task<int> GetAllDepartmentsCount()
        {
            var response = await Server
                .CreateRequest(BASE_URL)
                .GetAsync();


            var responseObj = JsonConvert.DeserializeObject<List<Department>>(await response.Content.ReadAsStringAsync());
            return responseObj.Count;
        }
    }
}
