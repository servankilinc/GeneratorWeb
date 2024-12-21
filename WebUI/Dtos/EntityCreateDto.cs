namespace WebUI.Dtos
{
    public class EntityCreateDto
    {
        public string Name { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public List<FieldOnEntityCreateDto> Fields { get; set; } = null!;
    }
}
