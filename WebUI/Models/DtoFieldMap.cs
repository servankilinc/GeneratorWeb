namespace WebUI.Models
{
    public class DtoFieldMap
    {
        public int DtoId { get; set; }
        public int FieldId { get; set; }
        public Dto? Dto { get; set; }
        public Field? Field { get; set; }
    }
}
