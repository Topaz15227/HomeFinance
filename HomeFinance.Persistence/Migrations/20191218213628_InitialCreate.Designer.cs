﻿// <auto-generated />
using System;
using HomeFinance.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeFinance.Persistence.Migrations
{
    [DbContext(typeof(HomeFinanceDbContext))]
    [Migration("20191218213628_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeFinance.Domain.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("CardDescription")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ClosingName")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("HomeFinance.Domain.Entities.Closing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId");

                    b.Property<decimal>("ClosingAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("date");

                    b.Property<string>("ClosingName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("Closings");
                });

            modelBuilder.Entity("HomeFinance.Domain.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("HomeFinance.Domain.Entities.StorePay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("CardId");

                    b.Property<int?>("ClosingId");

                    b.Property<string>("Note")
                        .HasMaxLength(45);

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("date");

                    b.Property<int>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("ClosingId");

                    b.HasIndex("StoreId");

                    b.ToTable("StorePays");
                });

            modelBuilder.Entity("HomeFinance.Domain.Entities.Closing", b =>
                {
                    b.HasOne("HomeFinance.Domain.Entities.Card", "Card")
                        .WithMany("Closings")
                        .HasForeignKey("CardId")
                        .HasConstraintName("FK_Closings_Cards")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeFinance.Domain.Entities.StorePay", b =>
                {
                    b.HasOne("HomeFinance.Domain.Entities.Card", "Card")
                        .WithMany("StorePays")
                        .HasForeignKey("CardId")
                        .HasConstraintName("FK_StorePays_Cards")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeFinance.Domain.Entities.Closing", "Closing")
                        .WithMany("StorePays")
                        .HasForeignKey("ClosingId")
                        .HasConstraintName("FK_StorePays_Closings");

                    b.HasOne("HomeFinance.Domain.Entities.Store", "Store")
                        .WithMany("StorePays")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK_StorePays_Stores")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
