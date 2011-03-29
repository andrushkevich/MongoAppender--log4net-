using System;
using MongoDB.Bson.DefaultSerializer;

namespace MongoAppender
{
    [BsonIgnoreExtraElements]
    public class ErrorDocument
    {
        [BsonId]
        public String Id { get; set; }

        public DateTime Date { get; set; }

        public String Error { get; set; }
    }
}