﻿// <auto-generated />
using System;
using HW13.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HW13.Migrations
{
    [DbContext(typeof(HW13DbContext))]
    [Migration("20241121193641_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HW13.Entities.BarrowedBook", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("BarrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("BookTitle");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("BarrowedBooks");
                });

            modelBuilder.Entity("HW13.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Genre")
                        .HasColumnType("int")
                        .HasColumnName("Genre Id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status number");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("BookTitle");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "A",
                            Genre = 1,
                            Status = 0,
                            Title = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Author = "B",
                            Genre = 1,
                            Status = 0,
                            Title = "sql"
                        },
                        new
                        {
                            Id = 3,
                            Author = "C",
                            Genre = 3,
                            Status = 0,
                            Title = "Math"
                        });
                });

            modelBuilder.Entity("HW13.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("RoleNumber");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "rajabiarash36@gmail.com",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            Name = "Arash",
                            Password = "12345",
                            RegisterDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = 1
                        });
                });

            modelBuilder.Entity("HW13.Entities.BarrowedBook", b =>
                {
                    b.HasOne("HW13.Entities.Book", "Book")
                        .WithOne("books")
                        .HasForeignKey("HW13.Entities.BarrowedBook", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HW13.Entities.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HW13.Entities.Book", b =>
                {
                    b.Navigation("books")
                        .IsRequired();
                });

            modelBuilder.Entity("HW13.Entities.User", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}