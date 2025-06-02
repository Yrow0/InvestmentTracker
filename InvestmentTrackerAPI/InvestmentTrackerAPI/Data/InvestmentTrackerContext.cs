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

    public virtual DbSet<Coin> Coins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1455;Database=InvestmentTracker;User Id=SA;Password=Admin@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Coins");

            entity.ToTable("coins");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CoinId).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
