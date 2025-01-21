﻿using Microsoft.EntityFrameworkCore;
using WebUI.Models;

namespace WebUI.Context
{
    public class LocalContext: DbContext
    {
        public LocalContext(DbContextOptions<LocalContext> options) : base(options)
        {
        }

        public DbSet<Entity> Entities { get; set; }

        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<FieldTypeSource> FieldTypeSources { get; set; }

        public DbSet<Relation> Relations { get; set; }
        public DbSet<RelationType> RelationTypes { get; set; }

        public DbSet<Dto> Dtos { get; set; }
        public DbSet<DtoField> DtoFields { get; set; }

        public DbSet<Validation> Validations { get; set; }
        public DbSet<ValidationParam> ValidationParams { get; set; }
        public DbSet<ValidatorType> ValidatorTypes { get; set; }
        public DbSet<ValidatorTypeParam> ValidatorTypeParams { get; set; }

        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceLayer> ServiceLayers { get; set; }

        public DbSet<Method> Methods { get; set; }
        public DbSet<MethodArgumentField> MethodArgumentFields { get; set; }
        public DbSet<MethodReturnField> MethodReturnFields { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Entity
            modelBuilder.Entity<Entity>(e =>
            {
                e.HasKey(e => e.Id);


                e.HasMany(e => e.Fields)
                    .WithOne(f => f.Entity)
                    .HasForeignKey(f => f.EntityId);

                e.HasMany(e => e.Dtos)
                    .WithOne(f => f.RelatedEntity)
                    .HasForeignKey(f => f.RelatedEntityId);

                e.HasMany(e => e.Services)
                    .WithOne(s => s.RelatedEntity)
                    .HasForeignKey(s => s.RelatedEntityId);
            });

            // Field, FieldType
            modelBuilder.Entity<Field>(f =>
            {
                f.HasKey(f => f.Id);

                f.HasOne(f => f.Entity)
                   .WithMany(e => e.Fields)
                   .HasForeignKey(f => f.EntityId);

                f.HasOne(f => f.FieldType)
                    .WithMany(t => t.Fields)
                    .HasForeignKey(f => f.FieldTypeId);

                f.HasMany(f => f.RelationsPrimary)
                    .WithOne(r => r.PrimaryField)
                    .HasForeignKey(f => f.PrimaryFieldId)
                    .OnDelete(DeleteBehavior.Restrict);

                f.HasMany(f => f.RelationsForeign)
                    .WithOne(r => r.ForeignField)
                    .HasForeignKey(f => f.ForeignFieldId)
                    .OnDelete(DeleteBehavior.Restrict);

                f.HasMany(f => f.DtoFields)
                    .WithOne(df => df.SourceField)
                    .HasForeignKey(df => df.SourceFieldId);
            });

            modelBuilder.Entity<FieldType>(ft =>
            {
                ft.HasKey(ft => ft.Id);

                ft.HasOne(ft => ft.SourceType)
                    .WithMany(fts => fts.FieldTypes)
                    .HasForeignKey(ft => ft.SourceTypeId);

                ft.HasMany(ft => ft.Fields)
                    .WithOne(f => f.FieldType)
                    .HasForeignKey(f => f.FieldTypeId);

                ft.HasMany(ft => ft.MethodArgumentFields)
                    .WithOne(maf => maf.FieldType)
                    .HasForeignKey(f => f.FieldTypeId);

                ft.HasMany(ft => ft.MethodReturnFields)
                    .WithOne(mrf => mrf.FieldType)
                    .HasForeignKey(f => f.FieldTypeId);

                ft.HasData(
                   new FieldType { Id = 1, Name = "Int", SourceTypeId = 1 },
                   new FieldType { Id = 2, Name = "String", SourceTypeId = 1 },
                   new FieldType { Id = 3, Name = "Long", SourceTypeId = 1 },
                   new FieldType { Id = 4, Name = "Float", SourceTypeId = 1 },
                   new FieldType { Id = 5, Name = "Double", SourceTypeId = 1 },
                   new FieldType { Id = 6, Name = "Bool", SourceTypeId = 1 },
                   new FieldType { Id = 7, Name = "Char", SourceTypeId = 1 },
                   new FieldType { Id = 8, Name = "Byte", SourceTypeId = 1 },
                   new FieldType { Id = 9, Name = "DateTime", SourceTypeId = 1 },
                   new FieldType { Id = 10, Name = "DateOnly", SourceTypeId = 1 },
                   new FieldType { Id = 11, Name = "Guid", SourceTypeId = 1 }
                );
            });

            modelBuilder.Entity<FieldTypeSource>(fts =>
            {
                fts.HasKey(fts => fts.Id);

                fts.HasMany(fts => fts.FieldTypes)
                    .WithOne(ft => ft.SourceType)
                    .HasForeignKey(ft => ft.SourceTypeId);

                fts.HasData(
                     new RelationType { Id = 1, Name = "Base" },
                     new RelationType { Id = 2, Name = "Entity" },
                     new RelationType { Id = 3, Name = "Dto" }
                );
            });

            // Relation, RelationType
            modelBuilder.Entity<Relation>(r =>
            {
                r.HasKey(r => r.Id);

                r.HasIndex(r => new { r.PrimaryFieldId, r.ForeignFieldId }).IsUnique();

                r.HasOne(r => r.PrimaryField)
                    .WithMany(f => f.RelationsPrimary)
                    .HasForeignKey(r => r.PrimaryFieldId);
                //.OnDelete(DeleteBehavior.Restrict);

                r.HasOne(r => r.ForeignField)
                    .WithMany(f => f.RelationsForeign)
                    .HasForeignKey(r => r.ForeignFieldId);
                //.OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullanıldı.

                r.HasOne(r => r.RelationType)
                    .WithMany(rt => rt.Relations)
                    .HasForeignKey(r => r.RelationTypeId);
                //.OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullanıldı.
            });

            modelBuilder.Entity<RelationType>(rt =>
            {
                rt.HasKey(rt => rt.Id);

                rt.HasMany(rt => rt.Relations)
                    .WithOne(r => r.RelationType)
                    .HasForeignKey(r => r.RelationTypeId);

                rt.HasData(
                    new RelationType { Id = 1, Name = "OnoToOne" },
                    new RelationType { Id = 2, Name = "OnoToMany" }
                );
            });

            // Dto, DtoField
            modelBuilder.Entity<Dto>(d =>
            {
                d.HasKey(d => d.Id);

                d.HasOne(d => d.RelatedEntity)
                    .WithMany(r => r.Dtos)
                    .HasForeignKey(r => r.RelatedEntityId)
                    .OnDelete(DeleteBehavior.Restrict);

                d.HasMany(d => d.DtoFields)
                    .WithOne(r => r.Dto)
                    .HasForeignKey(r => r.DtoId);
            });

            modelBuilder.Entity<DtoField>(df =>
            {
                df.HasKey(df => df.Id);


                df.HasOne(df => df.Dto)
                   .WithMany(f => f.DtoFields)
                   .HasForeignKey(df => df.DtoId);

                df.HasOne(df => df.SourceField)
                   .WithMany(f => f.DtoFields)
                   .HasForeignKey(df => df.SourceFieldId);

                df.HasOne(df => df.Validation)
                   .WithOne(v => v.DtoField)
                   .HasForeignKey<DtoField>(df => df.ValidationId);
            });

            // Validation, ValidationParam, ValidatorType, ValidatorTypeParam
            modelBuilder.Entity<Validation>(v =>
            {
                v.HasKey(v => v.Id);

                //v.HasIndex(v => v.DtoFieldId ).IsUnique();

                v.HasOne(v => v.DtoField)
                    .WithOne(df => df.Validation)
                    .HasForeignKey<Validation>(v => v.DtoFieldId);

                v.HasOne(v => v.ValidatorType)
                    .WithMany(vt => vt.Validations)
                    .HasForeignKey(v => v.ValidatorTypeId);

                v.HasMany(v => v.ValidationParams)
                    .WithOne(vp => vp.Validation)
                    .HasForeignKey(vp => vp.ValidationId);
            });

            modelBuilder.Entity<ValidationParam>(vp =>
            {
                vp.HasKey(vp => new { vp.ValidationId, vp.ValidatorTypeParamId });

                vp.HasOne(vp => vp.Validation)
                    .WithMany(v => v.ValidationParams)
                    .HasForeignKey(v => v.ValidationId);

                vp.HasOne(vp => vp.ValidatorTypeParam)
                    .WithMany(vtp => vtp.ValidationParams)
                    .HasForeignKey(v => v.ValidatorTypeParamId);
            });

            modelBuilder.Entity<ValidatorType>(vt =>
            {
                vt.HasKey(vt => vt.Id);

                vt.HasMany(vt => vt.Validations)
                    .WithOne(v => v.ValidatorType)
                    .HasForeignKey(v => v.ValidatorTypeId);

                vt.HasMany(vt => vt.ValidatorTypeParams)
                    .WithOne(vtp => vtp.ValidatorType)
                    .HasForeignKey(vtp => vtp.ValidatorTypeId)
                    .OnDelete(DeleteBehavior.Restrict);


                vt.HasData(
                    new ValidatorType { Id = 1, Name = "NotEmpty", Description = "Field cannot be empty" },
                    new ValidatorType { Id = 2, Name = "NotNull", Description = "Field cannot be null" },
                    new ValidatorType { Id = 3, Name = "MaxLength", Description = "Field cannot exceed maximum length" },
                    new ValidatorType { Id = 4, Name = "Range", Description = "Value must be within a specific range" },
                    new ValidatorType { Id = 5, Name = "MinLength", Description = "Field must have a minimum number of characters" },
                    new ValidatorType { Id = 6, Name = "Regex", Description = "Field must match a regular expression" },
                    new ValidatorType { Id = 7, Name = "GreaterThan", Description = "Value must be greater than a specific number" },
                    new ValidatorType { Id = 8, Name = "LessThan", Description = "Value must be less than a specific number" },
                    new ValidatorType { Id = 9, Name = "EmailAddress", Description = "Field must be a valid email address" },
                    new ValidatorType { Id = 10, Name = "CreditCard", Description = "Field must be a valid credit card number" },
                    new ValidatorType { Id = 11, Name = "Phone", Description = "Field must be a valid phone number" },
                    new ValidatorType { Id = 12, Name = "Url", Description = "Field must be a valid URL" },
                    new ValidatorType { Id = 13, Name = "Date", Description = "Field must be a valid date" },
                    new ValidatorType { Id = 14, Name = "Number", Description = "Field must be a valid number" },
                    new ValidatorType { Id = 15, Name = "GuidNotEmpty", Description = "Field mus be a valid guid value" }
                );
            });

            modelBuilder.Entity<ValidatorTypeParam>(vtp =>
            {
                vtp.HasKey(vt => vt.Id);

                vtp.HasOne(vtp => vtp.ValidatorType)
                    .WithMany(v => v.ValidatorTypeParams)
                    .HasForeignKey(vtp => vtp.ValidatorTypeId);

                vtp.HasMany(vtp => vtp.ValidationParams)
                    .WithOne(vp => vp.ValidatorTypeParam)
                    .HasForeignKey(vp => vp.ValidatorTypeParamId);

                vtp.HasData(
                    // NotEmpty Validator (no additional params needed)
                    // NotNull Validator (no additional params needed)
                    // MaxLength Validator max
                    new ValidatorTypeParam { Id = 1, ValidatorTypeId = 3, Key = "Max" },
                    // Range Validator min, max
                    new ValidatorTypeParam { Id = 2, ValidatorTypeId = 4, Key = "Min" },
                    new ValidatorTypeParam { Id = 3, ValidatorTypeId = 4, Key = "Max" },
                    // MinLength Validator min
                    new ValidatorTypeParam { Id = 4, ValidatorTypeId = 5, Key = "Min" },
                    // Regex Validator pattern
                    new ValidatorTypeParam { Id = 5, ValidatorTypeId = 6, Key = "Pattern" },
                    // GreaterThan Validator
                    new ValidatorTypeParam { Id = 6, ValidatorTypeId = 7, Key = "Value" },
                    // LessThan Validator
                    new ValidatorTypeParam { Id = 7, ValidatorTypeId = 8, Key = "Value" }
                    // EmailAddress Validator (no additional params needed)
                    // CreditCard Validator (no additional params needed)
                    // Phone Validator (no additional params needed)
                    // Url Validator (no additional params needed)
                    // Date Validator (no additional params needed)
                    // Number Validator (no additional params needed)
                    // GuidNotEmpty Validator (no additional params needed)
                );
            });

            // Service, ServiceLayer
            modelBuilder.Entity<Service>(s =>
            {
                s.HasKey(s => s.Id);

                s.HasIndex(s => new { s.ServiceLayerId, s.RelatedEntityId }).IsUnique();

                s.HasOne(s => s.ServiceLayer)
                    .WithMany(sl => sl.Services)
                    .HasForeignKey(s => s.ServiceLayerId);

                s.HasOne(s => s.RelatedEntity)
                    .WithMany(e => e.Services)
                    .HasForeignKey(s => s.RelatedEntityId);
            });

            modelBuilder.Entity<ServiceLayer>(sl =>
            {
                sl.HasKey(sl => sl.Id);

                sl.HasMany(sl => sl.Services)
                    .WithOne(s => s.ServiceLayer)
                    .HasForeignKey(s => s.ServiceLayerId);

                sl.HasData(
                    new ServiceLayer { Id = 1, Name = "Core" },
                    new ServiceLayer { Id = 2, Name = "Model" },
                    new ServiceLayer { Id = 3, Name = "DataAccess" },
                    new ServiceLayer { Id = 4, Name = "Business" },
                    new ServiceLayer { Id = 5, Name = "Presentation" }
                );
            });

            // Method, MethodArgumentField, MethodReturnField
            modelBuilder.Entity<Method>(m =>
            {
                m.HasKey(m => m.Id);

                m.HasOne(m => m.Service)
                    .WithMany(s => s.Methods)
                    .HasForeignKey(m => m.ServiceId);

                m.HasOne(m => m.ReturnMethodField)
                    .WithOne(rmf => rmf.Method)
                    .HasForeignKey<Method>(m => m.ReturnMethodFieldId);

                m.HasMany(m => m.ArgumentMethodFields)
                    .WithOne(amf => amf.Method)
                    .HasForeignKey(m => m.MethodId);
            });

            modelBuilder.Entity<MethodArgumentField>(maf =>
            {
                maf.HasKey(maf => maf.Id);

                maf.HasOne(maf => maf.Method)
                    .WithMany(m => m.ArgumentMethodFields)
                    .HasForeignKey(maf => maf.MethodId);

                maf.HasOne(maf => maf.FieldType)
                    .WithMany(ft => ft.MethodArgumentFields)
                    .HasForeignKey(maf => maf.FieldTypeId);
            });

            modelBuilder.Entity<MethodReturnField>(mrf =>
            {
                mrf.HasKey(mrf => mrf.Id);

                mrf.HasIndex(mrf => mrf.MethodId).IsUnique();


                mrf.HasOne(mrf => mrf.Method)
                    .WithOne(m => m.ReturnMethodField)
                    .HasForeignKey<MethodReturnField>(mrf => mrf.FieldTypeId);

                mrf.HasOne(mrf => mrf.FieldType)
                    .WithMany(ft => ft.MethodReturnFields)
                    .HasForeignKey(mrf => mrf.FieldTypeId);
            });
        }
    }
}
