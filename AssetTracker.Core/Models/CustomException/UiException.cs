using System;
using System.Runtime.Serialization;

namespace AssetTracker.Core.Models.CustomException
{
    public class UiException : Exception
    {
        public UiException()
            : base()
        {

        }

        public UiException(string message)
            : base(message)
        {

        }

        public UiException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public UiException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
