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
    [Migration("20220522072011_FinalMigration1")]
    partial class FinalMigration1
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

            modelBuilder.Entity("AccountProject", b =>
                {
                    b.Property<int>("ProjectUsersId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("ProjectUsersId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("AccountProject");
                });

            modelBuilder.Entity("AccountWorkgroup", b =>
                {
                    b.Property<int>("WorkgroupsId")
                        .HasColumnType("int");

                    b.Property<int>("WorkingUsersId")
                        .HasColumnType("int");

                    b.HasKey("WorkgroupsId", "WorkingUsersId");

                    b.HasIndex("WorkingUsersId");

                    b.ToTable("AccountWorkgroup");
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

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectTittle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Refference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatRoomId");

                    b.HasIndex("StatusId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Diplom.Auth.Models.ProjectStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Readiness")
                        .HasColumnType("int");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("projectStatuses");
                });

            modelBuilder.Entity("Diplom.Auth.Models.Workgroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDataTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripton")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkgroupStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkgroupStatusId");

                    b.ToTable("Workgroups");
                });

            modelBuilder.Entity("Diplom.Auth.Models.WorkgroupStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Defifnition")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkgroupStatuses");
                });

            modelBuilder.Entity("Diplom.Auth.Models.WorkgroupTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Definition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkgroupId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkgroupTaskStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkgroupId");

                    b.HasIndex("WorkgroupTaskStatusId");

                    b.ToTable("WorkgroupTasks");
                });

            modelBuilder.Entity("Diplom.Auth.Models.WorkgroupTaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Readiness")
                        .HasColumnType("int");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkgroupTaskStatuses");
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

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Diplom.Models.ChatRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatingChatDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatingChatDataId");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("Diplom.Models.CreatingChatData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserCreateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.ToTable("CreatingChatDatas");
                });

            modelBuilder.Entity("Diplom.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChatRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatRoomId");

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

            modelBuilder.Entity("ProjectWorkgroup", b =>
                {
                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<int>("WorkgroupsId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsId", "WorkgroupsId");

                    b.HasIndex("WorkgroupsId");

                    b.ToTable("ProjectWorkgroup");
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

            modelBuilder.Entity("AccountProject", b =>
                {
                    b.HasOne("Diplom.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("ProjectUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diplom.Auth.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccountWorkgroup", b =>
                {
                    b.HasOne("Diplom.Auth.Models.Workgroup", null)
                        .WithMany()
                        .HasForeignKey("WorkgroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diplom.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("WorkingUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diplom.Auth.Models.Project", b =>
                {
                    b.HasOne("Diplom.Models.ChatRoom", "ChatRoom")
                        .WithMany()
                        .HasForeignKey("ChatRoomId");

                    b.HasOne("Diplom.Auth.Models.ProjectStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("ChatRoom");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Diplom.Auth.Models.Workgroup", b =>
                {
                    b.HasOne("Diplom.Auth.Models.WorkgroupStatus", "WorkgroupStatus")
                        .WithMany()
                        .HasForeignKey("WorkgroupStatusId");

                    b.Navigation("WorkgroupStatus");
                });

            modelBuilder.Entity("Diplom.Auth.Models.WorkgroupTask", b =>
                {
                    b.HasOne("Diplom.Auth.Models.Workgroup", null)
                        .WithMany("WorkgroupTasks")
                        .HasForeignKey("WorkgroupId");

                    b.HasOne("Diplom.Auth.Models.WorkgroupTaskStatus", "WorkgroupTaskStatus")
                        .WithMany()
                        .HasForeignKey("WorkgroupTaskStatusId");

                    b.Navigation("WorkgroupTaskStatus");
                });

            modelBuilder.Entity("Diplom.Models.Account", b =>
                {
                    b.HasOne("Diplom.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Diplom.Models.ChatRoom", b =>
                {
                    b.HasOne("Diplom.Models.CreatingChatData", "CreatingChatData")
                        .WithMany()
                        .HasForeignKey("CreatingChatDataId");

                    b.Navigation("CreatingChatData");
                });

            modelBuilder.Entity("Diplom.Models.CreatingChatData", b =>
                {
                    b.HasOne("Diplom.Models.Account", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.Navigation("UserCreate");
                });

            modelBuilder.Entity("Diplom.Models.Message", b =>
                {
                    b.HasOne("Diplom.Models.ChatRoom", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatRoomId");
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

            modelBuilder.Entity("ProjectWorkgroup", b =>
                {
                    b.HasOne("Diplom.Auth.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diplom.Auth.Models.Workgroup", null)
                        .WithMany()
                        .HasForeignKey("WorkgroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diplom.Auth.Models.Workgroup", b =>
                {
                    b.Navigation("WorkgroupTasks");
                });

            modelBuilder.Entity("Diplom.Models.Account", b =>
                {
                    b.Navigation("References");

                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("Diplom.Models.ChatRoom", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
