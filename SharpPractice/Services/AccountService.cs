namespace SharpPractice.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;
  private readonly BurgersService _burgersService;
  private readonly DrinksService _drinksService;
  private readonly FriesService _friesService;

  public AccountService(AccountsRepository repo, BurgersService burgersService, DrinksService drinksService, FriesService friesService)
  {
    _repo = repo;
    _burgersService = burgersService;
    _drinksService = drinksService;
    _friesService = friesService;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    return _repo.Edit(original);
  }

  internal string CheckOut(string userId)
  {
    bool result1 = _burgersService.CheckOut(userId);
    bool result2 = _drinksService.CheckOut(userId);
    bool result3 = _friesService.CheckOut(userId);
    if (!result1 && !result2 && !result3)
    {
      throw new Exception("Something went wrong trying to check out your order, do you not have anything in your order?");
    }
    return "Order successfully checked out!";
  }
}
