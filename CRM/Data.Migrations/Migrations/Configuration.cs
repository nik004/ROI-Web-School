namespace Crm.Data.Migrations.Migrations
{
	using System.Data.Entity.Migrations;
	using Entities;

	internal sealed class Configuration : DbMigrationsConfiguration<Crm.Data.CrmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrmContext context)
        {
			context.Users.AddOrUpdate(
				user => user.Login,
				new User { Login = "Administrator" }
			);
        }
    }
}