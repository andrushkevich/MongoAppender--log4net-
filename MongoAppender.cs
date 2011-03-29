using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using log4net.Core;

namespace MongoAppender
{
    public class MongoAppender : AppenderSkeleton
    {
        private String m_connectionString;

        public String ConnectionString
		{
			get { return m_connectionString; }
			set { m_connectionString = value; }
		}

        private String m_collectionName = "log4net";

        public String CollectionName
        {
            get { return m_collectionName; }
            set { m_collectionName = value; }
        }

        private MongoDb _server;

        protected MongoDb Server { 
            get
            {
                if ( _server == null)
                    _server = new MongoDb(ConnectionString, CollectionName);
                return _server;
            }
        }


        protected override void Append(LoggingEvent loggingEvent)
        {
            String result = RenderLoggingEvent(loggingEvent);
            AddNewErroToMongoDb(result);
        }

        #region Protected Instance Methods

        protected void AddNewErroToMongoDb(String errorMsg)
        {
            Server.Collection.Insert(new ErrorDocument()
                                                            {
                                                                Id = Guid.NewGuid().ToString(),
                                                                Date = DateTime.UtcNow,
                                                                Error = errorMsg
                                                            });
}

        #endregion
    }
}
