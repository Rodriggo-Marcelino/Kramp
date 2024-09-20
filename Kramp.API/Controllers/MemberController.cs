using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using Application.CQRS.UsersCQRS.MemberCQ.Commands;
using Application.CQRS.UsersCQRS.MemberCQ.ViewModels;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(IMediator _mediator, MemberRepository _repository, IMapper _mapper) : ControllerBase
    {

        [HttpPost("Create")]
        public async Task<ActionResult<MemberInfoViewModel>> Create(CreateMemberCommand command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<ActionResult<MemberInfoViewModel>> GetAllMembers()
        {
            var members = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GymInfoViewModel>>(members));
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<MemberInfoViewModel>> GetMemberById(Guid Id)
        {
            Member? member = await _repository.GetByIdAsync(Id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GymInfoViewModel>(member));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<MemberInfoViewModel>> Update(Guid Id, UpdateMemberCommand command)
        {
            command.Id = Id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("Delete/{Id:guid}")]
        public async Task<ActionResult<MemberInfoViewModel>> DeleteById(Guid Id)
        {
            await _repository.DeleteByIdAsync(Id, new CancellationToken());
            return NoContent();
        }
    }
}
