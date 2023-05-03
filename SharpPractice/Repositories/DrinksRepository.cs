namespace SharpPractice.Repositories
{
  public class DrinksRepository
  {
    private readonly IDbConnection _db;

    public DrinksRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Drink CreateDrink(Drink drinkData)
    {
      string sql = @"
      INSERT INTO drinks
      (creatorId, flavor, size)
      VALUES
      (@creatorId, @flavor, @size);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, drinkData);
      drinkData.Id = id;
      return drinkData;
    }

    internal List<Drink> GetMyDrinks(string userId)
    {
      throw new NotImplementedException();
    }
  }
}