namespace Domain.Services
{
    using Microsoft.Extensions.Logging;

    public class DataService
    {
        protected readonly KeepNotesDbContext keepNoteDbContext;
        protected readonly ILogger logger;

        public DataService(KeepNotesDbContext keepNoteDbContext, ILogger logger)
        {
            this.keepNoteDbContext = keepNoteDbContext;
            this.logger = logger;
        }
    }
}
