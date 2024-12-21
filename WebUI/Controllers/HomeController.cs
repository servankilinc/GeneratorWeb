using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Dtos;
using WebUI.Models;
using WebUI.Models.Enums;
using WebUI.Repository;
using WebUI.ViewModels.Home;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly EntityRepository _entityRepository;
        private readonly FieldTypeRepository _fieldTypeRepository;
        private readonly FieldRepository _fieldRepository;
        private readonly RelationTypeRepository _relationTypeRepository;
        private readonly RelationRepository _relationRepository;
        public HomeController(EntityRepository entityRepository, FieldTypeRepository fieldTypeRepository, RelationTypeRepository relationTypeRepository, FieldRepository fieldRepository, RelationRepository relationRepository)
        {
            _entityRepository = entityRepository;
            _fieldTypeRepository = fieldTypeRepository;
            _relationTypeRepository = relationTypeRepository;
            _fieldRepository = fieldRepository;
            _relationRepository = relationRepository;
        }

        #region Index
        public IActionResult Index()
        {
            var eList = _entityRepository.GetEntityResponseList();
            var fTypeList = _fieldTypeRepository.GetAll();
            var rList = _relationTypeRepository.GetAll();

            var viewModel = new VMHomeIndex()
            {
                EntityList = eList,
                FieldTypeList = fTypeList.Select(x => new FieldTypeResponseDto { Id = x.Id, Name = x.Name }).ToList(),
                RelationTypeList = rList.Select(x => new RelationTypeResponseDto { Id = x.Id, Name = x.Name }).ToList(),
            };
            return View(viewModel);
        }

        public IActionResult ShowRelationModal(int id)
        {
            ViewBag.MainId = id;

            var _list = _relationRepository.GetAllByFields(id);

            var eList = _entityRepository.GetEntityResponseList();
            var fTypeList = _fieldTypeRepository.GetAll();
            var rList = _relationTypeRepository.GetAll();

            var viewModel = new VMHomeIndex()
            {
                EntityList = eList,
                FieldTypeList = fTypeList.Select(x => new FieldTypeResponseDto { Id = x.Id, Name = x.Name }).ToList(),
                RelationTypeList = rList.Select(x => new RelationTypeResponseDto { Id = x.Id, Name = x.Name }).ToList(),
                RelationList = _list
            };
            return PartialView("~/Views/Home/Partial/_modalRelations.cshtml", viewModel);
        }

        public IActionResult ShowAddRelationModal(int id)
        {
            var field = _fieldRepository.Get(f =>
                f.Id == id,
                include: i => i
                    .Include(x => x.RelationsPrimary)
                    .Include(x => x.RelationsForeign)
            );
            var fList2 = _fieldRepository.GetAll();
            var fList = _fieldRepository.GetAll(
                filter: f => f.FieldTypeId == field.FieldTypeId,
                include: i => i.Include(x => x.FieldType)
            );
            var eList = _entityRepository.GetEntityResponseList();
            var rList = _relationTypeRepository.GetAll();

            var viewModel = new VMHomeAddRelation()
            {
                FieldId = field.Id,
                EntityId = field.EntityId,
                FieldName = field.Name,
                EntityList = eList.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList(),
                RelationTypeList = rList.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList(),
                AllFieldList = fList.Select(x =>
                    new FieldOnFieldRelationResponseDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        EntityId = x.EntityId,
                        FieldTypeId = x.FieldTypeId,
                        IsUnique = x.IsUnique,
                        IsAlreadyRelated =
                            field.RelationsPrimary.Any(x => x.PrimaryFieldId == x.Id || x.ForeignFieldId == x.Id) ||
                            field.RelationsForeign.Any(x => x.PrimaryFieldId == x.Id || x.ForeignFieldId == x.Id),
                        FieldType = new FieldTypeResponseDto()
                        {
                            Id = x.FieldType.Id,
                            Name = x.FieldType.Name
                        }
                    }
                ).ToList()
            };

            return PartialView("~/Views/Home/Partial/_modalAddRelation.cshtml", viewModel);
        }

        [HttpPost]
        public IActionResult AddRelation(RelationCreateDto relationCreateDto)
        {
            var relationToInsert = new Relation()
            {
                ForeignFieldId = relationCreateDto.ForeignFieldId,
                PrimaryFieldId = relationCreateDto.PrimaryFieldId,
                RelationTypeId = relationCreateDto.RelationTypeId
            };
            var insertedRelation = _relationRepository.Add(relationToInsert);

            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteEntiy(int id)
        {
            _entityRepository.DeleteByFilter(f => f.Id == id);

            return RedirectToAction("Index");
        }
        #endregion


        #region Create
        public IActionResult CreateEntity() 
        {
            var viewModel = new VMHomeCreateEntity()
            {
                FieldTypeList = _fieldTypeRepository.GetAll().Select(x => new FieldTypeResponseDto { Id = x.Id, Name = x.Name }).ToList(),
                FormModel = new EntityCreateDto() { 
                    Name = "",
                    TableName = "",
                    Fields = new List<FieldOnEntityCreateDto>() {
                        new FieldOnEntityCreateDto() {
                            IsUnique = true, 
                            Name = "Id",
                            FieldTypeId = (int)FieldTypeEnums.Guid
                        },
                        new FieldOnEntityCreateDto() {
                            IsUnique = false,
                            Name = "Name",
                            FieldTypeId = (int)FieldTypeEnums.String
                        }
                    }
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateEntity(VMHomeCreateEntity createDto)
        {
            var insertedEntity = _entityRepository.Add(new Models.Entity
            {
                Name = createDto.FormModel.Name,
                TableName = createDto.FormModel.TableName        
            });

            var Fields = createDto.FormModel.Fields.Select(f => new Models.Field()
            {
                FieldTypeId = f.FieldTypeId,
                IsUnique = f.IsUnique,
                Name = f.Name,
                EntityId = insertedEntity.Id,
            }).ToList();
            foreach (var item in Fields)
            {
                var insertedField = _fieldRepository.Add(item);
                Console.Write(insertedField);
            }

            return RedirectToAction("CreateEntity");
        }
        #endregion
    }
}
