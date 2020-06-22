namespace Domain.Models
{ 
    using System.Collections.Generic;

    public class Page
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<EventNote> EventNotes { get; set; }
    }
}
