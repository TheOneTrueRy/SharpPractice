namespace SharpPractice.Repositories
{
  public class FriesRepository
  {
    private readonly IDbConnection _db;

    public FriesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Fries CreateFries(Fries friesData)
    {
      string sql = @"
      INSERT INTO fries
      (creatorId, type, size)
      VALUES
      (@creatorId, @type, @size);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, friesData);
      friesData.Id = id;
      return friesData;
    }

    internal List<Fries> GetMyFries(string userId)
    {
      string sql = @"
      SELECT
      *
      FROM fries
      WHERE creatorId = @userId;
      ";
      List<Fries> fries = _db.Query<Fries>(sql, new { userId }).ToList();
      return fries;
    }
  }
}