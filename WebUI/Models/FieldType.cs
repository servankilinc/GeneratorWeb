namespace WebUI.Models
{
    public class FieldType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SourceTypeId { get; set; }

        public FieldTypeSource? SourceType { get; set; }
        public List<Field>? Fields { get; set; }
        public List<MethodArgumentField>? MethodArgumentFields { get; set; }
        public List<MethodReturnField>? MethodReturnFields { get; set; }
    }
}
