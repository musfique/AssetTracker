using System;
using System.Runtime.Serialization;

namespace AssetTracker.Core.Models.CustomException
{
    public class BllException : Exception
    {
        public BllException()
            : base()
        {

        }

        public BllException(string message)
            : base(message)
        {

        }

        public BllException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public BllException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
