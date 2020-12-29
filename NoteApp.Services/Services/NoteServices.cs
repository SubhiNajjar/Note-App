using MongoDB.Driver;
using NoteApp.Core.BaseModels;
using NoteApp.Data;
using NoteApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Services.Services
{
    public class NoteServices : INoteServices
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteServices(IDbClient dbClient)
        {
            _notes = dbClient.GetNotesCollection();
        }

        public Note AddNote(Note note)
        {
            _notes.InsertOne(note);
            return note;
        }

        public void DeleteNote(string id)
        {
            _notes.DeleteOne(note => note.Id == id);
        }

        public Note GetNote(string id) => _notes.Find(note => note.Id == id).First();

        public List<Note> GetNotes() => _notes.Find(note => true).ToList();

        public Note UpdateNote(Note note)
        {
            GetNote(note.Id);
            _notes.ReplaceOne(n => n.Id == note.Id, note);
            return note;
        }
    }
}
