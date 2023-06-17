﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoccerStatsNew.Data;

#nullable disable

namespace SoccerStatsNew.Migrations
{
    [DbContext(typeof(SoccerStatsDbContext))]
    [Migration("20230617205216_InitalMigration")]
    partial class InitalMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoccerStatsNew.Models.CountryModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlagURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("CountryModel");
                });

            modelBuilder.Entity("SoccerStatsNew.Models.LeagueModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("LeagueModel");
                });

            modelBuilder.Entity("SoccerStatsNew.Models.SeasonModel", b =>
                {
                    b.Property<string>("SeasonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("Injuries")
                        .HasColumnType("bit");

                    b.Property<bool>("Odds")
                        .HasColumnType("bit");

                    b.Property<bool>("Players")
                        .HasColumnType("bit");

                    b.Property<bool>("Predictions")
                        .HasColumnType("bit");

                    b.Property<bool>("Standings")
                        .HasColumnType("bit");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TopAssists")
                        .HasColumnType("bit");

                    b.Property<bool>("TopCards")
                        .HasColumnType("bit");

                    b.Property<bool>("TopScorers")
                        .HasColumnType("bit");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SeasonId");

                    b.HasIndex("CountryName");

                    b.HasIndex("Id");

                    b.ToTable("SeasonModel");
                });

            modelBuilder.Entity("SoccerStatsNew.Models.TeamModel", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Founded")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("National")
                        .HasColumnType("bit");

                    b.Property<int?>("StadiumId")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.HasIndex("StadiumId");

                    b.ToTable("TeamModel");
                });

            modelBuilder.Entity("SoccerStatsNew.Models.VenuesModel", b =>
                {
                    b.Property<int>("StadiumId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surface")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StadiumId");

                    b.ToTable("VenuesModel");
                });

            modelBuilder.Entity("SoccerStatsNew.Models.LeagueModel", b =>
                {
                    b.HasOne("SoccerStatsNew.Models.CountryModel", "Country")
                        .WithMany()
                        .HasForeignKey("Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SoccerStatsNew.Models.SeasonModel", b =>
                {
                    b.HasOne("SoccerStatsNew.Models.CountryModel", "Country")
                        .WithMany()
                        .HasForeignKey("CountryName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerStatsNew.Models.LeagueModel", "League")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("League");
                });

            modelBuilder.Entity("SoccerStatsNew.Models.TeamModel", b =>
                {
                    b.HasOne("SoccerStatsNew.Models.VenuesModel", "VenueModel")
                        .WithMany()
                        .HasForeignKey("StadiumId");

                    b.Navigation("VenueModel");
                });
#pragma warning restore 612, 618
        }
    }
}
