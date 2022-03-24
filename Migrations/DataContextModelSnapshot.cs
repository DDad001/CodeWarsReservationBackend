﻿// <auto-generated />
using CodeWarsReservationBackend.Services.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeWarsReservationBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CodeWarsReservationBackend.Models.CohortModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodeWarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CohortLevelOfDifficulty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CohortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CohortInfo");
                });

            modelBuilder.Entity("CodeWarsReservationBackend.Models.CompletedKatasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodeWarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataRank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataSlug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompletedKatasInfo");
                });

            modelBuilder.Entity("CodeWarsReservationBackend.Models.ReservationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodeWarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KataLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataRank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KataSlug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReservationInfo");
                });

            modelBuilder.Entity("CodeWarsReservationBackend.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodeWarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CohortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
