using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionMusicaAPI.Models;

public partial class EvaluacionMusicaDbContext : DbContext
{
    public EvaluacionMusicaDbContext()
    {
    }

    public EvaluacionMusicaDbContext(DbContextOptions<EvaluacionMusicaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Albumes__3214EC072A05F030");

            entity.ToTable("Album");

            entity.Property(e => e.Artista)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
