using Domain.Primitives;
using DT.API.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DT.API.Infrastructure
{
    [Route("api")]
    public class ApiController:ControllerBase
    {
        protected ApiController(ISender sender) => Sender=sender;

        protected ISender Sender { get;}

        protected IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new[] { error }));


        protected new  IActionResult Ok(object value)=>base.Ok(value);

        protected new IActionResult NoFound() => NotFound("The request resource is not found.");
    }
}
