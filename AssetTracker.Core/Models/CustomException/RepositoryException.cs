using System;
using System.Runtime.Serialization;

namespace AssetTracker.Core.Models.CustomException
{
    public class RepositoryException : Exception
    {
        public RepositoryException()
            : base()
        {

        }

        public RepositoryException(string message)
            : base(message)
        {

        }

        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public RepositoryException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
