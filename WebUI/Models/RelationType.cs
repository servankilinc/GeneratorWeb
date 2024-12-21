namespace WebUI.Models
{
    public class RelationType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Relation>? Relations { get; set; }
    }
}
