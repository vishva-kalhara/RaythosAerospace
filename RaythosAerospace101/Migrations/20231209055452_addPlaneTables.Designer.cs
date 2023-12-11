﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RaythosAerospace101.Data;

namespace RaythosAerospace101.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231209055452_addPlaneTables")]
    partial class addPlaneTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

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
