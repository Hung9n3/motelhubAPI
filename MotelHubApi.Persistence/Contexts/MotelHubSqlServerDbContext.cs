using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi.Persistence;

public class MotelHubSqlServerDbContext : IdentityDbContext<User, Role, int>
{
    private readonly IDomainEventDispatcher _dispatcher;

    public MotelHubSqlServerDbContext(DbContextOptions<MotelHubSqlServerDbContext> options,
      IDomainEventDispatcher dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public override DbSet<User> Users { get; set; } = null!;
    public override DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<Area> Areas { get; set; } = null!;
    public virtual DbSet<Room> Rooms { get; set; } = null!;
    public virtual DbSet<MeterReading> MeterReadings { get; set; } = null!;
    public virtual DbSet<MeterReadingPrice> MeterReadingPrices { get; set; } = null!;
    public virtual DbSet<Contract> Contracts { get; set; } = null!;
    public virtual DbSet<Bill> Bills { get; set; } = null!;
    public virtual DbSet<Photo> Photos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(user =>
        {
            user.Property<int>("RoleId").HasDefaultValue(1);
            user.HasOne(x => x.Role).WithMany("User").HasForeignKey(x => x.RoleId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            user.HasMany(x => x.Photos).WithOne(x => x.User).HasForeignKey(x => x.UserId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);   
            user.HasMany(x => x.Areas).WithOne(x => x.Host).HasForeignKey(x => x.HostId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        });
    }
}