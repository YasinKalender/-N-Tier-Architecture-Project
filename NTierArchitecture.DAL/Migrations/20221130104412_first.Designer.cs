﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTierArchitecture.DAL.Context;

#nullable disable

namespace NTierArchitecture.DAL.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20221130104412_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NTierArchitecture.Entites.ORM.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CategoryName");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Category",
                            CreatedDate = new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9083),
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Category2",
                            CreatedDate = new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9091),
                            Status = 0
                        });
                });

            modelBuilder.Entity("NTierArchitecture.Entites.ORM.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductFeatureId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ProductName");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9219),
                            Price = 1000m,
                            ProductFeatureId = 0,
                            ProductName = "Product1",
                            Status = 0,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9221),
                            Price = 1000m,
                            ProductFeatureId = 0,
                            ProductName = "Product2",
                            Status = 0,
                            Stock = 100
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9222),
                            Price = 1000m,
                            ProductFeatureId = 0,
                            ProductName = "Product3",
                            Status = 0,
                            Stock = 100
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9223),
                            Price = 1000m,
                            ProductFeatureId = 0,
                            ProductName = "Product4",
                            Status = 0,
                            Stock = 100
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9224),
                            Price = 1000m,
                            ProductFeatureId = 0,
                            ProductName = "Product5",
                            Status = 0,
                            Stock = 100
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 11, 30, 13, 44, 12, 243, DateTimeKind.Local).AddTicks(9225),
                            Price = 1000m,
                            ProductFeatureId = 0,
                            ProductName = "Product6",
                            Status = 0,
                            Stock = 100
                        });
                });

            modelBuilder.Entity("NTierArchitecture.Entites.ORM.Concrete.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdcutDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeature");
                });

            modelBuilder.Entity("NTierArchitecture.Entites.ORM.Concrete.Product", b =>
                {
                    b.HasOne("NTierArchitecture.Entites.ORM.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NTierArchitecture.Entites.ORM.Concrete.ProductFeature", b =>
                {
                    b.HasOne("NTierArchitecture.Entites.ORM.Concrete.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("NTierArchitecture.Entites.ORM.Concrete.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NTierArchitecture.Entites.ORM.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NTierArchitecture.Entites.ORM.Concrete.Product", b =>
                {
                    b.Navigation("ProductFeature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
