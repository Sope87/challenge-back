using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Service;
using BusinessLogicLayer.Service.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AntChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IGenericService<Student> _studentService;
        public StudentsController(IGenericService<Student> studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var response = await _studentService.GetListAsync();

            return Ok(response);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var response = await _studentService.GetByIdAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // GET: api/Student/GetStudentDetails/{id}
        [HttpGet("GetStudentDetails/{id}")]
        public async Task<ActionResult<Student>> GetStudentDetails(int id)
        {
            var student = await _studentService.GetByIdFullAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            try
            {
                //TODO no se si recuperarlo antes
                var response = await _studentService.UpdateAsync(student);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var classToCreate = await _studentService.CreateAsync(student);

            return CreatedAtAction("GetStudent", new { id = classToCreate.Id }, classToCreate);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentService.DeleteAsync(id);

            return Ok();
        }
    }
}
