using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Engineer
{
  public int EngineerId { get; set; }
  [Required(ErrorMessage="Please Enter a Name")]
  public string Name { get; set; }
  public List<EngMachine> JoinEntities { get; }
}