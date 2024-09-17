using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.DishCQ.Commands;
using Restaurants.Application.DishCQ.Queries;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/Restaurants/{restaurantId}")]
public class DishesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DishesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("dishes")]
    public async Task<IActionResult> GetAllDishes([FromRoute] Guid restaurantId)
    {
        var query = new GetAllDishesQuery(restaurantId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("dishes/{dishId}")]
    public async Task<IActionResult> GetDishById([FromRoute] Guid restaurantId, Guid dishId)
    {
        var query = new GetDishByIdQuery(restaurantId, dishId);
        var result = await _mediator.Send(query);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDish([FromBody] Dish dish)
    {
        var command = new CreateDishCommand(dish);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [Route("dishes/{dishId}")]
    public async Task<IActionResult> DeleteDish([FromRoute] Guid restaurantId, Guid dishId)
    {
        var command = new DeleteDishCommand(restaurantId, dishId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
