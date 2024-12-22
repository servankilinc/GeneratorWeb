using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Dtos._Field;

namespace WebUI.ViewModels.Entity
{
    public class VMEntityAddRelation
    {
        public string FieldName { get; set; } = "";
        public int FieldId { get; set; }
        public int EntityId { get; set; }
        public List<SelectListItem> EntityList { get; set; } = new List<SelectListItem>();
        public List<FieldOnFieldRelationResponseDto> AllFieldList { get; set; } = new List<FieldOnFieldRelationResponseDto>();
        public List<SelectListItem> RelationTypeList { get; set; } = new List<SelectListItem>();
    }
}
