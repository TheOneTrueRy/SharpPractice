namespace SharpPractice.Repositories
{
  public class BurgersRepository
  {
    private readonly IDbConnection _db;

    public BurgersRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Burger CreateBurger(Burger burgerData)
    {
      string sql = @"
      INSERT INTO burgers
      (creatorId, buns, patties, cheeseSlices, onions, pickles, ketchup, specialRequest)
      VALUES
      (@creatorId, @buns, @patties, @cheeseSlices, @onions, @pickles, @ketchup, @specialRequest);
      ";
      int id = _db.ExecuteScalar<int>(sql, burgerData);
      burgerData.Id = id;
      return burgerData;
    }

    internal List<Burger> GetAllBurgers()
    {
      string sql = @"
      SELECT 
      *
      FROM burgers;
      ";
      List<Burger> burgers = _db.Query<Burger>(sql).ToList();
      return burgers;
    }

    internal List<Burger> GetMyBurgers(string userId)
    {
      string sql = @"
      SELECT
      *
      FROM burgers
      WHERE creatorId = @userId;
      ";
      List<Burger> burgers = _db.Query<Burger>(sql, new { userId }).ToList();
      return burgers;
    }
  }
}