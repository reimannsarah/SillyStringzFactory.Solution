namespace Factory.Models;

public class Engineer
{
  public int EngineerId { get; set; }
  public string Name { get; set; }
  public List<EngMachine> JoinEntities { get; }
}