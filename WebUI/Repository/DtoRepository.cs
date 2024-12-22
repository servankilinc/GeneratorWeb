using WebUI.Context;
using WebUI.Dtos._Dto;
using WebUI.Models;

namespace WebUI.Repository
{
    public class DtoRepository : EFRepositoryBase<Dto>
    {
        private readonly LocalContext _context;
        public DtoRepository(LocalContext context) : base(context)
        {
            _context = context;
        }


        public Dto CreateByFields(DtoCreateDto createDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var dtoToInsert = new Dto()
                {
                    Name = createDto.Name,
                    RelatedEntityId = createDto.RelatedEntityId,
                };

                var inserting = _context.Dtos.Add(dtoToInsert);
                _context.SaveChanges();

                Dto insertedDto = inserting.Entity;

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
                return dtoToInsert;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
