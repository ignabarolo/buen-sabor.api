using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace buen_sabor.api.Controllers
{
    [ApiController]
    [Route("api/")]
    public abstract class ApiController : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
