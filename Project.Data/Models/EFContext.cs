using System.Data.Entity;

namespace Project.Data.Models
{
  public class EFContext : DbContext
  {
    public EFContext() : base("DbConnection") { }

    public DbSet<User> Users { get; set; }
  }
}