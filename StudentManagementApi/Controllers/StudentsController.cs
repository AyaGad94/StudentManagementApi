using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models;
using StudentManagementApi.Services;

namespace StudentManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_service.GetById(id));//Calls the GetById(id) method from the service then returns an HTTP 200 (OK) response with the student data in the body

        [HttpPost]
        public IActionResult Add(Student student) => Created("", _service.Add(student));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // built in interface that represents the result of an action method in a controller.
        {
            _service.Delete(id);
            return Ok(); //returns 200 OK (with or without a body).
        }
    }
}
