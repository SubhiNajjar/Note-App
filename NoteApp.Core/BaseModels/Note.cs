using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Core.BaseModels
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Subject { get; set; }

        public string Reminder { get; set; }

    }
}
