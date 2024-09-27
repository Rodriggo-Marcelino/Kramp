﻿using Application.CQRS.GenericsCQRS.User.Commands;
using Application.CQRS.GenericsCQRS.User.ViewModel;
using Application.CQRS.UsersCQRS.ManagerCQ.Queries;
using AutoMapper;
using Domain.Entity.User;
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
        public async Task<ActionResult<UserGenericViewModel>> Create(CreateUserGenericCommand<Manager, UserGenericViewModel> command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<UserGenericViewModel>>> GetAllManagers()
        {
            var query = new GetAllManagersQuery();
            var managers = await _mediator.Send(query);
            return Ok(managers);
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<UserGenericViewModel>> GetManagerById(Guid Id)
        {
            var query = new GetManagerByIdQuery(Id);
            var manager = await _mediator.Send(query);
            return Ok(manager);
        }

        [HttpPut("Update/{Id:guid}")]
        public async Task<ActionResult<UserGenericViewModel>> Update(Guid Id/* UpdateManagerCommand command*/)
        {
            /*
            command.Id = Id;
            return Ok(await _mediator.Send(command));
            */
            throw new NotImplementedException();
        }

        [HttpDelete("Delete/{Id:guid}")]
        public async Task<ActionResult> DeleteById(Guid Id)
        {
            //TODO: Retirar o método de delete do controller (má prática)
            await _repository.DeleteByIdAsync(Id);
            return NoContent();
        }
    }
}
