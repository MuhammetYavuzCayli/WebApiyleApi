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
                Name = "�kinci Ki�i",
                Location = "T�rkiye"
            });
            user.Add(new User()
            {
                Name = "���nc� Ki�i",
                Location = "T�rkiye"
            });
            user.Add(new User()
            {
                Name = "D�rd�nc� Ki�i",
                Location = "T�rkiye"
            });
            context.User.AddRange(user);
            context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
