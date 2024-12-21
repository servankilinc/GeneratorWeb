namespace WebUI.Dtos
{
    public class EntityResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<FieldResponseDto> Fields { get; set; } = null!;
    }
}
