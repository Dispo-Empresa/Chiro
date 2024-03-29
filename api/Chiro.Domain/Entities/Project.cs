﻿namespace Chiro.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public List<TimelineAction> TimelineActionsList { get; set; }
        public List<BoardAction> BoardActionsList { get; set; }
    }
}