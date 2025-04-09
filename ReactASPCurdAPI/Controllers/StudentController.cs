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
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Student.ToListAsync();
        }
        [HttpPost]
        [Route("Addstudent")]
        public async Task<Student> Addstudent(Student objStudent)
        {
            _studentDbContext.Student.Add(objStudent);
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }
        //this is test by bhuvan for gethub branch updting//

        //changes for Student Data Update 
        [HttpPatch]
        [Route("Updatestudent/{id}")]
        public async Task<Student> Updatestudent(Student objStudent)
        {
            _studentDbContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }
    }
}//This is test by charan from github //
