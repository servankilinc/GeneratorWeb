namespace WebUI.Models
{
    public class Field
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; } = null!;
        public int FieldTypeId { get; set; }
        public bool IsUnique { get; set; }

        public Entity? Entity { get; set; }
        public FieldType? FieldType { get; set; }
        public List<Relation>? RelationsPrimary { get; set; }
        public List<Relation>? RelationsForeign { get; set; }
        public List<DtoFieldMap>? DtoFieldMaps { get; set; }
    }
}
