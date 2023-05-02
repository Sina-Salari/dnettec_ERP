﻿// <auto-generated />
using System;
using Kernel.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kernel.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230205165848_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kernel.Domain.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Kernel.Domain.Models.EntityField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FeildType")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDuplicate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.ToTable("EntityFields");
                });

            modelBuilder.Entity("Kernel.Domain.Models.EntityFieldRelation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntityFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntityFieldId");

                    b.HasIndex("EntityId");

                    b.ToTable("EntityFieldRelations");
                });

            modelBuilder.Entity("Kernel.Domain.Models.EntityFieldValidation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntityFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Regex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntityFieldId");

                    b.HasIndex("MessageId");

                    b.ToTable("EntityFieldValidations");
                });

            modelBuilder.Entity("Kernel.Domain.Models.LangMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("MessageId");

                    b.ToTable("LangMessages");
                });

            modelBuilder.Entity("Kernel.Domain.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Kernel.Domain.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Kernel.Domain.Models.ProcessStep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<int>("ProcessType")
                        .HasColumnType("int");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProcessSteps");
                });

            modelBuilder.Entity("Kernel.Domain.Models.RequestPattern", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkFlowId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkFlowId");

                    b.ToTable("RequestPatterns");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkFlows");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BodyJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkFlowId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkFlowId")
                        .IsUnique();

                    b.ToTable("WorkFlowInput");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowResponse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<string>("ResponseJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkFlowId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkFlowId")
                        .IsUnique();

                    b.ToTable("WorkFlowResponse");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowStep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFirst")
                        .HasColumnType("bit");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RecordType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkFlowId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkFlowId");

                    b.ToTable("WorkFlowSteps");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowStepMovment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkFlowNextStepId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkFlowStepId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkFlowStepMovmentValueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkFlowNextStepId");

                    b.HasIndex("WorkFlowStepId");

                    b.HasIndex("WorkFlowStepMovmentValueId");

                    b.ToTable("WorkFlowStepMovments");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowStepMovmentValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBase")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("ValueStepId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ValueStepId");

                    b.ToTable("WorkFlowStepMovmentValues");
                });

            modelBuilder.Entity("Kernel.Domain.Models.EntityField", b =>
                {
                    b.HasOne("Kernel.Domain.Models.Entity", "Entity")
                        .WithMany("EntityFields")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("Kernel.Domain.Models.EntityFieldRelation", b =>
                {
                    b.HasOne("Kernel.Domain.Models.EntityField", "EntityField")
                        .WithMany("EntityFieldRelations")
                        .HasForeignKey("EntityFieldId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Kernel.Domain.Models.Entity", "Entity")
                        .WithMany("EntityFieldRelations")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Entity");

                    b.Navigation("EntityField");
                });

            modelBuilder.Entity("Kernel.Domain.Models.EntityFieldValidation", b =>
                {
                    b.HasOne("Kernel.Domain.Models.EntityField", "EntityField")
                        .WithMany("EntityFieldValidations")
                        .HasForeignKey("EntityFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kernel.Domain.Models.Message", "Message")
                        .WithMany("EntityFieldValidations")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntityField");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Kernel.Domain.Models.LangMessage", b =>
                {
                    b.HasOne("Kernel.Domain.Models.Language", "Language")
                        .WithMany("LangMessages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kernel.Domain.Models.Message", "Message")
                        .WithMany("LangMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Kernel.Domain.Models.RequestPattern", b =>
                {
                    b.HasOne("Kernel.Domain.Models.WorkFlow", "WorkFlow")
                        .WithMany()
                        .HasForeignKey("WorkFlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkFlow");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowInput", b =>
                {
                    b.HasOne("Kernel.Domain.Models.WorkFlow", "WorkFlow")
                        .WithOne("WorkFlowInput")
                        .HasForeignKey("Kernel.Domain.Models.WorkFlowInput", "WorkFlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkFlow");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowResponse", b =>
                {
                    b.HasOne("Kernel.Domain.Models.WorkFlow", "WorkFlow")
                        .WithOne("WorkFlowResponse")
                        .HasForeignKey("Kernel.Domain.Models.WorkFlowResponse", "WorkFlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkFlow");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowStep", b =>
                {
                    b.HasOne("Kernel.Domain.Models.WorkFlow", "WorkFlow")
                        .WithMany("WorkFlowSteps")
                        .HasForeignKey("WorkFlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkFlow");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowStepMovment", b =>
                {
                    b.HasOne("Kernel.Domain.Models.WorkFlowStep", "WorkFlowNextStep")
                        .WithMany("WorkFlowNextStepMovments")
                        .HasForeignKey("WorkFlowNextStepId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Kernel.Domain.Models.WorkFlowStep", "WorkFlowStep")
                        .WithMany("WorkFlowStepMovments")
                        .HasForeignKey("WorkFlowStepId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Kernel.Domain.Models.WorkFlowStepMovmentValue", "WorkFlowStepMovmentValue")
                        .WithMany()
                        .HasForeignKey("WorkFlowStepMovmentValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkFlowNextStep");

                    b.Navigation("WorkFlowStep");

                    b.Navigation("WorkFlowStepMovmentValue");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowStepMovmentValue", b =>
                {
                    b.HasOne("Kernel.Domain.Models.WorkFlowStep", "WorkFlowStepValue")
                        .WithMany()
                        .HasForeignKey("ValueStepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkFlowStepValue");
                });

            modelBuilder.Entity("Kernel.Domain.Models.Entity", b =>
                {
                    b.Navigation("EntityFieldRelations");

                    b.Navigation("EntityFields");
                });

            modelBuilder.Entity("Kernel.Domain.Models.EntityField", b =>
                {
                    b.Navigation("EntityFieldRelations");

                    b.Navigation("EntityFieldValidations");
                });

            modelBuilder.Entity("Kernel.Domain.Models.Language", b =>
                {
                    b.Navigation("LangMessages");
                });

            modelBuilder.Entity("Kernel.Domain.Models.Message", b =>
                {
                    b.Navigation("EntityFieldValidations");

                    b.Navigation("LangMessages");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlow", b =>
                {
                    b.Navigation("WorkFlowInput")
                        .IsRequired();

                    b.Navigation("WorkFlowResponse")
                        .IsRequired();

                    b.Navigation("WorkFlowSteps");
                });

            modelBuilder.Entity("Kernel.Domain.Models.WorkFlowStep", b =>
                {
                    b.Navigation("WorkFlowNextStepMovments");

                    b.Navigation("WorkFlowStepMovments");
                });
#pragma warning restore 612, 618
        }
    }
}
