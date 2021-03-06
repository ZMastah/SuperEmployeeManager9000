﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperEmployeeManager9000.Models;

namespace SuperEmployeeManager9000.Migrations
{
    [DbContext(typeof(SuperEmployeeManager9000Context))]
    [Migration("20181025094929_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperEmployeeManager9000.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateHired");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("Salary");

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
