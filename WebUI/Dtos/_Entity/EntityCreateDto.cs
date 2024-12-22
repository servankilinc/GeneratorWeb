using WebUI.Dtos._Field;

namespace WebUI.Dtos._Entity
{
    public class EntityCreateDto
    {
        public string Name { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public List<FieldOnEntityCreateDto> Fields { get; set; } = null!;
    }
}
