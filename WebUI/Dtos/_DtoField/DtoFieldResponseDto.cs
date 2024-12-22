using WebUI.Dtos._Field;

namespace WebUI.Dtos._DtoField
{
    public class DtoFieldResponseDto
    {
        public int Id { get; set; }
        public int DtoId { get; set; }
        public string? Name { get; set; }
        public int SourceFieldId { get; set; }

        public FieldByEntityResponseDto SourceField { get; set; } = null!;
    }
}
