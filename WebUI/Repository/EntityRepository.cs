using Microsoft.EntityFrameworkCore;
using WebUI.Context;
using WebUI.Dtos._Relation;
using WebUI.Dtos._Entity;
using WebUI.Dtos._Field;
using WebUI.Models;
using WebUI.Dtos._FieldType;
using Microsoft.AspNetCore.Http.HttpResults;
using WebUI.ViewModels.Entity;
using WebUI.Models.Enums;

namespace WebUI.Repository
{
    public class EntityRepository : EFRepositoryBase<Entity>
    {
        private readonly LocalContext _context;
        public EntityRepository(LocalContext context) : base(context)
        {
            _context = context;
        }

        public void AddByDto(VMEntityCreate createDto)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var entityToInsert = new Entity
                {
                    Name = createDto.FormModel.Name,
                    TableName = createDto.FormModel.TableName
                };
                var insertedEntity = _context.Set<Entity>().Add(entityToInsert).Entity;
                _context.SaveChanges();

                _context.Set<FieldType>().Add(new FieldType
                {
                    Name = insertedEntity.Name,
                    SourceTypeId = (int)FieldTypeSourceEnums.Entity,
                });
                _context.SaveChanges();

                var Fields = createDto.FormModel.Fields.Select(f => new Field()
                {
                    FieldTypeId = f.FieldTypeId,
                    IsUnique = f.IsUnique,
                    Name = f.Name,
                    EntityId = insertedEntity.Id,
                    IsList = f.IsList
                }).ToList();
                foreach (var item in Fields)
                {
                    _context.Set<Field>().Add(item); 
                }

                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public List<EntityResponseDto> GetEntityResponseList()
        {
            var result1 = _context.Entities
                .Include(e => e.Fields)
                    .ThenInclude(f => f.FieldType)
                .Include(e => e.Fields)
                    .ThenInclude(f => f.RelationsPrimary)
                        .ThenInclude(rp => rp.PrimaryField).AsNoTracking()
                .Include(e => e.Fields)
                    .ThenInclude(f => f.RelationsPrimary)
                        .ThenInclude(rp => rp.ForeignField).AsNoTracking()
                .Include(e => e.Fields)
                    .ThenInclude(f => f.RelationsForeign)
                        .ThenInclude(rp => rp.PrimaryField).AsNoTracking()
                .Include(e => e.Fields)
                    .ThenInclude(f => f.RelationsForeign)
                        .ThenInclude(rp => rp.ForeignField).AsNoTracking()
                .Include(e => e.Fields)
                    .ThenInclude(f => f.RelationsForeign)
                        .ThenInclude(rf => rf.RelationType)
                .Include(e => e.Fields)
                    .ThenInclude(f => f.RelationsPrimary)
                     .ThenInclude(rf => rf.RelationType)
                     .Select(e => new EntityResponseDto()
                     {
                         Id = e.Id,
                         Name = e.Name,
                         Fields = e.Fields.Select(f =>
                             new FieldResponseDto()
                             {
                                 Id = f.Id,
                                 EntityId = f.Id,
                                 Name = f.Name,
                                 IsUnique = f.IsUnique,
                                 FieldTypeId = f.FieldTypeId,
                                 FieldType = new FieldTypeResponseDto()
                                 {
                                     Id = f.FieldType.Id,
                                     Name = f.FieldType.Name,
                                 },
                                 RelationsForeign = f.RelationsForeign.Select(rf =>
                                     new RelationResponseDto()
                                     {
                                         Id = rf.Id,
                                         RelationTypeId = rf.RelationTypeId,
                                         PrimaryFieldId = rf.PrimaryFieldId,
                                         ForeignFieldId = rf.ForeignFieldId,
                                         PrimaryField = new FieldBasicResponseDto()
                                         {
                                             Id = rf.PrimaryField.Id,
                                             EntityId = rf.PrimaryField.EntityId,
                                             Name = rf.PrimaryField.Name,
                                             IsUnique = rf.PrimaryField.IsUnique,
                                             FieldTypeId = rf.PrimaryField.FieldType.Id,
                                             FieldType = new FieldTypeResponseDto()
                                             {
                                                 Id = rf.PrimaryField.FieldType.Id,
                                                 Name = rf.PrimaryField.FieldType.Name,
                                             }
                                         },
                                         ForeignField = new FieldBasicResponseDto()
                                         {
                                             Id = rf.ForeignField.Id,
                                             EntityId = rf.ForeignField.EntityId,
                                             Name = rf.ForeignField.Name,
                                             IsUnique = rf.ForeignField.IsUnique,
                                             FieldTypeId = rf.ForeignField.FieldType.Id,
                                             FieldType = new FieldTypeResponseDto()
                                             {
                                                 Id = rf.ForeignField.FieldType.Id,
                                                 Name = rf.ForeignField.FieldType.Name,
                                             }
                                         },
                                         RelationType = new RelationTypeResponseDto()
                                         {
                                             Id = rf.RelationType.Id,
                                             Name = rf.RelationType.Name,
                                         }
                                     }
                                 ).ToList(),
                                 RelationsPrimary = f.RelationsPrimary.Select(rp =>
                                     new RelationResponseDto()
                                     {
                                         Id = rp.Id,
                                         RelationTypeId = rp.RelationTypeId,
                                         PrimaryFieldId = rp.PrimaryFieldId,
                                         ForeignFieldId = rp.ForeignFieldId,
                                         PrimaryField = new FieldBasicResponseDto()
                                         {
                                             Id = rp.PrimaryField.Id,
                                             EntityId = rp.PrimaryField.EntityId,
                                             Name = rp.PrimaryField.Name,
                                             IsUnique = rp.PrimaryField.IsUnique,
                                             FieldTypeId = rp.PrimaryField.FieldType.Id,
                                             FieldType = new FieldTypeResponseDto()
                                             {
                                                 Id = rp.PrimaryField.FieldType.Id,
                                                 Name = rp.PrimaryField.FieldType.Name,
                                             }
                                         },
                                         ForeignField = new FieldBasicResponseDto()
                                         {
                                             Id = rp.ForeignField.Id,
                                             EntityId = rp.ForeignField.EntityId,
                                             Name = rp.ForeignField.Name,
                                             IsUnique = rp.ForeignField.IsUnique,
                                             FieldTypeId = rp.ForeignField.FieldType.Id,
                                             FieldType = new FieldTypeResponseDto()
                                             {
                                                 Id = rp.ForeignField.FieldType.Id,
                                                 Name = rp.ForeignField.FieldType.Name,
                                             }
                                         },
                                         RelationType = new RelationTypeResponseDto()
                                         {
                                             Id = rp.RelationType.Id,
                                             Name = rp.RelationType.Name,
                                         }
                                     }
                                 ).ToList(),
                             }
                            ).ToList()
                     });
            return result1.ToList();
        }
    }
}
