using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
 public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-U9NQ17S;database=ScholarshipBlogDB; integrated security= true;"); 
            
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Writer>()
                .HasMany(p => p.Comments)
                .WithOne(t => t.Writer)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Writer>()
                .HasMany(a => a.Blogs)
                .WithOne(c => c.Writer)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Blog>()
            .HasMany(m => m.Comments)
            .WithOne(k => k.Blog)
            .OnDelete(DeleteBehavior.NoAction);


        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Comment> Comments  { get; set; }
        public DbSet<Contact> Contacts   { get; set; }
        public DbSet<Writer> Writers   { get; set; }
        public DbSet<NewsLater> NewsLaters { get; set; }
    }
}
