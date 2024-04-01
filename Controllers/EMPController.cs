using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreWebApiProject.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class EMPController : ControllerBase
    {
        [Route("employees/all")]
        public string GetAllEMPloyees()
        {
            return "All Employees Here";
        }
        // [Route("employees/{id}")]
        // Pass multiple constraints min(100),
        [Route("employees/{id:int:min(100)}")]
        public string GetEMPloyeeById(int id)
        {
            return "Employeeswith Id:" + id;
        }
        [Route("emp/{id:int}")]
        public string GetEmployeeDetails(int id)
        {
            return "Employee Details" + id;
        }
        [Route("emp{name:alpha}")]
        public string GetEmployeeDetails(string name)
        {
            return "Employee Details" + name;
        }
    }
}
