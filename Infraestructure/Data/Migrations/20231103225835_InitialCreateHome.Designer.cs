﻿// <auto-generated />
using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Data.Migrations
{
    [DbContext(typeof(DbFirstContext))]
    [Migration("20231103225835_InitialCreateHome")]
    partial class InitialCreateHome
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasMaxLength(45)
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("driver", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "idx_team_name")
                        .IsUnique();

                    b.ToTable("team", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Teamdriver", b =>
                {
                    b.Property<int>("IdDriver")
                        .HasColumnType("int");

                    b.Property<int>("Idteam")
                        .HasColumnType("int");

                    b.HasKey("IdDriver", "Idteam");

                    b.HasIndex("Idteam");

                    b.ToTable("teamdriver", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Teamdriver", b =>
                {
                    b.HasOne("Core.Entities.Driver", "Driver")
                        .WithMany("Teamdrivers")
                        .HasForeignKey("IdDriver")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Team", "Team")
                        .WithMany("Teamdrivers")
                        .HasForeignKey("Idteam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Core.Entities.Driver", b =>
                {
                    b.Navigation("Teamdrivers");
                });

            modelBuilder.Entity("Core.Entities.Team", b =>
                {
                    b.Navigation("Teamdrivers");
                });
#pragma warning restore 612, 618
        }
    }
}
