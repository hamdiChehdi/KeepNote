namespace Domain.Services
{
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class PageService : DataService, IPageService
    {
        public PageService(KeepNotesDbContext keepNoteDbContext, ILogger<PageService> logger) :
            base(keepNoteDbContext, logger)
        {

        }

        public async Task<Page[]> GetPages()
        {
            return await keepNoteDbContext.Pages
                //.Include(t => t.Notes)
                //.Include(t => t.EventNotes)
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<Page> AddPage(Page Page)
        {
            try
            {
                keepNoteDbContext.Pages.Add(Page);

                await keepNoteDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError("Unable to add a new Page " + ex.Message);
            }

            return Page;
        }

        public async Task<Page> DeletePage(long id)
        {
            var Page = await keepNoteDbContext.Pages.FindAsync(id);

            if (Page == null)
            {
                return null;
            }

            keepNoteDbContext.Pages.Remove(Page);
            await keepNoteDbContext.SaveChangesAsync();

            return Page;
        }

        public async Task<Page> UpdatePage(long id, string PageName)
        {
            var Page = await keepNoteDbContext.Pages.FindAsync(id);

            if (Page == null)
            {
                return null;
            }

            Page.Name = PageName;
            keepNoteDbContext.Entry(Page).State = EntityState.Modified;
            
            await keepNoteDbContext.SaveChangesAsync();

            return Page;
        }
    }
}
