namespace WebUI.Models
{
    public class Field
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; } = null!;
        public int FieldTypeId { get; set; }
        public bool IsUnique { get; set; }

        public Entity Entity { get; set; } = null!;
        public FieldType FieldType { get; set; } = null!;
        public List<Relation> RelationsPrimary { get; set; } = null!;
        public List<Relation> RelationsForeign { get; set; } = null!;
        public List<DtoField> DtoFields { get; set; } = null!;
    }
}
