using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace buen_sabor.api.Controllers
{
    public class TestController : Controller
    {
        private readonly IAppDBContext _context;

        public TestController(IAppDBContext context)
        {
            _context = context;
        }

        [HttpGet("Test")]
        [SwaggerOperation(Summary = "Test Connection to DataBase.")]
        public async Task<ActionResult> TestDataBase()
        {
            var result = _context.GetVersion();
            return Ok();
        }
        
        [HttpGet("Domicilio")]
        [SwaggerOperation(Summary = "Test Domicilio Table.")]
        public async Task<ActionResult> TestDomicilio()
        {
            var result = _context.Domicilio.Where(w => w.Id == Guid.Parse("6e5fda37-4e40-47f4-b021-ed7573322d77"));
            return Ok(result);
        }
    }
}
