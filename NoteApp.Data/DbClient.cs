using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NoteApp.Core.BaseModels;
using System;

namespace NoteApp.Data
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Note> _notes;

        public DbClient(IOptions<DbConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.Connection_String);
            var datbase = client.GetDatabase(dbConfig.Value.Database_Name);
            _notes = datbase.GetCollection<Note>(dbConfig.Value.Notes_Collection_Name);
        }
        public IMongoCollection<Note> GetNotesCollection() => _notes;
    }
}
