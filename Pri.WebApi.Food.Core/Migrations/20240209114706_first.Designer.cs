﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pri.WebApi.Food.Core.Data;

#nullable disable

namespace Pri.WebApi.Food.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240209114706_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pri.WebApi.Food.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5082),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5084),
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5085),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5085),
                            Name = "Pasta"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5087),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5087),
                            Name = "Groenten"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5088),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5089),
                            Name = "Fruit"
                        });
                });

            modelBuilder.Entity("Pri.WebApi.Food.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CategoryId = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5153),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5153),
                            Name = "Peperoni"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CategoryId = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5155),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5155),
                            Name = "Hawai"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            CategoryId = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5156),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5156),
                            Name = "Macaroni"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            CategoryId = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5158),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5158),
                            Name = "Spaghetti"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000005"),
                            CategoryId = new Guid("00000000-0000-0000-0000-000000000003"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5159),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5159),
                            Name = "Komkommer"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000006"),
                            CategoryId = new Guid("00000000-0000-0000-0000-000000000003"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5161),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5161),
                            Name = "Tomaat"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000007"),
                            CategoryId = new Guid("00000000-0000-0000-0000-000000000004"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5162),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5163),
                            Name = "Appel"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000008"),
                            CategoryId = new Guid("00000000-0000-0000-0000-000000000004"),
                            CreatedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5164),
                            LastEditedOn = new DateTime(2024, 2, 9, 11, 47, 6, 251, DateTimeKind.Utc).AddTicks(5164),
                            Name = "Peer"
                        });
                });

            modelBuilder.Entity("Pri.WebApi.Food.Core.Entities.Product", b =>
                {
                    b.HasOne("Pri.WebApi.Food.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
