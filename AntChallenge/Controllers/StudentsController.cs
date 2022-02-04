using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntChallenge.ViewModels;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public StudentsController(IGenericService<Student> studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetStudents()
        {
            var response = await _studentService.GetListAsync();

            return Ok(_mapper.Map<IReadOnlyList<StudentViewModel>>(response));
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentViewModel>> GetStudent(int id)
        {
            var response = await _studentService.GetByIdAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentViewModel>(response));
        }

        // GET: api/Student/GetStudentDetails/{id}
        [HttpGet("GetStudentDetails/{id}")]
        public async Task<ActionResult<StudentViewModel>> GetStudentDetails(int id)
        {
            var student = await _studentService.GetByIdFullAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentViewModel>(student));
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentViewModel studentVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var getStudent = await _studentService.GetByIdAsync(id);
                if (getStudent == null)
                {
                    return NotFound();
                }
                var student = _mapper.Map<Student>(studentVM);

                getStudent.IsActive = student.IsActive;
                getStudent.Name = student.Name;
                getStudent.LastName = student.LastName;
                getStudent.ProfessorId = student.ProfessorId;
                var response = await _studentService.UpdateAsync(getStudent);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<StudentViewModel>> PostStudent(StudentViewModel studentVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = _mapper.Map<Student>(studentVM);
            var classToCreate = await _studentService.CreateAsync(student);

            return CreatedAtAction("GetStudent", new { id = classToCreate.Id }, _mapper.Map<StudentViewModel>(classToCreate));
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentViewModel>> DeleteStudent(int id)
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
