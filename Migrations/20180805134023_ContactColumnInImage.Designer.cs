﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWarsForever.UnitOfWork;

namespace StarWarsForever.Migrations
{
    [DbContext(typeof(StarDbContext))]
    [Migration("20180805134023_ContactColumnInImage")]
    partial class ContactColumnInImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StarWarsForever.Core.Model.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate");

                    b.Property<bool>("IsDisplayed");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("ProfileImageId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileImageId")
                        .IsUnique()
                        .HasFilter("[ProfileImageId] IS NOT NULL");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("StarWarsForever.Core.Model.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactId");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("StarWarsForever.Core.Model.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("StarWarsForever.Core.Model.Contact", b =>
                {
                    b.HasOne("StarWarsForever.Core.Model.Image", "ProfileImage")
                        .WithOne()
                        .HasForeignKey("StarWarsForever.Core.Model.Contact", "ProfileImageId");
                });

            modelBuilder.Entity("StarWarsForever.Core.Model.Image", b =>
                {
                    b.HasOne("StarWarsForever.Core.Model.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("StarWarsForever.Core.Model.Weapon", b =>
                {
                    b.HasOne("StarWarsForever.Core.Model.Contact", "Contact")
                        .WithMany("Weapons")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
