using System.Data.Entity;
using WebApiyleApi.Migrations;
using WebApiyleApi.Models;

namespace WebApiyleApi.Classes
{
    public class MyContext : DbContext
    {
        public MyContext() : base("webapicontext")
        {
            Database.SetInitializer<MyContext>(new MigrateDatabaseToLatestVersion<MyContext, Configuration>());
        }
        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<UserBookRelation> UserBookRelation { get; set; }


        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<User>().ToTable("User").HasKey(p => p.Id)
                .Property(p => p.Name).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<UserBookRelation>().ToTable("UserBookRelation").HasKey(p => p.Id);

            modelBuilder.Entity<Book>().ToTable("Book").HasKey(p => p.Id)
                .Property(p => p.Name).HasMaxLength(200).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
