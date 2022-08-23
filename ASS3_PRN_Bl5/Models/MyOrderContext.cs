using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ASS3_PRN_Bl5.Models
{
    public partial class MyOrderContext : DbContext
    {
        public MyOrderContext()
        {
        }

        public MyOrderContext(DbContextOptions<MyOrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblKhachHang> TblKhachHangs { get; set; }
        public virtual DbSet<TblMatHang> TblMatHangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblKhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("tblKhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaKH");

                entity.Property(e => e.Diachi).HasMaxLength(50);

                entity.Property(e => e.Gt).HasColumnName("GT");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<TblMatHang>(entity =>
            {
                entity.HasKey(e => e.MaHang);

                entity.ToTable("tblMatHang");

                entity.Property(e => e.MaHang)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dvt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DVT");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Tenhang)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
