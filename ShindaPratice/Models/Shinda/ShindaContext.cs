using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShindaPratice.Models.Shinda
{
    public partial class ShindaContext : DbContext
    {
        public ShindaContext()
        {
        }

        public ShindaContext(DbContextOptions<ShindaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActiveItem> TblActiveItem { get; set; }
        public virtual DbSet<TblSignup> TblSignup { get; set; }
        public virtual DbSet<TblSignupItem> TblSignupItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblActiveItem>(entity =>
            {
                entity.HasKey(e => e.CItemId);

                entity.ToTable("tblActiveItem");

                entity.Property(e => e.CItemId).HasColumnName("cItemID");

                entity.Property(e => e.CActiveDt)
                    .IsRequired()
                    .HasColumnName("cActiveDt")
                    .HasMaxLength(20);

                entity.Property(e => e.CItemName)
                    .HasColumnName("cItemName")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblSignup>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tblSignup");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.CCreateDt)
                    .HasColumnName("cCreateDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CEmail)
                    .HasColumnName("cEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.CMobile)
                    .HasColumnName("cMobile")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblSignupItem>(entity =>
            {
                entity.HasKey(e => new { e.CSignupId, e.CItemId });

                entity.ToTable("tblSignupItem");

                entity.Property(e => e.CSignupId)
                    .HasColumnName("cSignupID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CItemId).HasColumnName("cItemID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
