namespace Project.Data.Migrations
{
  using System.Data.Entity.Migrations;
  using Project.Data.Models;

  internal sealed class Configuration : DbMigrationsConfiguration<EFContext>
  {
    public Configuration() { AutomaticMigrationsEnabled = false; }

    protected override void Seed(EFContext context) { }
  }
}