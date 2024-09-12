using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.RestaurantCQ.Commands;
using Restaurants.Application.RestaurantCQ.Queries;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IMediator _mediator;

    public RestaurantController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRestaurants()
    {
        var query = new GetAllRestaurantsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetRestaurantById([FromRoute] Guid id)
    {
        var query = new GetRestaurantByIdQuery(id);
        var result = await _mediator.Send(query);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddRestaurant([FromBody] Restaurant restaurant)
    {
        var command = new AddRestaurantCommand(restaurant);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] Guid id, [FromBody] Restaurant restaurant)
    {
        var command = new UpdateRestaurantCommand(id, restaurant);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] Guid id)
    {
        var command = new DeleteRestaurantCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
