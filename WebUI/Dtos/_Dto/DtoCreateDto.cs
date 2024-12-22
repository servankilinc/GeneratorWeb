using WebUI.Dtos._DtoField;

namespace WebUI.Dtos._Dto
{
    public class DtoCreateDto
    {
        public int RelatedEntityId { get; set; }
        public string Name { get; set; } = null!;
        public List<DtoFieldCreateDto> DtoFields { get; set; } = null!;
    }
}
