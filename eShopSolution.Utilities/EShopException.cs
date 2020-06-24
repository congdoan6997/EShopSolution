using System;
using System.Runtime.Serialization;

namespace eShopSolution.Utilities
{
    public class EShopException : Exception
    {
        public EShopException()
        {
        }

        public EShopException(string message) : base(message)
        {
        }

        public EShopException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EShopException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
