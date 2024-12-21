namespace WebUI.Models
{
    public class FieldType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Field>? Fields { get; set; }
    }
}
