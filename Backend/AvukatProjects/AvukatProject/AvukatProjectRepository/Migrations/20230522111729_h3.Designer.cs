﻿// <auto-generated />
using System;
using AvukatProjectRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AvukatProjectRepository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230522111729_h3")]
    partial class h3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AvukatProjectCore.Model.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abouts")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Answers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ceza Hukuku"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Medeni Hukuku"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Borçlar Hukuku"
                        });
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Lawyers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photograph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RoleId");

                    b.ToTable("Lawyers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            About = "Ceza Hukukçusu",
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 5, 22, 14, 17, 28, 807, DateTimeKind.Local).AddTicks(5955),
                            Email = "emreuuguz@gmail.com",
                            Name = "Emre Uğuz",
                            Password = "1234",
                            Photograph = "asd"
                        },
                        new
                        {
                            Id = 2,
                            About = "Medeni Hukukçusu",
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 5, 22, 14, 17, 28, 807, DateTimeKind.Local).AddTicks(5966),
                            Email = "cagrisenturk@gmail.com",
                            Name = "Çağrı Şentürk",
                            Password = "12324",
                            Photograph = "asd"
                        },
                        new
                        {
                            Id = 3,
                            About = "Borçlar Hukukçusu",
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 5, 22, 14, 17, 28, 807, DateTimeKind.Local).AddTicks(5967),
                            Email = "hakanozdemır@gmail.com",
                            Name = "Hakan Özdemir",
                            Password = "123444",
                            Photograph = "asd"
                        },
                        new
                        {
                            Id = 9,
                            About = "Borçlar Hukukçusu",
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 5, 22, 14, 17, 28, 807, DateTimeKind.Local).AddTicks(5968),
                            Email = "hakanozdemır@gmail.com",
                            Name = "Hakan Özdemir",
                            Password = "123444",
                            Photograph = "asd"
                        });
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Oppressions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Oppression")
                        .HasColumnType("float");

                    b.Property<int>("OppressionQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Oppressions");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LawyersId")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LawyersId");

                    b.HasIndex("UsersId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lawyer"
                        });
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Answers", b =>
                {
                    b.HasOne("AvukatProjectCore.Model.Questions", "Questions")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AvukatProjectCore.Model.Users", "Users")
                        .WithMany("Answers")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Lawyers", b =>
                {
                    b.HasOne("AvukatProjectCore.Model.Category", "Category")
                        .WithMany("Lawyers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AvukatProjectCore.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Category");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Oppressions", b =>
                {
                    b.HasOne("AvukatProjectCore.Model.Questions", "Question")
                        .WithMany("Oppressions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Questions", b =>
                {
                    b.HasOne("AvukatProjectCore.Model.Lawyers", "Lawyers")
                        .WithMany("Questions")
                        .HasForeignKey("LawyersId");

                    b.HasOne("AvukatProjectCore.Model.Users", "Users")
                        .WithMany("Questions")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lawyers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Users", b =>
                {
                    b.HasOne("AvukatProjectCore.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Category", b =>
                {
                    b.Navigation("Lawyers");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Lawyers", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Questions", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Oppressions");
                });

            modelBuilder.Entity("AvukatProjectCore.Model.Users", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}