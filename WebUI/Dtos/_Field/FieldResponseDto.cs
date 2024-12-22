using WebUI.Dtos._FieldType;
using WebUI.Dtos._Relation;

namespace WebUI.Dtos._Field
{
    public class FieldResponseDto
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; } = null!;
        public int FieldTypeId { get; set; }
        public bool IsUnique { get; set; }

        public FieldTypeResponseDto FieldType { get; set; } = new FieldTypeResponseDto();
        public List<RelationResponseDto> RelationsPrimary { get; set; } = new List<RelationResponseDto>();
        public List<RelationResponseDto> RelationsForeign { get; set; } = new List<RelationResponseDto>();
    }
}
