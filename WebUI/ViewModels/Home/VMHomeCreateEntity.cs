using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Dtos;

namespace WebUI.ViewModels.Home
{
    public class VMHomeCreateEntity
    {
        public EntityCreateDto FormModel { get; set; } = new EntityCreateDto();
        public List<FieldTypeResponseDto> FieldTypeList { get; set; } = new List<FieldTypeResponseDto>();
    }
}
