using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class buggyController : baseApiContoller
  {
    [HttpGet("not-found")]
    public ActionResult GetNotFound()
    {
      return NotFound();
    }
    [HttpGet("bad-request")]
    public ActionResult GetBadRequest()
    {
      return BadRequest(new ProblemDetails { Title = "This is a bad request" });
    }
    [HttpGet("unauthorized")]
    public ActionResult GetUnauthorized()
    {
      return Unauthorized();
    }
    [HttpGet("validation-error")]
    public ActionResult GetValidationError()
    {

      ModelState.AddModelError("problem1", "FirstError");

      ModelState.AddModelError("problemerro", "FirstError2");
      return ValidationProblem();
    }

    [HttpGet("server-error")]
    public ActionResult GetServerError()
    {
      throw new System.Exception("server error");
    }
  }
}