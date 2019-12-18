using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reminder.Data.Core;
using Reminder.Data.Models;

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
        [Authorize]
        public string Get()
        {
            return "Notes get method";
        }
    }
}