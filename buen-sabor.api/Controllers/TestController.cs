using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        [HttpGet("Domicilio/{id}")]
        [SwaggerOperation(Summary = "Test Domicilio Table.")]
        public async Task<ActionResult> TestDomicilio(Guid id)
        {
            //var result = _context.Domicilio.Where(w => w.Id == Guid.Parse("6e5fda37-4e40-47f4-b021-ed7573322d77"));
            var result = _context.Domicilio.Where(w => w.Id == id).AsNoTracking().FirstOrDefaultAsync().Result;
            return Ok(result);
        }
    }
}
