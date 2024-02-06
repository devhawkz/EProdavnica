﻿// <auto-generated />
using EProdavnica.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EProdavnica.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240206230750_SeedPodaciProizvod")]
    partial class SeedPodaciProizvod
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EProdavnica.Shared.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proizvodi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cena = 9.99m,
                            Naziv = "WTL MIG 315",
                            Opis = "Aparat za poluautomatsko zavarivanje u zastiti gasa.",
                            SlikaUrl = "https://www.sualati.com/files/product_picture/2019.07.11.14.16.25_5d272899aaebd_mig315a.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Cena = 15.99m,
                            Naziv = "WTL EASY JOB 200E",
                            Opis = "Savrsen za kucnu upotrebu i lakse radionicke poslove!elektrolucni aparat , za celik i prohron",
                            SlikaUrl = "https://www.sualati.com/files/product_picture/605c73c8ac430_wtl-easy-job-200.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Cena = 5.99m,
                            Naziv = "WTL MIG 350F",
                            Opis = "MIG/MAG Aparat za poluautomatsko zavarivanje u zaštiti gasa u izvedbi sa odvojenim dodvačem žice",
                            SlikaUrl = "https://www.sualati.com/files/product_picture/2019.07.11.14.53.23_5d2731434735b_mig-350-a-wtl.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
