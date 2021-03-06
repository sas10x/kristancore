using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<UserFollowing> Followings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Zmpq25b> Zmpq25b { get; set; }
        public DbSet<Move> Movements { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Mb51> Mb51 { get; set; }
        public DbSet<Zva05n> Zva05n { get; set; }
        public DbSet<ActivityMb51> ActivitiesMb51 { get; set; }
        public DbSet<ActivityZva05n> ActivitiesZva05n { get; set; }
        public DbSet<ReportSummary> Reports { get; set; }
        public DbSet<Report> DateReports { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Bubble> Bubbles { get; set; }
        public DbSet<ReportBar> ReportBars { get; set; }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Value>()
                .HasData(
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"}
                );
            builder.Entity<UserActivity>(x => x.HasKey(ua => new { ua.AppUserId, ua.ActivityId }));
            builder
            .Entity<ReportSummary>(
                builder => {
                    builder.HasNoKey();
                }
            );
             builder
            .Entity<Report>(
                builder => {
                    builder.HasNoKey();
                }
            );
            builder
            .Entity<Bubble>(
                builder => {
                    builder.HasNoKey();
                }
            
            );
            builder
            .Entity<ReportBar>(
                builder => {
                    builder.HasNoKey();
                }
            
            );
            builder.Entity<UserActivity>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.UserActivities)
                .HasForeignKey(u => u.AppUserId);

            builder.Entity<UserActivity>()
                .HasOne(a => a.Activity)
                .WithMany(u => u.UserActivities)
                .HasForeignKey(a => a.ActivityId);
                
            builder.Entity<UserFollowing>(b =>
            {
                b.HasKey(k => new { k.ObserverId, k.TargetId });

                b.HasOne(o => o.Observer)
                    .WithMany(f => f.Followings)
                    .HasForeignKey(o => o.ObserverId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                b.HasOne(o => o.Target)
                    .WithMany(f => f.Followers)
                    .HasForeignKey(o => o.TargetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }  
    }
}
