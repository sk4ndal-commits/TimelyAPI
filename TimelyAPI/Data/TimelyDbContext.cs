// Data/AppDbContext.cs

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimelyAPI.Models;

namespace TimelyAPI.Data;

public class TimelyDbContext(DbContextOptions<TimelyDbContext> options)
    : IdentityDbContext<User>(options)
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<TimeLog> TimeLogs { get; set; }
    public DbSet<Goal> Goals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Timelog
        modelBuilder.Entity<TimeLog>()
            .HasIndex(t => new { t.ActivityId, t.StartTime, t.EndTime });

        // Activity
        modelBuilder.Entity<Activity>()
            .HasIndex(a => a.Description);

        // User -> Goals
        modelBuilder.Entity<Goal>()
            .HasOne(g => g.User)
            .WithMany(g => g.Goals)
            .HasForeignKey(g => g.UserId);

        // Goal -> Activity
        modelBuilder.Entity<Activity>()
            .HasOne(a => a.Goal)
            .WithMany(a => a.Activities)
            .HasForeignKey(a => a.GoalId);

        // Activity -> Timelog
        modelBuilder.Entity<TimeLog>()
            .HasOne(t => t.Activity)
            .WithMany(a => a.TimeLogs)
            .HasForeignKey(t => t.ActivityId);

        // User -> Notification
        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(n => n.Notifications)
            .HasForeignKey(n => n.UserId);

        // User -> Report
        modelBuilder.Entity<Report>()
            .HasOne(r => r.User)
            .WithMany(r => r.Reports)
            .HasForeignKey(r => r.UserId);


        InitializeDummyData(modelBuilder);
    }

    private static void InitializeDummyData(ModelBuilder modelBuilder)
    {
        var userId = Guid.NewGuid().ToString();
        const string userPwd = "123456";
        var goalId = Guid.NewGuid().ToString();
        var activityId = Guid.NewGuid().ToString();
        var timeLogId = Guid.NewGuid().ToString();

        var user = new User
        {
            Id = userId,
            Email = "user@user.com",
            PasswordHash = userPwd,
        };


        var goal = new Goal
        {
            Id = goalId,
            Description = "Get Karate Black Belt",
            Reason = "I want to prove to myself that i can do that",
            TargetHours = TimeSpan.FromHours(1000),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UserId = userId,
        };

        var activity = new Activity
        {
            Id = activityId,
            GoalId = goalId,
            Description = "First Activity",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        var timeLog = new TimeLog
        {
            Id = timeLogId,
            ActivityId = activityId,
            StartTime = DateTime.UtcNow,
            EndTime = DateTime.UtcNow.AddHours(1),
            CreatedAt = DateTime.UtcNow,
        };

        modelBuilder.Entity<User>().HasData(user);
        modelBuilder.Entity<Goal>().HasData(goal);
        modelBuilder.Entity<Activity>().HasData(activity);
        modelBuilder.Entity<TimeLog>().HasData(timeLog);

    }
}