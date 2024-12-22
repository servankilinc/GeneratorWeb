using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Dtos._Dto;

namespace WebUI.ViewModels.Dtos
{
    public class VMDtoIndex
    {
        public List<SelectListItem> EntityList { get; set; } = new List<SelectListItem>();
        public List<DtoResponseDto> DtoList { get; set; } = new List<DtoResponseDto>();
    }
}
