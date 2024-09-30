using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers.Training
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController(ExerciseRepository _repository, IMapper _mapper) : ControllerBase
    {
        /*
         * -- Ler Exercícios (Exercises) --
         * GET /api/exercises (Retorna todos os exercícios)
         * GET /api/exercises/{id} (Retorna um exercício específico pelo ID)
         */

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