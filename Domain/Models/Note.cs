namespace Domain.Models
{
    using Domain.Enums;
    using System;

    public class Note
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime LastUdpateDateTime { get; set; }

        public NoteType NoteType { get; set; }

        public Page Page { get; set; }

        public long PageId { get; set; }
    }
}
