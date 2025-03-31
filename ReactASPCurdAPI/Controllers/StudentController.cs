using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactASPCurdAPI.Models;

namespace ReactASPCurdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentController(StudentDbContext studentDbContext) 
        {
            _studentDbContext = studentDbContext;
        
        }
        [HttpGet]
        [Route("Getstudent")]
        public async Task <IEnumerable<Student>>GetStudents()
        {
            return await _studentDbContext.Student.ToListAsync();
        }
        
    }
}
