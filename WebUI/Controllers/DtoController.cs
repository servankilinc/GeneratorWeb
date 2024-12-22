using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Dtos._Dto;
using WebUI.Dtos._DtoField;
using WebUI.Dtos._Entity;
using WebUI.Dtos._Field;
using WebUI.Dtos._FieldType;
using WebUI.Repository;
using WebUI.ViewModels.Dtos;

namespace WebUI.Controllers
{
    public class DtoController : Controller
    {
        private readonly DtoRepository _dtoRepository;
        private readonly EntityRepository _entityRepository;
        private readonly FieldRepository _fieldRepository;
        public DtoController(DtoRepository dtoRepository, EntityRepository entityRepository, FieldRepository fieldRepository)
        {
            _dtoRepository = dtoRepository;
            _entityRepository = entityRepository;
            _fieldRepository = fieldRepository;
        }

        public IActionResult Index()
        {
            var dtoList = _dtoRepository.GetAll(include:i => i
                .Include(d => d.DtoFields)
                    .ThenInclude(dfm => dfm.SourceField)
                        .ThenInclude(f => f.FieldType)
                .Include(d => d.DtoFields)
                    .ThenInclude(dfm => dfm.SourceField)
                        .ThenInclude(f => f.Entity)
                .Include(d => d.RelatedEntity));

            var eList = _entityRepository.GetAll();

            var model = new VMDtoIndex
            {
                DtoList = dtoList.Select(d => new DtoResponseDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    RelatedEntityId = d.RelatedEntityId,
                    RelatedEntity = d.RelatedEntity,
                    DtoFields = d.DtoFields.Select(dfm => new DtoFieldResponseDto
                    {
                        Id = dfm.SourceFieldId,
                        DtoId = dfm.DtoId,
                        Name = dfm.Name,
                        SourceFieldId = dfm.SourceFieldId,
                        SourceField = new FieldByEntityResponseDto
                        {
                            Id = dfm.SourceField.Id,
                            Name = dfm.SourceField.Name,
                            EntityId = dfm.SourceField.EntityId,
                            Entity = new EntityResponseDto
                            {
                                Id = dfm.SourceField.Entity.Id,
                                Name = dfm.SourceField.Entity.Name,
                            },
                            FieldTypeId = dfm.SourceField.FieldTypeId,
                            FieldType = new FieldTypeResponseDto
                            {
                                Id = dfm.SourceField.FieldType.Id,
                                Name = dfm.SourceField.FieldType.Name,
                            },
                            IsUnique = dfm.SourceField.IsUnique
                        }
                    }).ToList()
                }).ToList(),
                EntityList = eList.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList(),
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var eList = _entityRepository.GetAll();

            var fList = _fieldRepository.GetAll(
                include: f => f.Include(x => x.FieldType));

            var model = new VMDtoCreate
            {
                EntityList = eList.Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList(),
                AllFieldList = fList.Select(f => new FieldBasicResponseDto
                {
                    Id = f.Id,
                    EntityId = f.EntityId,
                    FieldTypeId = f.FieldTypeId,
                    FieldType = new FieldTypeResponseDto
                    {
                        Id = f.FieldType.Id,
                        Name = f.FieldType.Name,
                    },
                    IsUnique = f.IsUnique,
                    Name = f.Name
                }).ToList(),
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Create(VMDtoCreate viewModel)
        {
            var insertedDto = _dtoRepository.CreateByFields(viewModel.FormModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _dtoRepository.DeleteByFilter(filter: f => f.Id == id);

            return RedirectToAction("Index");
        }
    }
}
