namespace WebUI.Models
{
    public class ValidatorType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<Validation>? Validations { get; set; }
        public List<ValidatorTypeParam>? ValidatorTypeParams { get; set; }
    }
}