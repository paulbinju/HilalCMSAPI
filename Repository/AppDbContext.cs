using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions con) : base(con)
        {

        }
        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ArticleExtension> ArticleExtensions { get; set; }  
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<NewsletterDetail> NewsletterDetails { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ConnStr");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
