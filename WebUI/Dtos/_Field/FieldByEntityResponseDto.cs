﻿using WebUI.Dtos._Entity;
using WebUI.Dtos._FieldType;

namespace WebUI.Dtos._Field
{
    public class FieldByEntityResponseDto
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; } = null!;
        public int FieldTypeId { get; set; }
        public bool IsUnique { get; set; }

        public FieldTypeResponseDto FieldType { get; set; } = new FieldTypeResponseDto();
        public EntityResponseDto Entity { get; set; } = new EntityResponseDto();
    }
}
