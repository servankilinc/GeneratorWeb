namespace WebUI.Dtos._Field
{
    public class FieldOnEntityCreateDto
    {
        public string Name { get; set; } = null!;
        public int FieldTypeId { get; set; }
        public bool IsUnique { get; set; }
    }
}
