using System;
using System.Reflection.Emit;
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
            user.HasMany(x => x.OwnRooms).WithOne(x => x.Owner).HasForeignKey(x => x.OwnerId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            user.HasMany(x => x.LivingRooms).WithMany(x => x.Members).UsingEntity<UserRoom>();
        });

        builder.Entity<UserRoom>()
        .HasKey(ur => new { ur.MemberId, ur.RoomId });

        builder.Entity<UserRoom>()
            .HasOne(ur => ur.Member)
            .WithMany(u => u.UserRooms)
            .HasForeignKey(ur => ur.MemberId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserRoom>()
            .HasOne(ur => ur.Room)
            .WithMany(r => r.UserRooms)
            .HasForeignKey(ur => ur.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Area>(area =>
        {
            area.HasMany(x => x.Rooms).WithOne(x => x.Area).HasForeignKey(x => x.AreaId).OnDelete(DeleteBehavior.Cascade);
            area.HasMany(x => x.Photos).WithOne(x => x.Area).HasForeignKey(x => x.AreaId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Room>(room =>
        {
            room.HasMany(x => x.Photos).WithOne(x => x.Room).HasForeignKey(x => x.RoomId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
            room.HasMany(x => x.MeterReadings).WithOne(x => x.Room).HasForeignKey(x => x.RoomId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
            room.HasMany(x => x.Contracts).WithOne(x => x.Room).HasForeignKey(x => x.RoomId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);

        });

        builder.Entity<MeterReadingPrice>(price =>
        {
            price.HasIndex(x => new { x.Type, x.Price }).IsUnique();
        });

        builder.Entity<MeterReading>(meterReading =>
        {
            meterReading.HasMany(x => x.Photos).WithOne(x => x.MeterReading).HasForeignKey(x => x.MeterReadingId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);

        });

        builder.Entity<Contract>(contract =>
        {
            contract.HasMany(x => x.Bills).WithOne(x => x.Contract).OnDelete(DeleteBehavior.SetNull);
        });
    }
}