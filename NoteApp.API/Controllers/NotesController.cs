using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteApp.Core.BaseModels;
using NoteApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteServices _noteServices;

        public NotesController(INoteServices noteServices)
        {
            _noteServices = noteServices;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_noteServices.GetNotes());
        }

        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult GetNote(string id)
        {
            return Ok(_noteServices.GetNote(id));
        }

        [HttpPost]
        public IActionResult AddNote(Note note)
        {
            _noteServices.AddNote(note);
            return CreatedAtRoute("GetNote", new { id = note.Id }, note);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(string id)
        {
            _noteServices.DeleteNote(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateNote(Note note)
        {
            return Ok(_noteServices.UpdateNote(note));
        }
    }
}
