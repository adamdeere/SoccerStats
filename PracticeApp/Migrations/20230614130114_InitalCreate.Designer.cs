﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticeApp.Data;

#nullable disable

namespace PracticeApp.Migrations
{
    [DbContext(typeof(PracticeAppDbContext))]
    [Migration("20230614130114_InitalCreate")]
    partial class InitalCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticeApp.Models.ItemLocationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GRN")
                        .HasColumnType("int");

                    b.Property<int>("ItemNo")
                        .HasColumnType("int");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GRN");

                    b.HasIndex("ItemNo");

                    b.HasIndex("LocationId");

                    b.ToTable("ItemLocationModel");
                });

            modelBuilder.Entity("PracticeApp.Models.ItemModel", b =>
                {
                    b.Property<int>("ItemNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemNo"));

                    b.Property<int>("GRN")
                        .HasColumnType("int");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<string>("SKUCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ItemNo");

                    b.HasIndex("GRN");

                    b.HasIndex("SKUCode");

                    b.ToTable("ItemModel");
                });

            modelBuilder.Entity("PracticeApp.Models.LocationModel", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("LocationId");

                    b.ToTable("LocationModel");
                });

            modelBuilder.Entity("PracticeApp.Models.ProductModel", b =>
                {
                    b.Property<string>("SKUCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("SKUCode");

                    b.ToTable("ProductModel");
                });

            modelBuilder.Entity("PracticeApp.Models.ReceiptModel", b =>
                {
                    b.Property<int>("GRN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GRN"));

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedArrival")
                        .HasColumnType("datetime2");

                    b.Property<float>("TotalCube")
                        .HasColumnType("real");

                    b.Property<float>("TotalWeight")
                        .HasColumnType("real");

                    b.HasKey("GRN");

                    b.ToTable("ReceiptModel");
                });

            modelBuilder.Entity("PracticeApp.Models.ItemLocationModel", b =>
                {
                    b.HasOne("PracticeApp.Models.ReceiptModel", "Receipt")
                        .WithMany()
                        .HasForeignKey("GRN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticeApp.Models.ItemModel", "Item")
                        .WithMany()
                        .HasForeignKey("ItemNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticeApp.Models.LocationModel", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Location");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("PracticeApp.Models.ItemModel", b =>
                {
                    b.HasOne("PracticeApp.Models.ReceiptModel", "Receipt")
                        .WithMany()
                        .HasForeignKey("GRN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticeApp.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("SKUCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Receipt");
                });
#pragma warning restore 612, 618
        }
    }
}
