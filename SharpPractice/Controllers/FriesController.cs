namespace SharpPractice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FriesController : ControllerBase
  {
    private readonly FriesService _friesService;
    private readonly Auth0Provider _auth;

    public FriesController(FriesService friesService, Auth0Provider auth)
    {
      _friesService = friesService;
      _auth = auth;
    }
  }
}