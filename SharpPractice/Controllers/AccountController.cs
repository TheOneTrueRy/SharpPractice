namespace SharpPractice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly BurgersService _burgersService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, BurgersService burgersService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _burgersService = burgersService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("burgers")]
  [Authorize]
  public async Task<ActionResult<List<Burger>>> GetMyBurgers()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Burger> burgers = _burgersService.GetMyBurgers(userInfo.Id);
      return Ok(burgers);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
