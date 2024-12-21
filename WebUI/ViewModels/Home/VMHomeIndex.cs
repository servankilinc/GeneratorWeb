using WebUI.Dtos;

namespace WebUI.ViewModels.Home
{
    public class VMHomeIndex
    {
        public List<EntityResponseDto> EntityList { get; set; } = new List<EntityResponseDto>();
        public List<FieldTypeResponseDto> FieldTypeList { get; set; } = new List<FieldTypeResponseDto>();
        public List<RelationTypeResponseDto> RelationTypeList { get; set; } = new List<RelationTypeResponseDto>();
        public List<RelationResponseDto> RelationList { get; set; } = new List<RelationResponseDto>();
    }
}
