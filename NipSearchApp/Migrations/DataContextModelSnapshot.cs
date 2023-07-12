﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NipSearchApp;

#nullable disable

namespace NipSearchApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NipSearchApp.Models.AccountNumbers", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("subjectId");

                    b.ToTable("AccountNumbers");
                });

            modelBuilder.Entity("NipSearchApp.Models.AuthorizedClerks", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("subjectId");

                    b.ToTable("AuthorizedClerks");
                });

            modelBuilder.Entity("NipSearchApp.Models.Partners", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("subjectId");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("NipSearchApp.Models.Representatives", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("subjectId");

                    b.ToTable("Representatives");
                });

            modelBuilder.Entity("NipSearchApp.Models.Subject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool?>("hasVirtualAccounts")
                        .HasColumnType("bit");

                    b.Property<string>("krs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("registrationDenialBasis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("registrationDenialDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("registrationLegalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("regon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("removalBasis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("removalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("residenceAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("restorationBasis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("restorationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("statusVat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("workingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("NipSearchApp.Models.AccountNumbers", b =>
                {
                    b.HasOne("NipSearchApp.Models.Subject", "subject")
                        .WithMany("accountNumbers")
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subject");
                });

            modelBuilder.Entity("NipSearchApp.Models.AuthorizedClerks", b =>
                {
                    b.HasOne("NipSearchApp.Models.Subject", "subject")
                        .WithMany("authorizedClerks")
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subject");
                });

            modelBuilder.Entity("NipSearchApp.Models.Partners", b =>
                {
                    b.HasOne("NipSearchApp.Models.Subject", "subject")
                        .WithMany("partners")
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subject");
                });

            modelBuilder.Entity("NipSearchApp.Models.Representatives", b =>
                {
                    b.HasOne("NipSearchApp.Models.Subject", "subject")
                        .WithMany("representatives")
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subject");
                });

            modelBuilder.Entity("NipSearchApp.Models.Subject", b =>
                {
                    b.Navigation("accountNumbers");

                    b.Navigation("authorizedClerks");

                    b.Navigation("partners");

                    b.Navigation("representatives");
                });
#pragma warning restore 612, 618
        }
    }
}