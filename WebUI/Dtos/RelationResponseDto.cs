namespace WebUI.Dtos
{
    public class RelationResponseDto
    {
        public int Id { get; set; }
        public int PrimaryFieldId { get; set; }
        public int ForeignFieldId { get; set; }
        public int RelationTypeId { get; set; }

        public FieldBasicResponseDto PrimaryField { get; set; } = new FieldBasicResponseDto();
        public FieldBasicResponseDto ForeignField { get; set; } = new FieldBasicResponseDto();
        public RelationTypeResponseDto RelationType { get; set; } = new RelationTypeResponseDto();
    }
}
