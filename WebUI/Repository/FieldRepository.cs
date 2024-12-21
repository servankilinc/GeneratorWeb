using WebUI.Context;
using WebUI.Models;

namespace WebUI.Repository
{
    public class FieldRepository : EFRepositoryBase<Field>
    {
        public FieldRepository(LocalContext context) : base(context)
        {
        }
    }
}
