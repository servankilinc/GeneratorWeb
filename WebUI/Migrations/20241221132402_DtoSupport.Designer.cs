﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUI.Context;

#nullable disable

namespace WebUI.Migrations
{
    [DbContext(typeof(LocalContext))]
    [Migration("20241221132402_DtoSupport")]
    partial class DtoSupport
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WebUI.Models.Dto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RelatedEntityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RelatedEntityId");

                    b.ToTable("Dtos");
                });

            modelBuilder.Entity("WebUI.Models.DtoFieldMap", b =>
                {
                    b.Property<int>("DtoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FieldId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DtoId", "FieldId");

                    b.HasIndex("FieldId");

                    b.ToTable("DtoFieldMaps");
                });

            modelBuilder.Entity("WebUI.Models.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("WebUI.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FieldTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUnique")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("FieldTypeId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("WebUI.Models.FieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FieldTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Int"
                        },
                        new
                        {
                            Id = 2,
                            Name = "String"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Long"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Float"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Double"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bool"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Char"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Byte"
                        },
                        new
                        {
                            Id = 9,
                            Name = "DateTime"
                        },
                        new
                        {
                            Id = 10,
                            Name = "DateOnly"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Guid"
                        });
                });

            modelBuilder.Entity("WebUI.Models.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ForeignFieldId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrimaryFieldId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RelationTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ForeignFieldId");

                    b.HasIndex("PrimaryFieldId");

                    b.HasIndex("RelationTypeId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("WebUI.Models.RelationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RelationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "OnoToOne"
                        },
                        new
                        {
                            Id = 2,
                            Name = "OnoToMany"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ManyToMany"
                        });
                });

            modelBuilder.Entity("WebUI.Models.Dto", b =>
                {
                    b.HasOne("WebUI.Models.Entity", "RelatedEntity")
                        .WithMany("Dtos")
                        .HasForeignKey("RelatedEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelatedEntity");
                });

            modelBuilder.Entity("WebUI.Models.DtoFieldMap", b =>
                {
                    b.HasOne("WebUI.Models.Dto", "Dto")
                        .WithMany("DtoFieldMaps")
                        .HasForeignKey("DtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Models.Field", "Field")
                        .WithMany("DtoFieldMaps")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dto");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("WebUI.Models.Field", b =>
                {
                    b.HasOne("WebUI.Models.Entity", "Entity")
                        .WithMany("Fields")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Models.FieldType", "FieldType")
                        .WithMany("Fields")
                        .HasForeignKey("FieldTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");

                    b.Navigation("FieldType");
                });

            modelBuilder.Entity("WebUI.Models.Relation", b =>
                {
                    b.HasOne("WebUI.Models.Field", "ForeignField")
                        .WithMany("RelationsForeign")
                        .HasForeignKey("ForeignFieldId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebUI.Models.Field", "PrimaryField")
                        .WithMany("RelationsPrimary")
                        .HasForeignKey("PrimaryFieldId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebUI.Models.RelationType", "RelationType")
                        .WithMany("Relations")
                        .HasForeignKey("RelationTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ForeignField");

                    b.Navigation("PrimaryField");

                    b.Navigation("RelationType");
                });

            modelBuilder.Entity("WebUI.Models.Dto", b =>
                {
                    b.Navigation("DtoFieldMaps");
                });

            modelBuilder.Entity("WebUI.Models.Entity", b =>
                {
                    b.Navigation("Dtos");

                    b.Navigation("Fields");
                });

            modelBuilder.Entity("WebUI.Models.Field", b =>
                {
                    b.Navigation("DtoFieldMaps");

                    b.Navigation("RelationsForeign");

                    b.Navigation("RelationsPrimary");
                });

            modelBuilder.Entity("WebUI.Models.FieldType", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("WebUI.Models.RelationType", b =>
                {
                    b.Navigation("Relations");
                });
#pragma warning restore 612, 618
        }
    }
}
