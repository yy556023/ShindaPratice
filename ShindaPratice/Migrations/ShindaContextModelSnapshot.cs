﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShindaPratice.Models.Shinda;

namespace ShindaPratice.Migrations
{
    [DbContext(typeof(ShindaContext))]
    partial class ShindaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShindaPratice.Models.Shinda.TblActiveItem", b =>
                {
                    b.Property<int>("CItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cItemID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CActiveDt")
                        .HasColumnName("cActiveDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CItemName")
                        .HasColumnName("cItemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CItemId");

                    b.ToTable("tblActiveItem");
                });

            modelBuilder.Entity("ShindaPratice.Models.Shinda.TblSignup", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CCreateDt")
                        .HasColumnName("cCreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CEmail")
                        .HasColumnName("cEmail")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CMobile")
                        .HasColumnName("cMobile")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("CName")
                        .HasColumnName("cName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("CId");

                    b.ToTable("tblSignup");
                });

            modelBuilder.Entity("ShindaPratice.Models.Shinda.TblSignupItem", b =>
                {
                    b.Property<int>("CSignupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cSignupID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CItemId")
                        .HasColumnName("cItemID")
                        .HasColumnType("int");

                    b.HasKey("CSignupId", "CItemId");

                    b.ToTable("tblSignupItem");
                });
#pragma warning restore 612, 618
        }
    }
}