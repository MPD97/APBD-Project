using System;
using System.Runtime.Serialization;

namespace Advert.Presistance.Services
{
    [Serializable]
    internal class CannotUpdateException : Exception
    {
        public CannotUpdateException()
        {
        }

        public CannotUpdateException(string message) : base(message)
        {
        }

        public CannotUpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannotUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}