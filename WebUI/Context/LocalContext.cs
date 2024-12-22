using Microsoft.EntityFrameworkCore;
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
        public DbSet<Relation> Relations { get; set; }
        public DbSet<RelationType> RelationTypes { get; set; }
        public DbSet<Dto> Dtos { get; set; }
        public DbSet<DtoField> DtoFields { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Entity>(e =>
            { 
                e.HasKey(e => e.Id);

                e.HasMany(e => e.Fields)
                .WithOne(f => f.Entity)
                .HasForeignKey(f => f.EntityId);


                e.HasMany(e => e.Dtos)
                .WithOne(f => f.RelatedEntity)
                .HasForeignKey(f => f.RelatedEntityId);
            });

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
                    .HasForeignKey(f => f.PrimaryFieldId);
                
                f.HasMany(f => f.RelationsForeign)
                    .WithOne(r => r.ForeignField)
                    .HasForeignKey(f => f.ForeignFieldId);

                f.HasMany(f => f.DtoFields)
                    .WithOne(df => df.SourceField)
                    .HasForeignKey(df => df.SourceFieldId);
            });

            modelBuilder.Entity<FieldType>(ft =>
            {
                ft.HasKey(ft => ft.Id);

                ft.HasMany(ft => ft.Fields)
                    .WithOne(f => f.FieldType)
                    .HasForeignKey(f => f.FieldTypeId);

                ft.HasData(
                   new FieldType { Id = 1, Name = "Int" },
                   new FieldType { Id = 2, Name = "String" },
                   new FieldType { Id = 3, Name = "Long" },
                   new FieldType { Id = 4, Name = "Float" },
                   new FieldType { Id = 5, Name = "Double" },
                   new FieldType { Id = 6, Name = "Bool" },
                   new FieldType { Id = 7, Name = "Char" },
                   new FieldType { Id = 8, Name = "Byte" },
                   new FieldType { Id = 9, Name = "DateTime" },
                   new FieldType { Id = 10, Name = "DateOnly" },
                   new FieldType { Id = 11, Name = "Guid" }
                ); 
            });

            modelBuilder.Entity<Relation>(r =>
            {
                r.HasKey(r => r.Id);

                r.HasOne(r => r.PrimaryField)
                    .WithMany(f => f.RelationsPrimary)
                    .HasForeignKey(r => r.PrimaryFieldId)
                    .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullanıldı.

                r.HasOne(r => r.ForeignField)
                    .WithMany(f => f.RelationsForeign)
                    .HasForeignKey(r => r.ForeignFieldId)
                    .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullanıldı.

                r.HasOne(r => r.RelationType)
                    .WithMany(rt => rt.Relations)
                    .HasForeignKey(r => r.RelationTypeId)
                    .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict kullanıldı.
            });

            modelBuilder.Entity<RelationType>(rt =>
            {
                rt.HasKey(rt => rt.Id);

                rt.HasMany(rt => rt.Relations)
                    .WithOne(r => r.RelationType)
                    .HasForeignKey(r => r.RelationTypeId);

                rt.HasData(
                    new RelationType { Id = 1, Name = "OnoToOne" },
                    new RelationType { Id = 2, Name = "OnoToMany" },
                    new RelationType { Id = 3, Name = "ManyToMany" }
                );
            });

            modelBuilder.Entity<Dto>(d=>
            {
                d.HasKey(d => d.Id);


                d.HasOne(d => d.RelatedEntity)
                    .WithMany(r => r.Dtos)
                    .HasForeignKey(r => r.RelatedEntityId);

                d.HasMany(d => d.DtoFields)
                    .WithOne(r => r.Dto)
                    .HasForeignKey(r => r.DtoId);
            });

            modelBuilder.Entity<DtoField>(dfm =>
            {
                dfm.HasKey(dfm => new { dfm.DtoId, dfm.SourceFieldId });

                dfm.HasOne(dfm => dfm.SourceField)
                   .WithMany(f => f.DtoFields)
                   .HasForeignKey(dfm => dfm.SourceFieldId);

                dfm.HasOne(dfm => dfm.Dto)
                   .WithMany(f => f.DtoFields)
                   .HasForeignKey(dfm => dfm.DtoId);
            });
        }
    }
}
