namespace SharpPractice.Services
{
  public class FriesService
  {
    private readonly FriesRepository _repo;

    public FriesService(FriesRepository repo)
    {
      _repo = repo;
    }

    internal List<Fries> GetMyFries(string id)
    {
      throw new NotImplementedException();
    }
  }
}