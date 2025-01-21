namespace WebUI.Models
{
    public class FieldTypeSource
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<FieldType>? FieldTypes { get; set; }
    }
}
