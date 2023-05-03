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

    internal List<Burger> GetMyBurgers(string userId)
    {
      List<Burger> burgers = _repo.GetMyBurgers(userId);
      return burgers;
    }
  }
}