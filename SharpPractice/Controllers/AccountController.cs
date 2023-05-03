namespace SharpPractice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly BurgersService _burgersService;
  private readonly DrinksService _drinksService;
  private readonly FriesService _friesService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, BurgersService burgersService, DrinksService drinksService, FriesService friesService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _burgersService = burgersService;
    _drinksService = drinksService;
    _friesService = friesService;
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

  [HttpGet("drinks")]
  [Authorize]
  public async Task<ActionResult<List<Drink>>> GetMyDrinks()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Drink> drinks = _drinksService.GetMyDrinks(userInfo.Id);
      return Ok(drinks);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("fries")]
  [Authorize]
  public async Task<ActionResult<List<Fries>>> GetMyFries()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Fries> fries = _friesService.GetMyFries(userInfo.Id);
      return Ok(fries);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
