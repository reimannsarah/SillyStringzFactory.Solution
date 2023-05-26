using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class SSFactoryContext : DbContext
  {
    public DbSet<Machine> Machines { get; set; }
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<EngMachine> EngMachines { get; set; }
    public SSFactoryContext(DbContextOptions options) : base(options) { }
  }
}