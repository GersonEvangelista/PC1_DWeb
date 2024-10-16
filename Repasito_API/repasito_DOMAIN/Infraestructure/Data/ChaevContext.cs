using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace repasito_DOMAIN.Data;

public partial class ChaevContext : DbContext
{
    public ChaevContext()
    {
    }

    public ChaevContext(DbContextOptions<ChaevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<Sale> Sale { get; set; }

    public virtual DbSet<Suppliers> Suppliers { get; set; }

    public virtual DbSet<Supply> Supply { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-7N747763;Database=Chaev;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categories>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("pk_id_category");

            entity.ToTable("categories");

            entity.Property(e => e.IdCategory)
                .ValueGeneratedNever()
                .HasColumnName("id_category");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("categoryName");
            entity.Property(e => e.DescriptionNotes)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descriptionNotes");
        });

        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("pk_id_customer");

            entity.ToTable("customers");

            entity.Property(e => e.IdCustomer)
                .ValueGeneratedNever()
                .HasColumnName("id_customer");
            entity.Property(e => e.Department)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.District)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("district");
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.LastNames)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastNames");
            entity.Property(e => e.Names)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("province");
            entity.Property(e => e.Telf)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telf");
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("pk_id_product");

            entity.ToTable("products");

            entity.Property(e => e.IdProduct)
                .ValueGeneratedNever()
                .HasColumnName("id_product");
            entity.Property(e => e.DescriptionNotes)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descriptionNotes");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.ProductName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("productName");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("fk_id_category");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("pk_id_sale");

            entity.ToTable("sale");

            entity.Property(e => e.IdSale)
                .ValueGeneratedNever()
                .HasColumnName("id_sale");
            entity.Property(e => e.DateSale)
                .HasColumnType("datetime")
                .HasColumnName("dateSale");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Notes)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Sale)
                .HasForeignKey(d => d.IdCustomer)
                .HasConstraintName("fk_id_customer");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Sale)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("fk_id_product");
        });

        modelBuilder.Entity<Suppliers>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("pk_id_supplier");

            entity.ToTable("suppliers");

            entity.Property(e => e.IdSupplier)
                .ValueGeneratedNever()
                .HasColumnName("id_supplier");
            entity.Property(e => e.AddressLocation)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("addressLocation");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.NameCompany)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nameCompany");
            entity.Property(e => e.Telf)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telf");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.IdSupply).HasName("pk_id_supply");

            entity.ToTable("supply");

            entity.Property(e => e.IdSupply)
                .ValueGeneratedNever()
                .HasColumnName("id_supply");
            entity.Property(e => e.DateSupply)
                .HasColumnType("datetime")
                .HasColumnName("dateSupply");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Supply)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("fk1_id_product");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Supply)
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("fk_id_supplier");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
