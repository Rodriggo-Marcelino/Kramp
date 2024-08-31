using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController(IMediator mediator, KrampDbContext context, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // TODO: Repositories
        // Injetando DbContext e Mapper temporariamente enquanto não temos repository
        // Objetivo: Requisição GET e DELETE
        private readonly KrampDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpPost("Create")]
        public async Task<ActionResult<ManagerInfoViewModel>> Create(CreateManagerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<ManagerInfoViewModel>>> GetAllManagers()
        {
            //TODO: Retirar isso do controller
            List<Manager> managers = _context.Managers.ToList();
            IEnumerable<ManagerInfoViewModel> response = _mapper.Map<IEnumerable<ManagerInfoViewModel>>(managers);
            return Ok(response);
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<ManagerInfoViewModel>> GetManagerById(Guid Id)
        {
            //TODO: Retirar isso do controller
            Manager manager = _context.Managers.Find(Id);
            ManagerInfoViewModel response = _mapper.Map<ManagerInfoViewModel>(manager);
            return Ok(response);
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
            //TODO: Retirar isso do controller
            var deleteThis = await _context.Managers.FindAsync(Id);
            if (deleteThis == null)
            {
                return NotFound();
            }
            _context.Managers.Remove(deleteThis);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
