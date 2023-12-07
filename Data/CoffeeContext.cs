using System;
using System.Collections.Generic;
using Models.Entities;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<CoffeeAddition> CoffeeAdditions { get; set; }

    public virtual DbSet<CoffeeBean> CoffeeBeans { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Cookie> Cookies { get; set; }

    public virtual DbSet<CustomCoffee> CustomCoffees { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PickupLocation> PickupLocations { get; set; }

    public virtual DbSet<PredefinedCoffee> PredefinedCoffees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=EASV-DB4;Database=CoffeeshopDB;User Id=CSe2022t_t_3;Password=CSe2022tT3#;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Addition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addition__3214EC07843D88C0");

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
            entity.HasKey(e => e.Id).HasName("PK__Brewing___3214EC07909FFACF");

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

        modelBuilder.Entity<CoffeeAddition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CoffeeAd__3214EC074BA795EB");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AdditionId).HasColumnName("additionId");
            entity.Property(e => e.CustomCoffeeId).HasColumnName("customCoffeeId");

            entity.HasOne(d => d.Addition).WithMany(p => p.CoffeeAdditions)
                .HasForeignKey(d => d.AdditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoffeeAdd__addit__5812160E");

            entity.HasOne(d => d.CustomCoffee).WithMany(p => p.CoffeeAdditions)
                .HasForeignKey(d => d.CustomCoffeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoffeeAdd__custo__571DF1D5");
        });

        modelBuilder.Entity<CoffeeBean>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coffee_b__3214EC07BD8F34E4");

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
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC0740E6F3C3");

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
                .HasConstraintName("FK__Comments__predef__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__userId__4316F928");
        });

        modelBuilder.Entity<Cookie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cookies__3214EC078D54EF89");

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
                .HasConstraintName("FK__Cookies__predefi__4CA06362");
        });

        modelBuilder.Entity<CustomCoffee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Custom_c__3214EC07B96760A0");

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
                .HasConstraintName("FK__Custom_co__beanI__36B12243");

            entity.HasOne(d => d.Brewing).WithMany(p => p.CustomCoffees)
                .HasForeignKey(d => d.BrewingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Custom_co__brewi__37A5467C");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Likes__3214EC07D2CEE6F2");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LikeTime)
                .HasColumnType("datetime")
                .HasColumnName("likeTime");
            entity.Property(e => e.PredefinedCoffeeId).HasColumnName("predefinedCoffeeId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.PredefinedCoffee).WithMany(p => p.Likes)
                .HasForeignKey(d => d.PredefinedCoffeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__predefine__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__userId__3E52440B");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0733F0AFC5");

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
                .HasConstraintName("FK__Orders__location__48CFD27E");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__userId__47DBAE45");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order_de__3214EC073C548ABA");

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
                .HasConstraintName("FK__Order_det__cooki__534D60F1");

            entity.HasOne(d => d.CustomCoffee).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CustomCoffeeId)
                .HasConstraintName("FK__Order_det__custo__52593CB8");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_det__order__5070F446");

            entity.HasOne(d => d.PredefinedCoffee).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.PredefinedCoffeeId)
                .HasConstraintName("FK__Order_det__prede__5165187F");
        });

        modelBuilder.Entity<PickupLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pickup_l__3214EC079ACD378E");

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
            entity.HasKey(e => e.Id).HasName("PK__Predefin__3214EC07112F1526");

            entity.ToTable("Predefined_coffees");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image");
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
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F6DAB402");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E616472D9354C").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5723003A834").IsUnique();

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
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Salt).HasColumnName("salt");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
