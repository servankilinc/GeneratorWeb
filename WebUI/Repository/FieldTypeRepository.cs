using WebUI.Context;
using WebUI.Models;

namespace WebUI.Repository
{
    public class FieldTypeRepository : EFRepositoryBase<FieldType>
    {
        public FieldTypeRepository(LocalContext context) : base(context)
        {
        }
    }
}
