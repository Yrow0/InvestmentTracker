using System;
using System.Collections.Generic;
using InvestmentTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentTrackerAPI.Data;

public partial class InvestmentTrackerContext : DbContext
{
    public InvestmentTrackerContext()
    {
    }

    public InvestmentTrackerContext(DbContextOptions<InvestmentTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coin> Coins { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Models.TransactionType> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1455;Database=InvestmentTracker;User Id=SA;Password=Admin@123;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_category_Id");

            entity.ToTable("category");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Coin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Coins");

            entity.ToTable("coins");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CoinId).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("transactions");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.TypeId).HasColumnName("typeId");

            entity.HasOne(d => d.Category).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Category");

            entity.HasOne(d => d.Type).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Type");
        });

        modelBuilder.Entity<Models.TransactionType>(entity =>
        {
            entity.ToTable("type");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
