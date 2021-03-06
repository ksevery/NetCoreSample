﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NetCoreSample.Data;
using System;

namespace NetCoreSample.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20180117152500_Directors")]
    partial class Directors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCoreSample.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MovieID");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MovieID");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("NetCoreSample.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DirectorId");

                    b.Property<string>("Genre");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("NetCoreSample.Models.Director", b =>
                {
                    b.HasOne("NetCoreSample.Models.Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieID");
                });

            modelBuilder.Entity("NetCoreSample.Models.Movie", b =>
                {
                    b.HasOne("NetCoreSample.Models.Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId");
                });
#pragma warning restore 612, 618
        }
    }
}
