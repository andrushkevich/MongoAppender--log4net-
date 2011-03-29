using System;
using MongoDB.Driver;

namespace MongoAppender
{
    public class MongoDb
    {
        /// <summary>
        /// MongoDB Server
        /// </summary>
        private readonly MongoServer _server;

        /// <summary>
        /// Name of database 
        /// </summary>
        private readonly string _databaseName;

        /// <summary>
        /// Just Name of default collection in cyrrent db
        /// errors will be insert into this collection
        /// </summary>
        private readonly string _defaultCollection;

        /// <summary>
        /// Opens connection to MongoDB Server
        /// </summary>
        public MongoDb(String connectionString)
        {
            _databaseName = MongoUrl.Create(connectionString).DatabaseName;
            _server = MongoServer.Create(connectionString);
        }

        public MongoDb(String connectionString, String defaultCollection): this(connectionString)
        {
            _defaultCollection = defaultCollection;
        }

        /// <summary>
        /// MongoDB Server
        /// </summary>
        public MongoServer Server
        {
            get { return _server; }
        }

        /// <summary>
        /// Get database
        /// </summary>
        public MongoDatabase Database
        {
            get { return _server.GetDatabase(_databaseName); }
        }

        public MongoCollection Collection
        {
            get { return Database.GetCollection(_defaultCollection); }
        }
    }
}