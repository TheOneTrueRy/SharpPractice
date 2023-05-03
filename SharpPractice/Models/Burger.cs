namespace SharpPractice.Models
{
  public class Burger
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public int Buns { get; set; }
    public int Patties { get; set; }
    public int? CheeseSlices { get; set; }
    public bool Onions { get; set; }
    public bool Pickles { get; set; }
    public bool Ketchup { get; set; }
    public bool CheckedOut { get; set; }
    public string SpecialRequest { get; set; }
  }
}