﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210521194451_w")]
    partial class w
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Admin")
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Home.HomeModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("WebApplication1.Models.QuiSommeNous.ArticlePresentation.Paragraph", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParagraphContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("WebApplication1.Models.QuiSommeNous.ArticlePresentation.Parallex", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parallex");
                });

            modelBuilder.Entity("WebApplication1.Models.QuiSommeNous.ArticlePresentation.Section", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParallexId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ParallexId");

                    b.ToTable("PresnetationSections");
                });

            modelBuilder.Entity("WebApplication1.Models.QuiSommeNous.ArticlePresentation.Paragraph", b =>
                {
                    b.HasOne("WebApplication1.Models.QuiSommeNous.ArticlePresentation.Section", null)
                        .WithMany("ListOfParagraphs")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("WebApplication1.Models.QuiSommeNous.ArticlePresentation.Section", b =>
                {
                    b.HasOne("WebApplication1.Models.QuiSommeNous.ArticlePresentation.Parallex", "Parallex")
                        .WithMany()
                        .HasForeignKey("ParallexId");
                });
#pragma warning restore 612, 618
        }
    }
}
