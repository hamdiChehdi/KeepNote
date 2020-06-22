namespace NoteApp.Controllers
{
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.AspNetCore.Mvc;
    using NoteApp.DTO;

    [ApiController]
    [Route("api/[controller]")]
    public class PagesController : ControllerBase
    {
        private readonly IPageService Pageservice;

        public PagesController(IPageService Pageservice)
        {
            this.Pageservice = Pageservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var topîcs = await Pageservice.GetPages();
            return Ok(topîcs);
        }

        [HttpPost]
        public async Task<IActionResult> AddPage(Page page)
        { 
            var addedPage = await Pageservice.AddPage(page);

            return Ok(addedPage);
        }

        // DELETE: api/Pages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Page>> DeletePage(long id)
        {
            var Page = await Pageservice.DeletePage(id);

            if (Page == null)
            {
                return NotFound();
            }

            return Page;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPage(long id, Page page)
        {
            if (page == null)
            {
                return BadRequest();
            }

            string PageName = page.Name;

            if (PageName == "")
            {
                return BadRequest();
            }

            var Page = await Pageservice.UpdatePage(id, PageName);

            if (Page == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
