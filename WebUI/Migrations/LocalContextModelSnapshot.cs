﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUI.Context;

#nullable disable

namespace WebUI.Migrations
{
    [DbContext(typeof(LocalContext))]
    partial class LocalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebUI.Models.Dto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelatedEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RelatedEntityId");

                    b.ToTable("Dtos");
                });

            modelBuilder.Entity("WebUI.Models.DtoField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DtoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceFieldId")
                        .HasColumnType("int");

                    b.Property<int?>("ValidationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DtoId");

                    b.HasIndex("SourceFieldId");

                    b.ToTable("DtoFields");
                });

            modelBuilder.Entity("WebUI.Models.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("WebUI.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("FieldTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsList")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnique")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("FieldTypeId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("WebUI.Models.FieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceTypeId");

                    b.ToTable("FieldTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Int",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "String",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Long",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Float",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Double",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bool",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 7,
                            Name = "Char",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 8,
                            Name = "Byte",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 9,
                            Name = "DateTime",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 10,
                            Name = "DateOnly",
                            SourceTypeId = 1
                        },
                        new
                        {
                            Id = 11,
                            Name = "Guid",
                            SourceTypeId = 1
                        });
                });

            modelBuilder.Entity("WebUI.Models.FieldTypeSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FieldTypeSources");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Base"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Entity"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dto"
                        });
                });

            modelBuilder.Entity("WebUI.Models.Method", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAsync")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReturnMethodFieldId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Methods");
                });

            modelBuilder.Entity("WebUI.Models.MethodArgumentField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FieldTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsList")
                        .HasColumnType("bit");

                    b.Property<int>("MethodId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldTypeId");

                    b.HasIndex("MethodId");

                    b.ToTable("MethodArgumentFields");
                });

            modelBuilder.Entity("WebUI.Models.MethodReturnField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FieldTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsList")
                        .HasColumnType("bit");

                    b.Property<int>("MethodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FieldTypeId")
                        .IsUnique();

                    b.HasIndex("MethodId")
                        .IsUnique();

                    b.ToTable("MethodReturnFields");
                });

            modelBuilder.Entity("WebUI.Models.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ForeignFieldId")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryFieldId")
                        .HasColumnType("int");

                    b.Property<int>("RelationTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ForeignFieldId");

                    b.HasIndex("RelationTypeId");

                    b.HasIndex("PrimaryFieldId", "ForeignFieldId")
                        .IsUnique();

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("WebUI.Models.RelationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        });
                });

            modelBuilder.Entity("WebUI.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RelatedEntityId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceLayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RelatedEntityId");

                    b.HasIndex("ServiceLayerId", "RelatedEntityId")
                        .IsUnique();

                    b.ToTable("Services");
                });

            modelBuilder.Entity("WebUI.Models.ServiceLayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceLayers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Core"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Model"
                        },
                        new
                        {
                            Id = 3,
                            Name = "DataAccess"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Business"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Presentation"
                        });
                });

            modelBuilder.Entity("WebUI.Models.Validation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DtoFieldId")
                        .HasColumnType("int");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValidatorTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DtoFieldId")
                        .IsUnique();

                    b.HasIndex("ValidatorTypeId");

                    b.ToTable("Validations");
                });

            modelBuilder.Entity("WebUI.Models.ValidationParam", b =>
                {
                    b.Property<int>("ValidationId")
                        .HasColumnType("int");

                    b.Property<int>("ValidatorTypeParamId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ValidationId", "ValidatorTypeParamId");

                    b.HasIndex("ValidatorTypeParamId");

                    b.ToTable("ValidationParams");
                });

            modelBuilder.Entity("WebUI.Models.ValidatorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ValidatorTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Field cannot be empty",
                            Name = "NotEmpty"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Field cannot be null",
                            Name = "NotNull"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Field cannot exceed maximum length",
                            Name = "MaxLength"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Value must be within a specific range",
                            Name = "Range"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Field must have a minimum number of characters",
                            Name = "MinLength"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Field must match a regular expression",
                            Name = "Regex"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Value must be greater than a specific number",
                            Name = "GreaterThan"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Value must be less than a specific number",
                            Name = "LessThan"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Field must be a valid email address",
                            Name = "EmailAddress"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Field must be a valid credit card number",
                            Name = "CreditCard"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Field must be a valid phone number",
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Field must be a valid URL",
                            Name = "Url"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Field must be a valid date",
                            Name = "Date"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Field must be a valid number",
                            Name = "Number"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Field mus be a valid guid value",
                            Name = "GuidNotEmpty"
                        });
                });

            modelBuilder.Entity("WebUI.Models.ValidatorTypeParam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValidatorTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ValidatorTypeId");

                    b.ToTable("ValidatorTypeParams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "Max",
                            ValidatorTypeId = 3
                        },
                        new
                        {
                            Id = 2,
                            Key = "Min",
                            ValidatorTypeId = 4
                        },
                        new
                        {
                            Id = 3,
                            Key = "Max",
                            ValidatorTypeId = 4
                        },
                        new
                        {
                            Id = 4,
                            Key = "Min",
                            ValidatorTypeId = 5
                        },
                        new
                        {
                            Id = 5,
                            Key = "Pattern",
                            ValidatorTypeId = 6
                        },
                        new
                        {
                            Id = 6,
                            Key = "Value",
                            ValidatorTypeId = 7
                        },
                        new
                        {
                            Id = 7,
                            Key = "Value",
                            ValidatorTypeId = 8
                        });
                });

            modelBuilder.Entity("WebUI.Models.Dto", b =>
                {
                    b.HasOne("WebUI.Models.Entity", "RelatedEntity")
                        .WithMany("Dtos")
                        .HasForeignKey("RelatedEntityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RelatedEntity");
                });

            modelBuilder.Entity("WebUI.Models.DtoField", b =>
                {
                    b.HasOne("WebUI.Models.Dto", "Dto")
                        .WithMany("DtoFields")
                        .HasForeignKey("DtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Models.Field", "SourceField")
                        .WithMany("DtoFields")
                        .HasForeignKey("SourceFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dto");

                    b.Navigation("SourceField");
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

            modelBuilder.Entity("WebUI.Models.FieldType", b =>
                {
                    b.HasOne("WebUI.Models.FieldTypeSource", "SourceType")
                        .WithMany("FieldTypes")
                        .HasForeignKey("SourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SourceType");
                });

            modelBuilder.Entity("WebUI.Models.Method", b =>
                {
                    b.HasOne("WebUI.Models.Service", "Service")
                        .WithMany("Methods")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("WebUI.Models.MethodArgumentField", b =>
                {
                    b.HasOne("WebUI.Models.FieldType", "FieldType")
                        .WithMany("MethodArgumentFields")
                        .HasForeignKey("FieldTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Models.Method", "Method")
                        .WithMany("ArgumentMethodFields")
                        .HasForeignKey("MethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FieldType");

                    b.Navigation("Method");
                });

            modelBuilder.Entity("WebUI.Models.MethodReturnField", b =>
                {
                    b.HasOne("WebUI.Models.FieldType", "FieldType")
                        .WithMany("MethodReturnFields")
                        .HasForeignKey("FieldTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Models.Method", "Method")
                        .WithOne("ReturnMethodField")
                        .HasForeignKey("WebUI.Models.MethodReturnField", "FieldTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FieldType");

                    b.Navigation("Method");
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ForeignField");

                    b.Navigation("PrimaryField");

                    b.Navigation("RelationType");
                });

            modelBuilder.Entity("WebUI.Models.Service", b =>
                {
                    b.HasOne("WebUI.Models.Entity", "RelatedEntity")
                        .WithMany("Services")
                        .HasForeignKey("RelatedEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Models.ServiceLayer", "ServiceLayer")
                        .WithMany("Services")
                        .HasForeignKey("ServiceLayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelatedEntity");

                    b.Navigation("ServiceLayer");
                });

            modelBuilder.Entity("WebUI.Models.Validation", b =>
                {
                    b.HasOne("WebUI.Models.DtoField", "DtoField")
                        .WithOne("Validation")
                        .HasForeignKey("WebUI.Models.Validation", "DtoFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Models.ValidatorType", "ValidatorType")
                        .WithMany("Validations")
                        .HasForeignKey("ValidatorTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DtoField");

                    b.Navigation("ValidatorType");
                });

            modelBuilder.Entity("WebUI.Models.ValidationParam", b =>
                {
                    b.HasOne("WebUI.Models.Validation", "Validation")
                        .WithMany("ValidationParams")
                        .HasForeignKey("ValidationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Models.ValidatorTypeParam", "ValidatorTypeParam")
                        .WithMany("ValidationParams")
                        .HasForeignKey("ValidatorTypeParamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Validation");

                    b.Navigation("ValidatorTypeParam");
                });

            modelBuilder.Entity("WebUI.Models.ValidatorTypeParam", b =>
                {
                    b.HasOne("WebUI.Models.ValidatorType", "ValidatorType")
                        .WithMany("ValidatorTypeParams")
                        .HasForeignKey("ValidatorTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ValidatorType");
                });

            modelBuilder.Entity("WebUI.Models.Dto", b =>
                {
                    b.Navigation("DtoFields");
                });

            modelBuilder.Entity("WebUI.Models.DtoField", b =>
                {
                    b.Navigation("Validation");
                });

            modelBuilder.Entity("WebUI.Models.Entity", b =>
                {
                    b.Navigation("Dtos");

                    b.Navigation("Fields");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("WebUI.Models.Field", b =>
                {
                    b.Navigation("DtoFields");

                    b.Navigation("RelationsForeign");

                    b.Navigation("RelationsPrimary");
                });

            modelBuilder.Entity("WebUI.Models.FieldType", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("MethodArgumentFields");

                    b.Navigation("MethodReturnFields");
                });

            modelBuilder.Entity("WebUI.Models.FieldTypeSource", b =>
                {
                    b.Navigation("FieldTypes");
                });

            modelBuilder.Entity("WebUI.Models.Method", b =>
                {
                    b.Navigation("ArgumentMethodFields");

                    b.Navigation("ReturnMethodField");
                });

            modelBuilder.Entity("WebUI.Models.RelationType", b =>
                {
                    b.Navigation("Relations");
                });

            modelBuilder.Entity("WebUI.Models.Service", b =>
                {
                    b.Navigation("Methods");
                });

            modelBuilder.Entity("WebUI.Models.ServiceLayer", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("WebUI.Models.Validation", b =>
                {
                    b.Navigation("ValidationParams");
                });

            modelBuilder.Entity("WebUI.Models.ValidatorType", b =>
                {
                    b.Navigation("Validations");

                    b.Navigation("ValidatorTypeParams");
                });

            modelBuilder.Entity("WebUI.Models.ValidatorTypeParam", b =>
                {
                    b.Navigation("ValidationParams");
                });
#pragma warning restore 612, 618
        }
    }
}
