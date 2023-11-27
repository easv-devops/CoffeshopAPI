using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Models.Entities;

namespace Data;

public partial class CoffeeContext : DbContext
{
    public CoffeeContext()
    {
    }

    public CoffeeContext(DbContextOptions<CoffeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addition> Additions { get; set; }

    public virtual DbSet<BrewingMethod> BrewingMethods { get; set; }

    public virtual DbSet<CoffeeBean> CoffeeBeans { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Cookie> Cookies { get; set; }

    public virtual DbSet<CustomCoffee> CustomCoffees { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PickupLocation> PickupLocations { get; set; }

    public virtual DbSet<PredefinedCoffee> PredefinedCoffees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CoffeeshopDB;User Id=sa;Password=12344321;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Addition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addition__3214EC078AF931A3");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<BrewingMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brewing___3214EC0753A8E88B");

            entity.ToTable("Brewing_methods");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<CoffeeBean>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coffee_b__3214EC077DFE8327");

            entity.ToTable("Coffee_beans");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07E1C848FB");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CommentTime)
                .HasColumnType("datetime")
                .HasColumnName("commentTime");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.PredefinedCoffeeId).HasColumnName("predefinedCoffeeId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.PredefinedCoffee).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PredefinedCoffeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__predef__693CA210");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__userId__68487DD7");
        });

        modelBuilder.Entity<Cookie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cookies__3214EC07FB0FC4F6");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PredefinedCoffeeId).HasColumnName("predefinedCoffeeId");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.HasOne(d => d.PredefinedCoffee).WithMany(p => p.Cookies)
                .HasForeignKey(d => d.PredefinedCoffeeId)
                .HasConstraintName("FK__Cookies__predefi__71D1E811");
        });

        modelBuilder.Entity<CustomCoffee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Custom_c__3214EC07865FB1CC");

            entity.ToTable("Custom_coffees");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BeanId).HasColumnName("beanId");
            entity.Property(e => e.BrewingId).HasColumnName("brewingId");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Bean).WithMany(p => p.CustomCoffees)
                .HasForeignKey(d => d.BeanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Custom_co__beanI__5BE2A6F2");

            entity.HasOne(d => d.Brewing).WithMany(p => p.CustomCoffees)
                .HasForeignKey(d => d.BrewingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Custom_co__brewi__5CD6CB2B");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC07567C5829");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AdditionId).HasColumnName("additionId");
            entity.Property(e => e.CustomCoffeeId).HasColumnName("customCoffeeId");

            entity.HasOne(d => d.Addition).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.AdditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__addit__7D439ABD");

            entity.HasOne(d => d.CustomCoffee).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.CustomCoffeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__custo__7C4F7684");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Likes__3214EC071C73E7A9");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LikeTime)
                .HasColumnType("datetime")
                .HasColumnName("likeTime");
            entity.Property(e => e.PredefinedCoffeeId).HasColumnName("predefinedCoffeeId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.PredefinedCoffee).WithMany(p => p.Likes)
                .HasForeignKey(d => d.PredefinedCoffeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__predefine__6477ECF3");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__userId__6383C8BA");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0725A16FD7");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LocationId).HasColumnName("locationId");
            entity.Property(e => e.OrderTime)
                .HasColumnType("datetime")
                .HasColumnName("orderTime");
            entity.Property(e => e.PickupTime)
                .HasColumnType("datetime")
                .HasColumnName("pickupTime");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("totalPrice");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Location).WithMany(p => p.Orders)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__location__6E01572D");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__userId__6D0D32F4");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order_de__3214EC0768D2A478");

            entity.ToTable("Order_details");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CookieId).HasColumnName("cookieId");
            entity.Property(e => e.CustomCoffeeId).HasColumnName("customCoffeeId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.PredefinedCoffeeId).HasColumnName("predefinedCoffeeId");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Cookie).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CookieId)
                .HasConstraintName("FK__Order_det__cooki__787EE5A0");

            entity.HasOne(d => d.CustomCoffee).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CustomCoffeeId)
                .HasConstraintName("FK__Order_det__custo__778AC167");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_det__order__75A278F5");

            entity.HasOne(d => d.PredefinedCoffee).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.PredefinedCoffeeId)
                .HasConstraintName("FK__Order_det__prede__76969D2E");
        });

        modelBuilder.Entity<PickupLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pickup_l__3214EC0720E6FDBC");

            entity.ToTable("Pickup_locations");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.ShopName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("shopName");
        });

        modelBuilder.Entity<PredefinedCoffee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Predefin__3214EC0734C7AEE4");

            entity.ToTable("Predefined_coffees");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07DEDEE4A0");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61645FBED559").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5726B993205").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}