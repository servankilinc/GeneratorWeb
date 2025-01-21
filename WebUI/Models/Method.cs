namespace WebUI.Models
{
    public class Method
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int? ReturnMethodFieldId { get; set; }
        public bool IsVoid => ReturnMethodFieldId == default;
        public string Name { get; set; } = null!;
        public bool IsAsync { get; set; }
        public string? Description { get; set; }

        public Service Service { get; set; } = new Service();
        public MethodReturnField? ReturnMethodField { get; set; }
        public List<MethodArgumentField>? ArgumentMethodFields { get; set; }
    }
}
