namespace WebUI.Models
{
    public class Dto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string RelatedEntityId { get; set; } = null!;
        public List<DtoFieldMap>? DtoFieldMaps { get; set; }
        public Entity? RelatedEntity { get; set; }
    }
}
