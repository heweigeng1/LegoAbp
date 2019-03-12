﻿// <auto-generated />
using System;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LegoAbp.Migrations
{
    [DbContext(typeof(LegoAbpDbContext))]
    [Migration("20190311073431_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LegoAbp.Zero.Authorization.Roles.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("IsDefault");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsStatic");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int?>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new { Id = new Guid("2a88fe00-b533-4eb0-8888-14419cf56b9f"), ConcurrencyStamp = "91400b30-7289-4312-ab6f-7c60732c2a05", CreationTime = new DateTime(2019, 3, 11, 15, 34, 30, 811, DateTimeKind.Local), DisplayName = "超级管理员", IsDefault = false, IsDeleted = false, IsStatic = false, Name = "admin", NormalizedName = "ADMIN" }
                    );
                });

            modelBuilder.Entity("LegoAbp.Zero.Authorization.Roles.Domain.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<Guid>("RoleId");

                    b.Property<int?>("TenantId");

                    b.Property<Guid>("UserId");

                    b.Property<long?>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("LegoAbp.Zero.Authorization.Users.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(256);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsEmailConfirmed");

                    b.Property<bool>("IsLockoutEnabled");

                    b.Property<bool>("IsPhoneNumberConfirmed");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<DateTime?>("LockoutEndDateUtc");

                    b.Property<string>("NormalizedEmailAddress")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(128);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16);

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(128);

                    b.Property<int>("Sex");

                    b.Property<int?>("TenantId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new { Id = 1L, AccessFailedCount = 0, CreationTime = new DateTime(2019, 3, 11, 15, 34, 30, 807, DateTimeKind.Local), IsActive = true, IsDeleted = false, IsEmailConfirmed = false, IsLockoutEnabled = false, IsPhoneNumberConfirmed = false, Password = "123456", Sex = 0, UserName = "admin" }
                    );
                });

            modelBuilder.Entity("LegoAbp.Zero.Authorization.Users.Domain.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType")
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<int?>("TenantId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("LegoAbp.Zero.Authorization.Users.Domain.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("TenantId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("LegoAbp.Zero.Tenants.Domain.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(512);

                    b.Property<string>("CompanyProfile");

                    b.Property<DateTime>("CreationTime");

                    b.Property<DateTime?>("EndTime");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<string>("LogoPath")
                        .HasMaxLength(512);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16);

                    b.Property<string>("QQNumber")
                        .HasMaxLength(16);

                    b.Property<DateTime?>("StartTime");

                    b.Property<string>("TenantCode")
                        .HasMaxLength(12);

                    b.Property<string>("TenantName")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Tenant");

                    b.HasData(
                        new { Id = 1, CreationTime = new DateTime(2019, 3, 11, 15, 34, 30, 687, DateTimeKind.Local), IsActive = true, IsDeleted = false, TenantCode = "default", TenantName = "default" }
                    );
                });

            modelBuilder.Entity("LegoAbp.Zero.Authorization.Roles.Domain.UserRole", b =>
                {
                    b.HasOne("LegoAbp.Zero.Authorization.Users.Domain.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("LegoAbp.Zero.Authorization.Users.Domain.UserClaim", b =>
                {
                    b.HasOne("LegoAbp.Zero.Authorization.Users.Domain.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LegoAbp.Zero.Authorization.Users.Domain.UserLogin", b =>
                {
                    b.HasOne("LegoAbp.Zero.Authorization.Users.Domain.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}