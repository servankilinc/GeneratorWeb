using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Dtos;

namespace WebUI.ViewModels.Home
{
    public class VMHomeAddRelation
    {
        public string FieldName { get; set; } = "";
        public int FieldId { get; set; }
        public int EntityId { get; set; }
        public List<SelectListItem> EntityList { get; set; } = new List<SelectListItem>();
        public List<FieldOnFieldRelationResponseDto> AllFieldList { get; set; } = new List<FieldOnFieldRelationResponseDto>();
        public List<SelectListItem> RelationTypeList { get; set; } = new List<SelectListItem>();
    }
}
