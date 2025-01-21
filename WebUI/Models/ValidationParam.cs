namespace WebUI.Models
{
    public class ValidationParam
    {
        public int ValidationId { get; set; }
        public int ValidatorTypeParamId { get; set; }
        public string Value { get; set; } = null!;

        public Validation Validation { get; set; } = null!;
        public ValidatorTypeParam ValidatorTypeParam { get; set; } = null!;
    }
}