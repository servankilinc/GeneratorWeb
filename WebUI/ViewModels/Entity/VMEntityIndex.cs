using WebUI.Dtos._Entity;
using WebUI.Dtos._FieldType;
using WebUI.Dtos._Relation;

namespace WebUI.ViewModels.Entity
{
    public class VMEntityIndex
    {
        public List<EntityResponseDto> EntityList { get; set; } = new List<EntityResponseDto>();
        public List<FieldTypeResponseDto> FieldTypeList { get; set; } = new List<FieldTypeResponseDto>();
        public List<RelationTypeResponseDto> RelationTypeList { get; set; } = new List<RelationTypeResponseDto>();
        public List<RelationResponseDto> RelationList { get; set; } = new List<RelationResponseDto>();
    }
}
