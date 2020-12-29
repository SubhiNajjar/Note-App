using NoteApp.Core.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Services.Interfaces
{
    public interface INoteServices
    {
        List<Note> GetNotes();

        Note AddNote(Note note);

        Note GetNote(string id);

        void DeleteNote(string id);
        Note UpdateNote(Note note);
    }
}
