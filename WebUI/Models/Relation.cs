﻿namespace WebUI.Models
{
    public class Relation
    {
        public int Id { get; set; }
        public int PrimaryFieldId { get; set; }
        public int ForeignFieldId { get; set; }
        public int RelationTypeId { get; set; }

        public Field PrimaryField { get; set; } = null!;
        public Field ForeignField { get; set; } = null!;
        public RelationType RelationType { get; set; } = null!;
    }
}
