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

        //changes for Student data delete
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent (int id)
        {
            bool a = false;
            var student = _studentDbContext.Student.Find(id);
            if(student!=null)
            {
                a = true;
                _studentDbContext.Entry(student).State = EntityState.Deleted;//Entity framework is doing this internally or manually we have toi run delete querry
                _studentDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }

    }
}//This is test by charan from github //
