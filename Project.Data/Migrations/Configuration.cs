namespace Project.Data.Migrations
{
  using System.Data.Entity.Migrations;

  internal sealed class Configuration : DbMigrationsConfiguration<Models.EFContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(Models.EFContext context)
    {
    }
  }
}