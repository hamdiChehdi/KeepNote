namespace Domain
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class KeepNotesDbContext : DbContext
    {
        public KeepNotesDbContext(DbContextOptions<KeepNotesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<EventNote> EventNotes { get; set; }

        public DbSet<Page> Pages { get; set; }
    }
}