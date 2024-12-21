namespace WebUI.ViewModels
{
    public class EntityCreateModel
    {
        public string TableName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<FieldModelOnEntityCreate> Fields { get; set; } = new List<FieldModelOnEntityCreate>();
    }

    public class FieldModelOnEntityCreate
    {
        public string Name { get; set; } = null!;
        public int FieldTypeId { get; set; }
        public bool IsUnique { get; set; }
    }
}
