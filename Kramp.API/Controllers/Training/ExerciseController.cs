using Application.CQRS.ViewModels.Training;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers.Training
{
    [Route("api/exercises")]
    [ApiController]
    public class ExerciseController(ExerciseRepository _repository, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseViewModel>>> GetAllExercises()
        {
            var exercises = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ExerciseViewModel>>(exercises));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ExerciseViewModel>> GetExerciseById(Guid id)
        {
            var exercise = await _repository.GetByIdAsync(id);
            return Ok(_mapper.Map<ExerciseViewModel>(exercise));
        }
    }
}