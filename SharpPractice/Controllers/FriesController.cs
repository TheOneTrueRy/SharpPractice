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

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Fries>> CreateFries([FromBody] Fries friesData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        friesData.CreatorId = userInfo.Id;
        Fries fries = _friesService.CreateFries(friesData);
        return Ok(fries);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}