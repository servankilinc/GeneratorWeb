﻿namespace WebUI.Dtos
{
    public class FieldBasicResponseDto
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; } = null!;
        public int FieldTypeId { get; set; }
        public bool IsUnique { get; set; }

        public FieldTypeResponseDto FieldType { get; set; } = new FieldTypeResponseDto();
    }
}
