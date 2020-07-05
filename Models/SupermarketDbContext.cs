using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Supermarket.Models
{
    public partial class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext()
        {
        }

        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Good> Good { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberGoodMapping> MemberGoodMapping { get; set; }
        public virtual DbSet<MemberLevelMapping> MemberLevelMapping { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=mysql98@;database=supermarket_db", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("good");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("level");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DiscountRate).HasColumnName("discount_rate");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Credit).HasColumnName("credit");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<MemberGoodMapping>(entity =>
            {
                entity.ToTable("member_good_mapping");

                entity.HasIndex(e => e.GoodId)
                    .HasName("FK_Reference_2");

                entity.HasIndex(e => e.MemberId)
                    .HasName("FK_Reference_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.GoodId).HasColumnName("good_id");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.MemberGoodMapping)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("FK_Reference_2");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberGoodMapping)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Reference_1");
            });

            modelBuilder.Entity<MemberLevelMapping>(entity =>
            {
                entity.ToTable("member_level_mapping");

                entity.HasIndex(e => e.LevelId)
                    .HasName("FK_Reference_4");

                entity.HasIndex(e => e.MemberId)
                    .HasName("FK_Reference_3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.MemberLevelMapping)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reference_4");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberLevelMapping)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reference_3");
            });

            modelBuilder.Entity<Statistics>(entity =>
            {
                entity.ToTable("statistics");

                entity.HasIndex(e => e.MemberId)
                    .HasName("FK_Reference_5");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreditsChange).HasColumnName("credits_change");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.TotalDiscount).HasColumnName("total_discount");

                entity.Property(e => e.TotalPayment).HasColumnName("total_payment");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Statistics)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Reference_5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
