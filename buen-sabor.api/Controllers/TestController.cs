using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace buen_sabor.api.Controllers;

[SwaggerResponse(200, "Success")]
[SwaggerResponse(404, "Not found")]
[SwaggerResponse(401, "Token required")]
[SwaggerResponse(500, "Internal error")]
public class TestController : ApiController
{
    private readonly IAppDBContext _context;

    public TestController(IAppDBContext context)
    {
        _context = context;
    }

    [HttpGet("200")]
    public ActionResult t200() => Ok();

    [HttpGet("500")]
    public ActionResult t500() => throw new Exception("Exception de test");


    [HttpGet("401")]
    public ActionResult t401() => Unauthorized();


    [HttpGet("404")]
    public ActionResult t404() => NotFound();

    [HttpGet("405")]
    public ActionResult t405() => BadRequest();

    [HttpGet("TestVersionDataBase")]
    [SwaggerOperation(Summary = "Test Connection to DataBase.")]
    public ActionResult TestVersionDataBase()
    {
        var result = _context.GetVersion();
        return Ok();
    }
    
   
}
