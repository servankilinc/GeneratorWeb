using WebUI.Context;
using WebUI.Models;

namespace WebUI.Repository
{
    public class RelationTypeRepository : EFRepositoryBase<RelationType>
    {
        public RelationTypeRepository(LocalContext context) : base(context)
        {
        }
    }
}
