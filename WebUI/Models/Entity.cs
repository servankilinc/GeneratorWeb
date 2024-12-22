namespace WebUI.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public string TableName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<Field> Fields { get; set; } = null!;
        public List<Dto>? Dtos { get; set; }
    }
}
