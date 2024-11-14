using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Currency.Model.Dtos.DataModel;

public partial class CurrencyContext : DbContext
{
    public CurrencyContext()
    {
    }

    public CurrencyContext(DbContextOptions<CurrencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Currency> Currencies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("Server=.\\;Database=Currency; Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currency__3214EC07C104DA78");

            entity.ToTable("Currency");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyLang)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyRate).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
