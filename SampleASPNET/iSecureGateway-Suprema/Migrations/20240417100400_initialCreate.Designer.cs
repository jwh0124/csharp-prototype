﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using iSecureGateway_Suprema.Contexts;

#nullable disable

namespace iSecureGateway_Suprema.Migrations
{
    [DbContext(typeof(SupremaContext))]
    [Migration("20240417100400_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccessGroupAccessLevel", b =>
                {
                    b.Property<string>("AccessGroupsCode")
                        .HasColumnType("text");

                    b.Property<string>("AccessLevelsCode")
                        .HasColumnType("text");

                    b.HasKey("AccessGroupsCode", "AccessLevelsCode");

                    b.HasIndex("AccessLevelsCode");

                    b.ToTable("AccessGroupAccessLevel");
                });

            modelBuilder.Entity("iSecureGateway_Suprema.Models.AccessGroup", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("AccessGroup");
                });

            modelBuilder.Entity("iSecureGateway_Suprema.Models.AccessLevel", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("AccessScheduleCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.HasIndex("AccessScheduleCode");

                    b.ToTable("AccessLevel");
                });

            modelBuilder.Entity("iSecureGateway_Suprema.Models.AccessSchedule", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("AccessSchedule");
                });

            modelBuilder.Entity("AccessGroupAccessLevel", b =>
                {
                    b.HasOne("iSecureGateway_Suprema.Models.AccessGroup", null)
                        .WithMany()
                        .HasForeignKey("AccessGroupsCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iSecureGateway_Suprema.Models.AccessLevel", null)
                        .WithMany()
                        .HasForeignKey("AccessLevelsCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("iSecureGateway_Suprema.Models.AccessLevel", b =>
                {
                    b.HasOne("iSecureGateway_Suprema.Models.AccessSchedule", "AccessSchedule")
                        .WithMany("AccessLevels")
                        .HasForeignKey("AccessScheduleCode");

                    b.Navigation("AccessSchedule");
                });

            modelBuilder.Entity("iSecureGateway_Suprema.Models.AccessSchedule", b =>
                {
                    b.Navigation("AccessLevels");
                });
#pragma warning restore 612, 618
        }
    }
}
