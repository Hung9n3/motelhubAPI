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
    public virtual DbSet<Contract> Contracts { get; set; } = null!;
    public virtual DbSet<Bill> Bills { get; set; } = null!;
    public virtual DbSet<Photo> Photos { get; set; } = null!;
    public virtual DbSet<Appointment> Appointments { get; set; } = null!;
    public virtual DbSet<WorkOrder> WorkOrders { get; set; } = null!;

    public override int SaveChanges()
    {
        var changedEntities = this.ChangeTracker.Entries()
                                                .Where(x => x.State == EntityState.Added
                                                         || x.State == EntityState.Modified);
        foreach (var entity in changedEntities)
        {
            var dateTimeOffset = DateTime.UtcNow;

            if (entity.State == EntityState.Added)
            {
                entity.Property(nameof(BaseEntity.CreatedAt)).CurrentValue = dateTimeOffset;
            }
            entity.Property(nameof(BaseEntity.ModifiedAt)).CurrentValue = dateTimeOffset;
        }
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Role>(role =>
        {
            role.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        });
        builder.Entity<User>(user =>
        {
            user.Property<int?>("RoleId").HasDefaultValue(2);

            user.Property<string>("Email")
                .IsRequired(false)
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            user.HasMany(x => x.CustomerRooms).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.SetNull);
            user.HasMany(x => x.Photos).WithOne(x => x.User).HasForeignKey(x => x.UserId).IsRequired(false).OnDelete(DeleteBehavior.SetNull); 
            user.HasMany(x => x.Appointments).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);   
            user.HasMany(x => x.Areas).WithOne(x => x.Host).HasForeignKey(x => x.HostId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            user.HasMany(x => x.CustomerContracts).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            user.HasMany(x => x.WorkOrders).WithOne(x => x.Creator).HasForeignKey(x => x.CreatorId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<Area>(area =>
        {
            area.HasMany(x => x.Rooms).WithOne(x => x.Area).HasForeignKey(x => x.AreaId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<Room>(room =>
        {
            room.HasMany(x => x.Photos).WithOne(x => x.Room).HasForeignKey(x => x.RoomId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            room.HasMany(x => x.Appointments).WithOne(x => x.Room).HasForeignKey(x => x.RoomId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            room.HasMany(x => x.Contracts).WithOne(x => x.Room).HasForeignKey(x => x.RoomId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            room.HasMany(x => x.WorkOrders).WithOne(x => x.Room).HasForeignKey(x => x.RoomId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);

        });

        builder.Entity<Contract>(contract =>
        {
            contract.HasMany(x => x.Bills).WithOne(x => x.Contract).HasForeignKey(x => x.ContractId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        });
    }
}