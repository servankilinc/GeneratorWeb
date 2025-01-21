namespace WebUI.Models
{
    public class MethodArgumentField
    {
        public int Id { get; set; }
        public int MethodId { get; set; }
        public int FieldTypeId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsList { get; set; }

        public Method Method { get; set; } = null!;
        public FieldType FieldType { get; set; } = null!;
    }
}