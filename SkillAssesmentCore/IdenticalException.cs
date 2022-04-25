using System;
using System.Runtime.Serialization;

namespace SkillAssesmentCore
{
    [Serializable]
    internal class IdenticalException : Exception
    {
        public IdenticalException()
        {
        }

        public IdenticalException(string message) : base(message)
        {

        }

        public IdenticalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdenticalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}