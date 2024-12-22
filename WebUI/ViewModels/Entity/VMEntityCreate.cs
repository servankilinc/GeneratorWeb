using WebUI.Dtos._Entity;
using WebUI.Dtos._FieldType;

namespace WebUI.ViewModels.Entity
{
    public class VMEntityCreate
    {
        public EntityCreateDto FormModel { get; set; } = new EntityCreateDto();
        public List<FieldTypeResponseDto> FieldTypeList { get; set; } = new List<FieldTypeResponseDto>();
    }
}
