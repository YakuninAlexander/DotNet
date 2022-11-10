using Microsoft.EntityFrameworkCore;
using create_test.Entities.Models;

namespace create_test.Entities;
public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Questions> Questions { get; set; }
    public DbSet<Statistic> Statistics { get; set; }
    public DbSet<Test> Tests { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        #endregion

        #region Statistic

        builder.Entity<Statistic>().ToTable("statistic");
        builder.Entity<Statistic>().HasKey(x => x.Id);
        builder.Entity<Statistic>().HasOne(x => x.User)
                                      .WithMany(x => x.Statistics)
                                      .HasForeignKey(x => x.UserId)
                                      .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Statistic>().HasOne(x => x.Test)
                                      .WithMany(x => x.Statistics)
                                      .HasForeignKey(x => x.TestId)
                                      .OnDelete(DeleteBehavior.Cascade);


        #endregion

        #region Question

        builder.Entity<Questions>().ToTable("question");
        builder.Entity<Questions>().HasKey(x => x.Id);
        builder.Entity<Questions>().HasOne(x => x.Test)
                                    .WithMany(x => x.Questions)
                                    .HasForeignKey(x => x.TestId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Test

        builder.Entity<Test>().ToTable("test");
        builder.Entity<Test>().HasKey(x => x.Id);
        builder.Entity<Test>().HasOne(x => x.User)
                                    .WithMany(x => x.Tests)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}