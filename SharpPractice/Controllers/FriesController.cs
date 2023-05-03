namespace SharpPractice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FriesController : ControllerBase
  {
    private readonly FriesService _friesService;
    private readonly Auth0Provider _auth;
  }
}