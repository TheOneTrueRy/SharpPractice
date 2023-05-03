namespace SharpPractice.Models
{
  public class Fries
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public string Type { get; set; }
    public string Size { get; set; }
    public bool CheckedOut { get; set; }
  }
}