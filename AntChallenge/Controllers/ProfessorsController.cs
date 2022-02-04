using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntChallenge.ViewModels;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProfessorsController(IGenericService<Professor> professorService, IMapper mapper)
        {
            _professorService = professorService;
            _mapper = mapper;
        }

        // GET: api/Professors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorViewModel>>> GetProfessors()
        {
            var response =  await _professorService.GetListAsync();
            
            return Ok(_mapper.Map<IReadOnlyList<ProfessorViewModel>>(response));       
        }

        // GET: api/Professors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorViewModel>> GetProfessor(int id)
        {
            var response = await _professorService.GetByIdAsync(id); 

            if (response==null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map <ProfessorViewModel> (response));
        }

        // GET: api/Professors/GetProfessorDetails/{id}
        [HttpGet("GetProfessorDetails/{id}")]
        public async Task<ActionResult<ProfessorViewModel>> GetProfessorDetails(int id)
        {
            var professor = await _professorService.GetByIdFullAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProfessorViewModel>(professor));
        }

        // PUT: api/Professors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, ProfessorViewModel professorVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var getProfessor = await  _professorService.GetByIdAsync(id);
                if (getProfessor == null)
                {
                    return NotFound();
                }
                var professor = _mapper.Map<Professor>(professorVM);

                getProfessor.IsActive = professor.IsActive;
                getProfessor.Name = professor.Name;
                getProfessor.LastName = professor.LastName;
                getProfessor.Students = professor.Students;
                var response = await _professorService.UpdateAsync(getProfessor);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST: api/Professors
        [HttpPost]
        public async Task<ActionResult<ProfessorViewModel>> PostProfessor(ProfessorViewModel professorVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var professor = _mapper.Map<Professor>(professorVM);

            var classToCreate = await _professorService.CreateAsync(professor);

            return CreatedAtAction("GetProfessor", new { id = classToCreate.Id }, _mapper.Map<ProfessorViewModel>(classToCreate));
        }

        // DELETE: api/Professors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfessorViewModel>> DeleteProfessor(int id)
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
