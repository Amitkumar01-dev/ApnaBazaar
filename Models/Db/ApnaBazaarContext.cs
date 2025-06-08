using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApnaBazaar.Models.Db;

public partial class ApnaBazaarContext : DbContext
{
    public ApnaBazaarContext()
    {
    }

    public ApnaBazaarContext(DbContextOptions<ApnaBazaarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductGallery> ProductGalleries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=ApnaBazaar;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Banner__3214EC27F6A2476D");

            entity.ToTable("Banner");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImageName).HasMaxLength(100);
            entity.Property(e => e.Link).HasMaxLength(200);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.SubTitle).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Menus__3214EC27F8DB7908");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Link).HasMaxLength(300);
            entity.Property(e => e.MenuTitle).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83FDB507AEC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Discount).HasColumnType("money");
            entity.Property(e => e.FullDes).HasMaxLength(4000);
            entity.Property(e => e.ImageName).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Tags).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.VideoUrl).HasMaxLength(300);
        });

        modelBuilder.Entity<ProductGallery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductG__3213E83F2C013859");

            entity.ToTable("ProductGallery");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageName).HasMaxLength(50);
            entity.Property(e => e.ProducrId).HasColumnName("ProducrID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
