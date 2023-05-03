namespace SharpPractice.Services
{
  public class FriesService
  {
    private readonly FriesRepository _repo;

    public FriesService(FriesRepository repo)
    {
      _repo = repo;
    }

    internal Fries CreateFries(Fries friesData)
    {
      Fries fries = _repo.CreateFries(friesData);
      return fries;
    }

    internal List<Fries> GetMyFries(string userId)
    {
      List<Fries> fries = _repo.GetMyFries(userId);
      return fries;
    }
  }
}