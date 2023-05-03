namespace SharpPractice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DrinksController : ControllerBase
  {
    private readonly DrinksService _drinksService;
    private readonly Auth0Provider _auth;

    public DrinksController(DrinksService drinksService, Auth0Provider auth)
    {
      _drinksService = drinksService;
      _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Drink>> CreateDrink([FromBody] Drink drinkData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        drinkData.CreatorId = userInfo.Id;
        Drink drink = _drinksService.CreateDrink(drinkData);
        return Ok(drink);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}