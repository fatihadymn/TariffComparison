﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TariffComparison.Data;

namespace TariffComparison.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220427194623_CreateTariffs")]
    partial class CreateTariffs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("tariff_comparison")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TariffComparison.Items.Entities.Tariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("BaseCost")
                        .HasColumnType("money")
                        .HasColumnName("base_cost");

                    b.Property<decimal?>("BaseLimit")
                        .HasColumnType("money")
                        .HasColumnName("base_limit");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_on");

                    b.Property<decimal>("ExtraCost")
                        .HasColumnType("money")
                        .HasColumnName("extra_cost");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int>("Name")
                        .HasColumnType("integer")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.ToTable("tariffs");
                });
#pragma warning restore 612, 618
        }
    }
}