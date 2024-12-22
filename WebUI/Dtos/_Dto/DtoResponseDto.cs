using WebUI.Dtos._DtoField;
using WebUI.Models;

namespace WebUI.Dtos._Dto
{
    public class DtoResponseDto
    {
        public int Id { get; set; }
        public int RelatedEntityId { get; set; }
        public string Name { get; set; } = null!;
        public List<DtoFieldResponseDto> DtoFields { get; set; } = null!;
        public Entity RelatedEntity { get; set; } = null!;
    }
}
