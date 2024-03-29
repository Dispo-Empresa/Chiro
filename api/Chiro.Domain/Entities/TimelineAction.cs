﻿namespace Chiro.Domain.Entities
{
    public class TimelineAction : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? AdjustedDate { get; set; }
        public DateTime? ConcludedAt { get; set; }

        public long BoardActionId { get; set; }
        public BoardAction BoardAction { get; set; }

        public long ProjectId { get; set; }
        public Project Project { get; set; }

        public long? LinkedTimelineActionId { get; set; }
        public TimelineAction? LinkedTimelineAction { get; set; }
    }
}