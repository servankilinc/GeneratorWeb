﻿namespace WebUI.Models
{
    public class DtoField
    {
        public int Id { get; set; }
        public int DtoId { get; set; }
        public string? Name { get; set; }
        public int SourceFieldId { get; set; }

        public Dto Dto { get; set; } = null!;
        public Field SourceField { get; set; } = null!;
    }
}