﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bernardo_dev.Data;

#nullable disable

namespace bernardo_dev.Migrations
{
    [DbContext(typeof(BernardoDevDbContext))]
    partial class BernardoDevDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bernardo_dev.Models.Domain.TicTacToes.Boards.Entities.Board", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fields")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Playing")
                        .HasColumnType("bit");

                    b.Property<int>("Turn")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TicTacToe_Board", (string)null);
                });

            modelBuilder.Entity("bernardo_dev.Models.Domain.TicTacToes.Players.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Connected")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerType")
                        .HasColumnType("int");

                    b.Property<bool>("Turn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("TicTacToe_Player", (string)null);
                });

            modelBuilder.Entity("bernardo_dev.Models.Domain.Weathers.WeatherType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeatherTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                            Description = "Freezing"
                        },
                        new
                        {
                            Id = new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                            Description = "Chilly"
                        });
                });

            modelBuilder.Entity("bernardo_dev.Models.Domain.TicTacToes.Players.Entities.Player", b =>
                {
                    b.HasOne("bernardo_dev.Models.Domain.TicTacToes.Boards.Entities.Board", "Board")
                        .WithMany("Players")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("bernardo_dev.Models.Domain.TicTacToes.Boards.Entities.Board", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
