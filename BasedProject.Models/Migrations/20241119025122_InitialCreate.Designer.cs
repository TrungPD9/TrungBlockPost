﻿/*// <auto-generated />
using System;
using BasedProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasedProject.Models.Migrations
{
    [DbContext(typeof(JustBlogContext))]
    [Migration("20241119025122_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BasedProject.Models.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Posts related to technology and programming",
                            Name = "Technology",
                            UrlSlug = "technology"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Posts about health, wellness, and fitness",
                            Name = "Health",
                            UrlSlug = "health"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lifestyle and personal development posts",
                            Name = "Lifestyle",
                            UrlSlug = "lifestyle"
                        });
                });

            modelBuilder.Entity("BasedProject.Models.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BasedProject.Models.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<int>("RateCount")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TotalRate")
                        .HasColumnType("int");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Modified = new DateTime(2024, 11, 19, 2, 51, 22, 626, DateTimeKind.Utc).AddTicks(999),
                            PostContent = "Content of the C# post",
                            PostedOn = new DateTime(2024, 11, 19, 2, 51, 22, 626, DateTimeKind.Utc).AddTicks(996),
                            Published = true,
                            RateCount = 0,
                            ShortDescription = "Basic guide to C#",
                            Title = "Introduction to C#",
                            TotalRate = 0,
                            UrlSlug = "introduction-to-csharp",
                            ViewCount = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Modified = new DateTime(2024, 11, 19, 2, 51, 22, 626, DateTimeKind.Utc).AddTicks(1003),
                            PostContent = "Content about yoga health benefits",
                            PostedOn = new DateTime(2024, 11, 19, 2, 51, 22, 626, DateTimeKind.Utc).AddTicks(1002),
                            Published = true,
                            RateCount = 0,
                            ShortDescription = "Yoga benefits",
                            Title = "Health Benefits of Yoga",
                            TotalRate = 0,
                            UrlSlug = "health-benefits-of-yoga",
                            ViewCount = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Modified = new DateTime(2024, 11, 19, 2, 51, 22, 626, DateTimeKind.Utc).AddTicks(1076),
                            PostContent = "Content on improving lifestyle",
                            PostedOn = new DateTime(2024, 11, 19, 2, 51, 22, 626, DateTimeKind.Utc).AddTicks(1075),
                            Published = true,
                            RateCount = 0,
                            ShortDescription = "Lifestyle tips",
                            Title = "10 Tips for a Better Lifestyle",
                            TotalRate = 0,
                            UrlSlug = "10-tips-better-lifestyle",
                            ViewCount = 0
                        });
                });

            modelBuilder.Entity("BasedProject.Models.Models.PostTagMap", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTagMaps");
                });

            modelBuilder.Entity("BasedProject.Models.Models.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 10,
                            Description = "Programming language",
                            Name = "C#",
                            UrlSlug = "csharp"
                        },
                        new
                        {
                            Id = 2,
                            Count = 8,
                            Description = "Health tips",
                            Name = "Health",
                            UrlSlug = "health-tips"
                        },
                        new
                        {
                            Id = 3,
                            Count = 12,
                            Description = "Fitness routines",
                            Name = "Fitness",
                            UrlSlug = "fitness"
                        });
                });

            modelBuilder.Entity("BasedProject.Models.Models.Comment", b =>
                {
                    b.HasOne("BasedProject.Models.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BasedProject.Models.Models.Post", b =>
                {
                    b.HasOne("BasedProject.Models.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BasedProject.Models.Models.PostTagMap", b =>
                {
                    b.HasOne("BasedProject.Models.Models.Post", "Post")
                        .WithMany("PostTagMap")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasedProject.Models.Models.Tags", "Tags")
                        .WithMany("PostTagsmaps")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("BasedProject.Models.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BasedProject.Models.Models.Post", b =>
                {
                    b.Navigation("PostTagMap");
                });

            modelBuilder.Entity("BasedProject.Models.Models.Tags", b =>
                {
                    b.Navigation("PostTagsmaps");
                });
#pragma warning restore 612, 618
        }
    }
}
*/