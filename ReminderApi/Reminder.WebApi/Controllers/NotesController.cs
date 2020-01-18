using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reminder.Data.Core;
using Reminder.Data.Models;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Reminder.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly IRepository<Note> _noteRepository;

        public NotesController(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public string Get()
        {
            return "Notes get method";
        }

        [HttpPost]
        public async Task<IActionResult> UploadNotes(Stream stream)
        {
            var formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            if (formatter.Deserialize(stream) is List<Note> notes)
            {
                foreach (var note in notes)
                {
                    await _noteRepository.CreateAsync(note);
                }
            }
            return new OkResult();
        }
    }
}