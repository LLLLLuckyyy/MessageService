﻿// <auto-generated />
using System;
using MessageService.Resources.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageService.Resources.Api.Migrations
{
    [DbContext(typeof(MessageContext))]
    partial class MessageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MessageService.Resources.Api.Models.InfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryGetSentFrom")
                        .HasColumnType("int");

                    b.Property<int>("CountryGetSentTo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateGetSentFrom")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PricePerMessage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SendModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SendModelId")
                        .IsUnique();

                    b.ToTable("InfoModels");
                });

            modelBuilder.Entity("MessageService.Resources.Api.Models.SendModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountSid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumberFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumberTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SendModels");
                });

            modelBuilder.Entity("MessageService.Resources.Api.Models.InfoModel", b =>
                {
                    b.HasOne("MessageService.Resources.Api.Models.SendModel", null)
                        .WithOne("InfoModel")
                        .HasForeignKey("MessageService.Resources.Api.Models.InfoModel", "SendModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
