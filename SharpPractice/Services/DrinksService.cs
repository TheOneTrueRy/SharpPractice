namespace SharpPractice.Services
{
  public class DrinksService
  {
    private readonly DrinksRepository _repo;

    public DrinksService(DrinksRepository repo)
    {
      _repo = repo;
    }

    internal Drink CreateDrink(Drink drinkData)
    {
      Drink drink = _repo.CreateDrink(drinkData);
      return drink;
    }

    internal List<Drink> GetMyDrinks(string userId)
    {
      List<Drink> drinks = _repo.GetMyDrinks(userId);
      return drinks;
    }

    internal List<Drink> GetMyOrderedDrinks(string userId)
    {
      List<Drink> drinks = _repo.GetMyOrderedDrinks(userId);
      return drinks;
    }
  }
}