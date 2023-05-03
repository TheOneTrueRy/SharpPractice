namespace SharpPractice.Models
{
  public class Drink
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public string Flavor { get; set; }
    public string Size { get; set; }
    public bool CheckedOut { get; set; }
  }
}