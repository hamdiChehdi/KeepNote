using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace Domain.Test
{
    public class PageServiceTest
    {
        private IPageService PageService;

        public PageServiceTest()
        {
            var options = new DbContextOptionsBuilder<KeepNotesDbContext>()
                .UseInMemoryDatabase(databaseName: "PageServiceKeepNotes")
                .Options;

            var context = new KeepNotesDbContext(options);          

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);
            });

            var logger = loggerFactory.CreateLogger<PageService>();
            PageService = new PageService(context, logger);
        }

        [Fact]
        public async void AddAndGetsPages()
        {
            var Page1 = await PageService.AddPage(new Page() { Name = "Page 1" });
            var Page2 = await PageService.AddPage(new Page() { Name = "Page 2" });
            var Page3 = await PageService.AddPage(new Page() { Name = "Page 3" });

            Assert.NotNull(Page1);
            Assert.NotNull(Page2);
            Assert.NotNull(Page3);
            Assert.Equal(1, Page1.Id);
            Assert.Equal(2, Page2.Id);
            Assert.Equal(3, Page3.Id);

            var Pages = await PageService.GetPages();

            Assert.NotNull(Pages);
            Assert.Equal(3, Pages.Length);
        }   
    }
}
