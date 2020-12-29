using MongoDB.Driver;
using NoteApp.Core.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Data
{
    public interface IDbClient
    {
        IMongoCollection<Note> GetNotesCollection();
    }
}
