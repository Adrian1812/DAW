﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectDAW.DAL;

namespace ProiectDAW.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220124142038_Added")]
    partial class Added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DealerId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Address", b =>
                {
                    b.HasOne("ProiectDAW.DAL.Entities.Dealer", "Dealer")
                        .WithOne("Address")
                        .HasForeignKey("ProiectDAW.DAL.Entities.Address", "DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Order", b =>
                {
                    b.HasOne("ProiectDAW.DAL.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectDAW.DAL.Entities.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Product", b =>
                {
                    b.HasOne("ProiectDAW.DAL.Entities.Dealer", "Dealer")
                        .WithMany("Products")
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Dealer", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProiectDAW.DAL.Entities.Product", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
