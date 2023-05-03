namespace SharpPractice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgersController : ControllerBase
  {
    private readonly BurgersService _burgersService;
    private readonly Auth0Provider _auth;

    public BurgersController(BurgersService burgersService, Auth0Provider auth)
    {
      _burgersService = burgersService;
      _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Burger>> CreateBurger([FromBody] Burger burgerData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        burgerData.CreatorId = userInfo.Id;
        Burger burger = _burgersService.CreateBurger(burgerData);
        return Ok(burger);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}