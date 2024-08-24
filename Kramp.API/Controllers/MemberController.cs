﻿using Application.MemberCQ.Commands;
using Application.MemberCQ.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kramp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Create")]
        public async Task<ActionResult<MemberInfoViewModel>> Create(CreateMemberCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("Read")]
        public async Task<ActionResult<MemberInfoViewModel>> Read(CreateMemberCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<MemberInfoViewModel>> Update(CreateMemberCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<MemberInfoViewModel>> Delete(CreateMemberCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
