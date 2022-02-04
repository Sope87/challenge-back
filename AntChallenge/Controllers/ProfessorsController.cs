using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Service;
using BusinessLogicLayer.Service.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AntChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        
        private IGenericService<Professor> _professorService;
        //private ProfessorRepository _professorRepository;
        public ProfessorsController(IGenericService<Professor> professorService)
        {
            _professorService = professorService;
            //_professorRepository = professorRepository;
        }

        // GET: api/Professors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
        {
            var response =  await _professorService.GetListAsync();
            
            return Ok(response);       
        }

        // GET: api/Professors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var response = await _professorService.GetByIdAsync(id); 

            if (response==null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // GET: api/Professors/GetProfessorDetails/{id}
        [HttpGet("GetProfessorDetails/{id}")]
        public async Task<ActionResult<Professor>> GetProfessorDetails(int id)
        {
            var professor = await _professorService.GetByIdFullAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // PUT: api/Professors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, Professor professor)
        {
            try
            {
                var getProfessor = await  _professorService.GetByIdAsync(id);
                if (getProfessor == null)
                {
                    return NotFound();
                }
                //TODO no se si recuperarlo antes
                var response = await _professorService.UpdateAsync(professor);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: api/Professors
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
            var classToCreate = await _professorService.CreateAsync(professor);

            return CreatedAtAction("GetProfessor", new { id = classToCreate.Id }, classToCreate);
        }

        // DELETE: api/Professors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Professor>> DeleteProfessor(int id)
        {
            var professor = await _professorService.GetByIdAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            await _professorService.DeleteAsync(id);

            return Ok();
        }

        
    }
}
