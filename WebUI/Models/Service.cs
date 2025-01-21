namespace WebUI.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int ServiceLayerId { get; set; }
        public int RelatedEntityId { get; set; }

        public ServiceLayer ServiceLayer { get; set; } = null!;
        public Entity RelatedEntity { get; set; } = null!;
        public List<Method> Methods { get; set; }
    }
}
