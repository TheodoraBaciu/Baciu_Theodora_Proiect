﻿// <auto-generated />
using System;
using Baciu_Theodora_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Baciu_Theodora_Proiect.Migrations
{
    [DbContext(typeof(Baciu_Theodora_ProiectContext))]
    partial class Baciu_Theodora_ProiectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Baciu_Theodora_Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Baciu_Theodora_Proiect.Models.FlowerBox", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AparitionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StoreID");

                    b.ToTable("FlowerBox");
                });

            modelBuilder.Entity("Baciu_Theodora_Proiect.Models.FlowerBoxCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("FlowerBoxID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("FlowerBoxID");

                    b.ToTable("FlowerBoxCategory");
                });

            modelBuilder.Entity("Baciu_Theodora_Proiect.Models.Store", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StoreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Baciu_Theodora_Proiect.Models.FlowerBox", b =>
                {
                    b.HasOne("Baciu_Theodora_Proiect.Models.Store", "Store")
                        .WithMany("FlowerBoxes")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Baciu_Theodora_Proiect.Models.FlowerBoxCategory", b =>
                {
                    b.HasOne("Baciu_Theodora_Proiect.Models.Category", "Category")
                        .WithMany("FlowerBoxCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Baciu_Theodora_Proiect.Models.FlowerBox", "FlowerBox")
                        .WithMany("FlowerBoxCategories")
                        .HasForeignKey("FlowerBoxID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
