namespace WebApiyleApi.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using WebApiyleApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Classes.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebApiyleApi.Classes.MyContext";
        }

        protected override void Seed(Classes.MyContext context)
        {
            IList<User> user = new List<User>();
            //  This method will be called after migrating to the latest version.
            user.Add(new User()
            {
                Name = "Ýkinci Kiþi",
                Location = "Türkiye"
            });
            user.Add(new User()
            {
                Name = "Üçüncü Kiþi",
                Location = "Türkiye"
            });
            user.Add(new User()
            {
                Name = "Dördüncü Kiþi",
                Location = "Türkiye"
            });
            context.User.AddRange(user);
            context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
