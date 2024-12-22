using WebUI.Dtos._Field;

namespace WebUI.Dtos._Entity
{
    public class EntityResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<FieldResponseDto> Fields { get; set; } = null!;
    }
}
