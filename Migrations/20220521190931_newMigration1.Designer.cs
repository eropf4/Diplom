﻿// <auto-generated />
using System;
using Diplom.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diplom.Auth.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220521190931_newMigration1")]
    partial class newMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountChatRoom", b =>
                {
                    b.Property<int>("AccountsId")
                        .HasColumnType("int");

                    b.Property<int>("ChatRoomsId")
                        .HasColumnType("int");

                    b.HasKey("AccountsId", "ChatRoomsId");

                    b.HasIndex("ChatRoomsId");

                    b.ToTable("AccountChatRoom");
                });

            modelBuilder.Entity("Diplom.Auth.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ChatRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectTittle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Refference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatRoomId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Diplom.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountRole")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InSystem")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Diplom.Models.ChatRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("Diplom.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Diplom.Models.UserReference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("References")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("UserReferences");
                });

            modelBuilder.Entity("Diplom.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserRoleStr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Diplom.Models.UserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Readiness")
                        .HasColumnType("int");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("AccountChatRoom", b =>
                {
                    b.HasOne("Diplom.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diplom.Models.ChatRoom", null)
                        .WithMany()
                        .HasForeignKey("ChatRoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diplom.Auth.Models.Project", b =>
                {
                    b.HasOne("Diplom.Models.ChatRoom", "ChatRoom")
                        .WithMany()
                        .HasForeignKey("ChatRoomId");

                    b.HasOne("Diplom.Models.Account", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.Navigation("ChatRoom");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Diplom.Models.Account", b =>
                {
                    b.HasOne("Diplom.Auth.Models.Project", null)
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Diplom.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Diplom.Models.UserReference", b =>
                {
                    b.HasOne("Diplom.Models.Account", null)
                        .WithMany("References")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Diplom.Models.UserTask", b =>
                {
                    b.HasOne("Diplom.Models.Account", null)
                        .WithMany("UserTasks")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Diplom.Auth.Models.Project", b =>
                {
                    b.Navigation("ProjectUsers");
                });

            modelBuilder.Entity("Diplom.Models.Account", b =>
                {
                    b.Navigation("References");

                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
