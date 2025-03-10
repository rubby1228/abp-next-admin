﻿// <auto-generated />
using System;
using LY.MicroService.PlatformManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

#nullable disable

namespace LY.MicroService.PlatformManagement.Migrations
{
    [DbContext(typeof(PlatformManagementMigrationsDbContext))]
    partial class PlatformHttpApiHostMigrationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LINGYUN.Platform.Datas.Data", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("Code");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("char(36)")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("Description");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("DisplayName");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<bool>("IsStatic")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("AppPlatformDatas", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Datas.DataItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("AllowBeNull")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<Guid>("DataId")
                        .HasColumnType("char(36)");

                    b.Property<string>("DefaultValue")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("DefaultValue");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("char(36)")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("Description");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("DisplayName");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<bool>("IsStatic")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<int>("ValueType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DataId");

                    b.HasIndex("Name");

                    b.ToTable("AppPlatformDataItems", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Layouts.Layout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<Guid>("DataId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("char(36)")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("DisplayName");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<string>("Framework")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Framework");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Name");

                    b.Property<string>("Path")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Path");

                    b.Property<string>("Redirect")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Redirect");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.ToTable("AppPlatformLayouts", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Menus.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(23)
                        .HasColumnType("varchar(23)")
                        .HasColumnName("Code");

                    b.Property<string>("Component")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Component");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("char(36)")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("DisplayName");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<string>("Framework")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Framework");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<Guid>("LayoutId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Path")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Path");

                    b.Property<string>("Redirect")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Redirect");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.ToTable("AppPlatformMenus", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Menus.RoleMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("char(36)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("RoleName");

                    b.Property<bool>("Startup")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("RoleName", "MenuId");

                    b.ToTable("AppPlatformRoleMenus", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Menus.UserFavoriteMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AliasName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("AliasName");

                    b.Property<string>("Color")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Color");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("DisplayName");

                    b.Property<string>("Framework")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Framework");

                    b.Property<string>("Icon")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("Icon");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Name");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Path");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "MenuId");

                    b.ToTable("AppPlatformUserFavoriteMenus", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Menus.UserMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Startup")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "MenuId");

                    b.ToTable("AppPlatformUserMenus", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Versions.AppVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("char(36)")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("varchar(2048)")
                        .HasColumnName("Description");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("PlatformType")
                        .HasColumnType("int");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Title");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Version");

                    b.HasKey("Id");

                    b.HasIndex("Version");

                    b.ToTable("AppPlatformVersion", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Versions.VersionFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AppVersionId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<int>("DownloadCount")
                        .HasColumnType("int");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Name");

                    b.Property<string>("Path")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Path");

                    b.Property<string>("SHA256")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("varchar(65)")
                        .HasColumnName("SHA256");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Version");

                    b.HasKey("Id");

                    b.HasIndex("AppVersionId");

                    b.HasIndex("Path", "Name", "Version")
                        .IsUnique();

                    b.ToTable("AppPlatformVersionFile", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Platform.Datas.DataItem", b =>
                {
                    b.HasOne("LINGYUN.Platform.Datas.Data", null)
                        .WithMany("Items")
                        .HasForeignKey("DataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LINGYUN.Platform.Versions.VersionFile", b =>
                {
                    b.HasOne("LINGYUN.Platform.Versions.AppVersion", "AppVersion")
                        .WithMany("Files")
                        .HasForeignKey("AppVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppVersion");
                });

            modelBuilder.Entity("LINGYUN.Platform.Datas.Data", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("LINGYUN.Platform.Versions.AppVersion", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
