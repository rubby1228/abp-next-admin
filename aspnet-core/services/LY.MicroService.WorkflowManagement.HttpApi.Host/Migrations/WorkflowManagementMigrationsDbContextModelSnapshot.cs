﻿// <auto-generated />
using System;
using LY.MicroService.WorkflowManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

#nullable disable

namespace LY.MicroService.WorkflowManagement.Migrations
{
    [DbContext(typeof(WorkflowManagementMigrationsDbContext))]
    partial class WorkflowManagementMigrationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<string>("EventData")
                        .HasColumnType("longtext");

                    b.Property<string>("EventKey")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("EventName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("IsProcessed");

                    b.HasIndex("EventName", "EventKey");

                    b.ToTable("WF_Event", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedExecutionError", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ErrorTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ExecutionPointerId")
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("WF_ExecutionError", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedExecutionPointer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Children")
                        .HasColumnType("longtext");

                    b.Property<string>("ContextItem")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EventData")
                        .HasColumnType("longtext");

                    b.Property<string>("EventKey")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("EventName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("EventPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Outcome")
                        .HasColumnType("longtext");

                    b.Property<string>("PersistenceData")
                        .HasColumnType("longtext");

                    b.Property<string>("PredecessorId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RetryCount")
                        .HasColumnType("int");

                    b.Property<string>("Scope")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("SleepUntil")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<string>("StepName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("WF_ExecutionPointer", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedExtensionAttribute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<Guid>("ExecutionPointerId")
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<string>("Key")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExecutionPointerId");

                    b.ToTable("WF_ExtensionAttribute", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedScheduledCommand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CommandName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Data")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<long>("ExecuteTime")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("ExecuteTime");

                    b.HasIndex("CommandName", "Data")
                        .IsUnique();

                    b.ToTable("WF_ScheduledCommand", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedSubscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("EventKey")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("EventName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("ExecutionPointerId")
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<string>("ExternalToken")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("ExternalTokenExpiry")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ExternalWorkerId")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscribeAsOf")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SubscriptionData")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EventKey");

                    b.HasIndex("EventName");

                    b.ToTable("WF_Subscription", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedWorkflow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CompleteTime")
                        .HasColumnType("datetime(6)");

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

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<long?>("NextExecution")
                        .HasColumnType("bigint");

                    b.Property<string>("Reference")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowDefinitionId")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("NextExecution");

                    b.ToTable("WF_Workflow", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowManagement.CompensateNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CancelCondition")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("ErrorBehavior")
                        .HasColumnType("int");

                    b.Property<string>("Inputs")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Outputs")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<TimeSpan?>("RetryInterval")
                        .HasColumnType("time(6)");

                    b.Property<bool>("Saga")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SelectNextStep")
                        .HasColumnType("longtext");

                    b.Property<string>("StepType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("WF_Compensate", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowManagement.StepNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CancelCondition")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("ErrorBehavior")
                        .HasColumnType("int");

                    b.Property<string>("Inputs")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Outputs")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<TimeSpan?>("RetryInterval")
                        .HasColumnType("time(6)");

                    b.Property<bool>("Saga")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SelectNextStep")
                        .HasColumnType("longtext");

                    b.Property<string>("StepType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("WF_Step", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowManagement.Workflow", b =>
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

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ErrorBehavior")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("ErrorRetryInterval")
                        .HasColumnType("time(6)");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WF_Definition", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowManagement.WorkflowData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsCaseSensitive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.Property<Guid>("WorkflowId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("WF_DefinitionData", (string)null);
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedExecutionPointer", b =>
                {
                    b.HasOne("LINGYUN.Abp.WorkflowCore.Persistence.PersistedWorkflow", "Workflow")
                        .WithMany("ExecutionPointers")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedExtensionAttribute", b =>
                {
                    b.HasOne("LINGYUN.Abp.WorkflowCore.Persistence.PersistedExecutionPointer", "ExecutionPointer")
                        .WithMany("ExtensionAttributes")
                        .HasForeignKey("ExecutionPointerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExecutionPointer");
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowManagement.WorkflowData", b =>
                {
                    b.HasOne("LINGYUN.Abp.WorkflowManagement.Workflow", null)
                        .WithMany("Datas")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedExecutionPointer", b =>
                {
                    b.Navigation("ExtensionAttributes");
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowCore.Persistence.PersistedWorkflow", b =>
                {
                    b.Navigation("ExecutionPointers");
                });

            modelBuilder.Entity("LINGYUN.Abp.WorkflowManagement.Workflow", b =>
                {
                    b.Navigation("Datas");
                });
#pragma warning restore 612, 618
        }
    }
}
