namespace WebUI.Models
{
    public class ServiceLayer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Service>? Services { get; set; }
    }
}
