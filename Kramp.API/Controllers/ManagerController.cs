using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController(IMediator _mediator, ManagerRepository _repository, IMapper _mapper) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<ManagerInfoViewModel>> Create(CreateManagerCommand command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<ManagerInfoViewModel>>> GetAllManagers()
        {
            var managers = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ManagerInfoViewModel>>(managers));
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<ManagerInfoViewModel>> GetManagerById(Guid Id)
        {
            Manager? manager = await _repository.GetByIdAsync(Id);
            
            if(manager == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ManagerInfoViewModel>(manager));
        }

        [HttpPut("Update/{Id:guid}")]
        public async Task<ActionResult<ManagerInfoViewModel>> Update(Guid Id, UpdateManagerCommand command)
        {
            command.Id = Id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("Delete/{Id:guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            //TODO: Retirar o método de delete do controller (má prática)
            await _repository.DeleteByIdAsync(Id, new CancellationToken());
            return NoContent();
        }
    }
}
