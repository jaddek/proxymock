﻿// <auto-generated />
using System;
using Calendario.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Calendario.API.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Calendario.API.Entities.BaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("BaseEntity");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Calendario.API.Entities.Endpoint", b =>
                {
                    b.HasBaseType("Calendario.API.Entities.BaseEntity");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SchemeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SchemeId");

                    b.ToTable("endpoints");
                });

            modelBuilder.Entity("Calendario.API.Entities.Project", b =>
                {
                    b.HasBaseType("Calendario.API.Entities.BaseEntity");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("Calendario.API.Entities.Scheme", b =>
                {
                    b.HasBaseType("Calendario.API.Entities.BaseEntity");

                    b.Property<Guid>("EndpointId")
                        .HasColumnType("uuid");

                    b.Property<string>("JsonData")
                        .HasColumnType("jsonb");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("EndpointId")
                        .IsUnique();

                    b.ToTable("Scheme");
                });

            modelBuilder.Entity("Calendario.API.Entities.Endpoint", b =>
                {
                    b.HasOne("Calendario.API.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Calendario.API.Entities.Endpoint", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Calendario.API.Entities.Project", "Project")
                        .WithMany("Urls")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Calendario.API.Entities.Scheme", "Scheme")
                        .WithMany()
                        .HasForeignKey("SchemeId");

                    b.Navigation("Project");

                    b.Navigation("Scheme");
                });

            modelBuilder.Entity("Calendario.API.Entities.Project", b =>
                {
                    b.HasOne("Calendario.API.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Calendario.API.Entities.Project", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Calendario.API.Entities.Scheme", b =>
                {
                    b.HasOne("Calendario.API.Entities.Endpoint", "Endpoint")
                        .WithOne()
                        .HasForeignKey("Calendario.API.Entities.Scheme", "EndpointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Calendario.API.Entities.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Calendario.API.Entities.Scheme", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endpoint");
                });

            modelBuilder.Entity("Calendario.API.Entities.Project", b =>
                {
                    b.Navigation("Urls");
                });
#pragma warning restore 612, 618
        }
    }
}
