using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ООО_Посуда1.Models
{
    public partial class Posuda_db : DbContext
    {
        public static Posuda_db DbContext { get; private set; } = new Posuda_db();

        public Posuda_db()
        {
        }

        public Posuda_db(DbContextOptions<Posuda_db> options)
            : base(options)
        {
        }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<PickupPoint> PickupPoints { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("user=root;password=a678e321r;database=db_posuda;server=localhost", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Idmanufacturers)
                    .HasName("PRIMARY");

                entity.ToTable("manufacturers");

                entity.Property(e => e.Idmanufacturers)
                    .ValueGeneratedNever()
                    .HasColumnName("idmanufacturers");

                entity.Property(e => e.ManufacturerName)
                    .HasMaxLength(75)
                    .HasColumnName("manufacturer_name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Idorder)
                    .HasName("PRIMARY");

                entity.ToTable("order");

                entity.HasIndex(e => e.PickupPointId, "FK_Order_PickupPoint_idx");

                entity.HasIndex(e => e.OrderStatusId, "FK_Order_Status_idx");

                entity.HasIndex(e => e.UserId, "FK_Order_User_idx");

                entity.Property(e => e.Idorder).HasColumnName("idorder");

                entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(45)
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

                entity.Property(e => e.PickupCode).HasColumnName("pickup_code");

                entity.Property(e => e.PickupPointId).HasColumnName("pickup_point_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Status");

                entity.HasOne(d => d.PickupPoint)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PickupPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_PickupPoint");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.IdorderProduct, e.OrderId, e.ProductId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("order_product");

                entity.HasIndex(e => e.OrderId, "FK_OrderProduct_Order_idx");

                entity.HasIndex(e => e.ProductId, "FK_OrderProduct_Product_idx");

                entity.Property(e => e.IdorderProduct)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idorder_product");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_Product");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.IdorderStatus)
                    .HasName("PRIMARY");

                entity.ToTable("order_status");

                entity.Property(e => e.IdorderStatus).HasColumnName("idorder_status");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(75)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<PickupPoint>(entity =>
            {
                entity.HasKey(e => e.Idpickuppoint)
                    .HasName("PRIMARY");

                entity.ToTable("pickup_point");

                entity.Property(e => e.Idpickuppoint)
                    .ValueGeneratedNever()
                    .HasColumnName("idpickuppoint");

                entity.Property(e => e.City)
                    .HasMaxLength(75)
                    .HasColumnName("city");

                entity.Property(e => e.Home)
                    .HasMaxLength(75)
                    .HasColumnName("home");

                entity.Property(e => e.Street)
                    .HasMaxLength(75)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.ManufacturerId, "FK_Product_Manufacturer_idx");

                entity.Property(e => e.Idproduct)
                    .ValueGeneratedNever()
                    .HasColumnName("idproduct");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Cost)
                    .HasMaxLength(75)
                    .HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(75)
                    .HasColumnName("name");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .HasColumnName("photo");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Manufacturer");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.RoleId, "FK_User_Role_idx");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Login)
                    .HasMaxLength(75)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .HasMaxLength(75)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(75)
                    .HasColumnName("password");

                entity.Property(e => e.Patronomyc)
                    .HasMaxLength(75)
                    .HasColumnName("patronomyc");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Surname)
                    .HasMaxLength(75)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.IduserRole)
                    .HasName("PRIMARY");

                entity.ToTable("user_role");

                entity.Property(e => e.IduserRole).HasColumnName("iduser_role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(45)
                    .HasColumnName("roleName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
