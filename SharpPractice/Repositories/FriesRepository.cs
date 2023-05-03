namespace SharpPractice.Repositories
{
  public class FriesRepository
  {
    private readonly IDbConnection _db;

    public FriesRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}