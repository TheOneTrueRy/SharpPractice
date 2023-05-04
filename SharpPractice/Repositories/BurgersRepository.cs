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
      SELECT LAST_INSERT_ID();
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

    internal List<Burger> GetMyOrderedBurgers(string userId)
    {
      string sql = @"
      SELECT
      *
      FROM burgers
      WHERE creatorId = @userId AND checkedOut = false;
      ";
      List<Burger> burgers = _db.Query<Burger>(sql, new { userId }).ToList();
      return burgers;
    }

    internal Burger GetOneBurger(int burgerId)
    {
      string sql = @"
      SELECT
      *
      FROM burgers
      WHERE id = @burgerId;
      ";
      Burger burger = _db.Query<Burger>(sql, new { burgerId }).FirstOrDefault();
      return burger;
    }

    internal bool DeleteBurger(int burgerId)
    {
      string sql = @"
      DELETE
      FROM burgers
      WHERE id = @burgerId;
      ";
      int rows = _db.Execute(sql, new { burgerId });
      return rows == 1;
    }

    internal bool CheckOut(string userId)
    {
      string sql = @"
      UPDATE burgers SET
      checkedOut = true
      WHERE creatorId = @userId;
      ";
      int rows = _db.Execute(sql, new { userId });
      return rows > 0;
    }
  }
}