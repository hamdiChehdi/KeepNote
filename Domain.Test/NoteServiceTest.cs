using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace Domain.Test
{
    public class NoteServiceTest
    {
        private INoteService noteService;
        private IPageService topicService;

        public  NoteServiceTest()
        {
            var options = new DbContextOptionsBuilder<KeepNotesDbContext>()
                .UseInMemoryDatabase(databaseName: "NoteServiceKeepNotes")
                .Options;

            var context = new KeepNotesDbContext(options);

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);
            });

            var logger = loggerFactory.CreateLogger<NoteService>();
            noteService = new NoteService(context, logger);

            var topicServiceLogger = loggerFactory.CreateLogger<PageService>();
            topicService = new PageService(context, topicServiceLogger);
            
        }

        [Fact]
        public async void AddAndGetsTopics()
        {
            var topic = await topicService.AddTopic(new Label() { Name = "topic 1" });
            Note note = new Note() { Content = "Note 1 content ", CreationDateTime = DateTime.Now, Topic = topic, LastUdpateDateTime = DateTime.Now};

            note = await noteService.AddNote(note);

            Assert.NotNull(note);
            Assert.True(note.Id > 0);
        }
    }
}
