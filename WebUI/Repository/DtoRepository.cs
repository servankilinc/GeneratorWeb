using WebUI.Context;
using WebUI.Dtos._Dto;
using WebUI.Models;
using WebUI.Models.Enums;

namespace WebUI.Repository
{
    public class DtoRepository : EFRepositoryBase<Dto>
    {
        private readonly LocalContext _context;
        public DtoRepository(LocalContext context) : base(context)
        {
            _context = context;
        }


        public void CreateByFields(DtoCreateDto createDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var insertedDto = _context.Dtos.Add(new Dto()
                {
                    Name = createDto.Name,
                    RelatedEntityId = createDto.RelatedEntityId,
                }).Entity;

                _context.SaveChanges();

                _context.Set<FieldType>().Add(new FieldType
                {
                    Name = insertedDto.Name,
                    SourceTypeId = (int)FieldTypeSourceEnums.Dto,
                });
                _context.SaveChanges();



                foreach (var sourceField in createDto.DtoFields)
                {
                    _context.DtoFields.Add(new DtoField
                    {
                        DtoId = insertedDto.Id,
                        SourceFieldId = sourceField.SourceFieldId,
                        Name = sourceField.Name,
                    });
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
    }
}
