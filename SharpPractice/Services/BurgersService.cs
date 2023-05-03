namespace SharpPractice.Services
{
  public class BurgersService
  {
    private readonly BurgersRepository _repo;

    public BurgersService(BurgersRepository repo)
    {
      _repo = repo;
    }

    internal Burger CreateBurger(Burger burgerData)
    {
      Burger burger = _repo.CreateBurger(burgerData);
      return burger;
    }

    internal List<Burger> GetAllBurgers()
    {
      List<Burger> burgers = _repo.GetAllBurgers();
      return burgers;
    }

    internal Burger GetOneBurger(int burgerId)
    {
      Burger burger = _repo.GetOneBurger(burgerId);
      return burger;
    }

    internal List<Burger> GetMyBurgers(string userId)
    {
      List<Burger> burgers = _repo.GetMyBurgers(userId);
      return burgers;
    }

    internal List<Burger> GetMyOrderedBurgers(string userId)
    {
      List<Burger> burgers = _repo.GetMyOrderedBurgers(userId);
      return burgers;
    }

    internal string DeleteBurger(int burgerId, string userId)
    {
      Burger burger = GetOneBurger(burgerId);
      if (burger.CreatorId != userId)
      {
        throw new Exception("You didn't create that burger!");
      }
      bool result = _repo.DeleteBurger(burgerId);
      if (!result)
      {
        throw new Exception("Something went wrong trying to delete that burger.");
      }
      return $"Successfully deleted the burger at with the Id of {burger.Id}";
    }
  }
}