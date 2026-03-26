using ECoffee.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Infrastructure.Configurations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost,9999;Database=ECoffeeDb;User Id=sa;Password=SqlServer@2024;TrustServerCertificate=True"
                );
            }
        }


        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<RoleEntity> Roles => Set<RoleEntity>();
        public DbSet<UserRoleEntity> UserRoles => Set<UserRoleEntity>();

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<MenuEntity> Menus => Set<MenuEntity>();
        public DbSet<MenuPriceEntity> MenuPrices => Set<MenuPriceEntity>();

        public DbSet<InventoryEntity> Inventories => Set<InventoryEntity>();

        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();

        public DbSet<PromotionEntity> Promotions => Set<PromotionEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureRelationships(modelBuilder);
            ConfigureKeys(modelBuilder);
            ConfigureHiLo(modelBuilder);
        }

        private static void ConfigureRelationships(ModelBuilder builder)
        {
            foreach (var fk in builder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<UserRoleEntity>()
                .HasKey(x => new { x.UserId, x.RoleId });
        }

        private static void ConfigureKeys(ModelBuilder builder)
        {
            builder.Entity<CategoryEntity>()
                .HasMany(c => c.Menus)
                .WithOne(m => m.Category)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MenuEntity>()
                .HasOne(m => m.Inventory)
                .WithOne(i => i.Menu)
                .HasForeignKey<InventoryEntity>(i => i.MenuId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MenuPriceEntity>()
                .HasOne(mp => mp.Menu)
                .WithMany(m => m.Prices)
                .HasForeignKey(mp => mp.MenuId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private static void ConfigureHiLo(ModelBuilder builder)
        {
            builder.HasSequence<long>("global_seq")
                   .StartsAt(1)
                   .IncrementsBy(10);

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entity.ClrType))
                {
                    builder.Entity(entity.ClrType)
                           .Property(nameof(BaseEntity.Id))
                           .UseHiLo("global_seq");
                }
            }
        }
    }
}
