﻿// <auto-generated />
using CmdApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CmdApi.Migrations
{
    [DbContext(typeof(CommandContext))]
    partial class CommandContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CmdApi.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Commandline")
                        .HasColumnType("text");

                    b.Property<string>("HowTo")
                        .HasColumnType("text");

                    b.Property<string>("Platform")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CommandItems");
                });
#pragma warning restore 612, 618
        }
    }
}
