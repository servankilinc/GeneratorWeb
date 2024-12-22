using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Dtos._Dto;
using WebUI.Dtos._Field;

namespace WebUI.ViewModels.Dtos
{
    public class VMDtoCreate
    {
        public List<SelectListItem> EntityList { get; set; } = new List<SelectListItem>();
        public List<FieldBasicResponseDto> AllFieldList { get; set; } = new List<FieldBasicResponseDto>();
        public DtoCreateDto FormModel { get; set; } = new DtoCreateDto();
    }
}
