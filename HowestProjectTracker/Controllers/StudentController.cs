using HowestProjectTracker.Api.DTOs;
using HowestProjectTracker.Api.Extensions;
using HowestProjectTracker.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HowestProjectTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController(IStudentRepository repository) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<IEnumerable<StudentReadDto>>(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetStudents()
        {
            var students = await repository.GetStudentsAsync();
            return Ok(students.ToStudentReadDtos());
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType<StudentReadDto>(StatusCodes.Status200OK)]
        public async Task<ActionResult<StudentReadDto>> GetByIdAsync([Range(1, int.MaxValue)] int id)
        {
            var student = await repository.GetByIdAsync(id);
            if (student is null)
                return NotFound();
            return Ok(student.ToDetailDto());
        }
    }
}
