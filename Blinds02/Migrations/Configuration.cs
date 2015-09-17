namespace Blinds02.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Blinds02.Models.Blinds02Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Blinds02.Models.Blinds02Context";
        }

        protected override void Seed(Blinds02.Models.Blinds02Context context)
        {

        }
    }
}
