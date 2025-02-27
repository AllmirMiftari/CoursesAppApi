using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Data
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Registration>(x => x.HasKey(r => new {r.UserId, r.CourseId}));

            builder.Entity<Registration>()
            .HasOne(u => u.User)
            .WithMany(u => u.Registrations)
            .HasForeignKey(r => r.UserId);

             builder.Entity<Registration>()
            .HasOne(u => u.Course)
            .WithMany(u => u.Registrations)
            .HasForeignKey(r => r.CourseId);

            List<IdentityRole> roles = new List<IdentityRole>{

                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                }

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}