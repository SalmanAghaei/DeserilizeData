using MediatR;
using Toolkit;
using Contract.Dtos;
using Contract.Queries;
using Contract.Commands;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers;

[ApiController]

public class PersonController : ControllerBase
{

    private readonly IMediator _mediator;
    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [Route("{datatype}/[controller]")]
    [ProducesResponseType(typeof(ServiceResult), 200)]
    public async Task<IActionResult> Post(PersonCreateCommand add)
    {
        var result = await _mediator.Send(add);
        return StatusCode((int)result.HttpStatusCode, result);
    }




    [HttpPut]
    [Route("[controller]/[action]")]
    [ProducesResponseType(typeof(ServiceResult), 200)]
    public async Task<IActionResult> Put(PersonEditCommand edit)
    {
        var result = await _mediator.Send(edit);
        return StatusCode((int)result.HttpStatusCode, result);
    }





    [HttpDelete]
    [Route("[controller]/[action]")]
    [ProducesResponseType(typeof(ServiceResult), 200)]

    public async Task<IActionResult> Delete([FromQuery] PersonDeleteCommand delete)
    {
        var result = await _mediator.Send(delete);
        return StatusCode((int)result.HttpStatusCode, result);
    }


    [HttpGet]
    [Route("[controller]/[action]")]
    [ProducesResponseType(typeof(ServiceResult<PersonGetSalaryDto>), 200)]
    public async Task<IActionResult> Get([FromQuery] PersonGetSalaryQuery query)
    {
        var result = await _mediator.Send(query);
        return StatusCode((int)result.HttpStatusCode, result);
    }



    [HttpGet]
    [Route("[controller]/[action]")]
    [ProducesResponseType(typeof(ServiceResult<List<PersonGetSalaryDto>>), 200)]
    public async Task<IActionResult> GetRange([FromQuery] PersonGetSalaryWithdateRangeQuery query)
    {
        var result = await _mediator.Send(query);
        return StatusCode((int)result.HttpStatusCode, result);
    }




}
