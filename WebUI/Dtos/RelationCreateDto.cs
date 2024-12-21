namespace WebUI.Dtos
{
    public class RelationCreateDto
    {
        public int PrimaryFieldId { get; set; }
        public int ForeignFieldId { get; set; }
        public int RelationTypeId { get; set; }
    }
}
