﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RaythosAerospace101.Data;

namespace RaythosAerospace101.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231209073345_addSPareParts")]
    partial class addSPareParts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("RaythosAerospace101.Models.CustomizedPlane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CurrentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FloorPlanId")
                        .HasColumnType("int");

                    b.Property<int>("OverallStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PlaneDesignSchemeId")
                        .HasColumnType("int");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FloorPlanId");

                    b.HasIndex("OverallStatusId");

                    b.HasIndex("PlaneDesignSchemeId");

                    b.HasIndex("PlaneId");

                    b.HasIndex("UserEmail");

                    b.ToTable("CustomizedPlanes");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.FloorPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Persons")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FloorPlans");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.InvInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("currDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.HasIndex("UserEmail");

                    b.ToTable("InvInvoice");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("SparePartId")
                        .HasColumnType("int");

                    b.Property<int>("qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SparePartId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.OverallStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OverallStatus");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Baggage")
                        .HasColumnType("float");

                    b.Property<double>("Distant")
                        .HasColumnType("float");

                    b.Property<string>("Heading1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Heading2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Mach")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Para1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Para2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.PlaneDesignScheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlaneDesignSchemes");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.SparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SparePart");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UsrStatusId")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.HasIndex("RoleId");

                    b.HasIndex("UsrStatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.UserStatus", b =>
                {
                    b.Property<int>("UsrStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UsrStatusValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsrStatusId");

                    b.ToTable("UserStatus");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.CustomizedPlane", b =>
                {
                    b.HasOne("RaythosAerospace101.Models.FloorPlan", "FloorPlan")
                        .WithMany("CustomizedPlanes")
                        .HasForeignKey("FloorPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaythosAerospace101.Models.OverallStatus", "OverallStatus")
                        .WithMany("CustomizedPlanes")
                        .HasForeignKey("OverallStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaythosAerospace101.Models.PlaneDesignScheme", "PlaneDesignScheme")
                        .WithMany("CustomizedPlanes")
                        .HasForeignKey("PlaneDesignSchemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaythosAerospace101.Models.Plane", "Plane")
                        .WithMany("CustomizedPlanes")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaythosAerospace101.Models.User", "User")
                        .WithMany("CustomizedPlanes")
                        .HasForeignKey("UserEmail");

                    b.Navigation("FloorPlan");

                    b.Navigation("OverallStatus");

                    b.Navigation("Plane");

                    b.Navigation("PlaneDesignScheme");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.InvInvoice", b =>
                {
                    b.HasOne("RaythosAerospace101.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaythosAerospace101.Models.User", "User")
                        .WithMany("InvInvoices")
                        .HasForeignKey("UserEmail");

                    b.Navigation("Inventory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.Inventory", b =>
                {
                    b.HasOne("RaythosAerospace101.Models.SparePart", "SpareParts")
                        .WithMany("InventoryItems")
                        .HasForeignKey("SparePartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.User", b =>
                {
                    b.HasOne("RaythosAerospace101.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaythosAerospace101.Models.UserStatus", "UserStatus")
                        .WithMany("Users")
                        .HasForeignKey("UsrStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");

                    b.Navigation("UserStatus");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.FloorPlan", b =>
                {
                    b.Navigation("CustomizedPlanes");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.OverallStatus", b =>
                {
                    b.Navigation("CustomizedPlanes");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.Plane", b =>
                {
                    b.Navigation("CustomizedPlanes");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.PlaneDesignScheme", b =>
                {
                    b.Navigation("CustomizedPlanes");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.SparePart", b =>
                {
                    b.Navigation("InventoryItems");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.User", b =>
                {
                    b.Navigation("CustomizedPlanes");

                    b.Navigation("InvInvoices");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RaythosAerospace101.Models.UserStatus", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
