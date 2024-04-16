using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multicontainerwithposgres.Data;
using Multicontainerwithposgres.Entity;
using System.Net;

namespace Multicontainerwithposgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherDbcontext _teacherDbcontext;

        public TeacherController(TeacherDbcontext teacherDbcontext)
        {
            _teacherDbcontext = teacherDbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _teacherDbcontext.Teachers.ToListAsync();
            return Ok(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Teacher teacher)
        {
            await _teacherDbcontext.AddAsync(teacher);
            await _teacherDbcontext.SaveChangesAsync();
            return StatusCode((int)HttpStatusCode.Created, teacher);
        }
    }
}
