namespace SharpPractice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DrinksController : ControllerBase
  {
    private readonly DrinksService _drinksService;
    private readonly Auth0Provider _auth;
  }
}