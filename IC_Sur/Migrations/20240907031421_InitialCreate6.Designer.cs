﻿// <auto-generated />
using System;
using IC_Sur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IC_Sur.Migrations
{
    [DbContext(typeof(IC_Sur_Dbcontext))]
    [Migration("20240907031421_InitialCreate6")]
    partial class InitialCreate6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IC_Sur.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MeasurementUnit")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("StorageId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("IC_Sur.Models.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProviderId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers", (string)null);
                });

            modelBuilder.Entity("IC_Sur.Models.Storage", b =>
                {
                    b.Property<int>("StorageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StorageId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StorageId");

                    b.ToTable("Storage", (string)null);
                });

            modelBuilder.Entity("IC_Sur.Models.StorageEntry", b =>
                {
                    b.Property<int>("StorageEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StorageEntryId"));

                    b.Property<DateTime>("EntryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductAmount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProviderId1")
                        .HasColumnType("int");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.HasKey("StorageEntryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("ProviderId1");

                    b.HasIndex("StorageId");

                    b.ToTable("StorageEntries", (string)null);
                });

            modelBuilder.Entity("IC_Sur.Models.Product", b =>
                {
                    b.HasOne("IC_Sur.Models.Provider", "Provider")
                        .WithMany("Products")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IC_Sur.Models.Storage", "Storage")
                        .WithMany("Products")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("IC_Sur.Models.StorageEntry", b =>
                {
                    b.HasOne("IC_Sur.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IC_Sur.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IC_Sur.Models.Provider", null)
                        .WithMany("StorageEntries")
                        .HasForeignKey("ProviderId1");

                    b.HasOne("IC_Sur.Models.Storage", null)
                        .WithMany("StorageEntries")
                        .HasForeignKey("StorageId");

                    b.Navigation("Product");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("IC_Sur.Models.Provider", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("StorageEntries");
                });

            modelBuilder.Entity("IC_Sur.Models.Storage", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("StorageEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
