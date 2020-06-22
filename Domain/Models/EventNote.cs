namespace Domain.Models
{
    using Domain.Enums;
    using System;

    public class EventNote
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime LastUdpateDateTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public EventNoteType EventNoteType { get; set; }

        public Page Page { get; set; }

        public long PageId { get; set; }
    }
}
