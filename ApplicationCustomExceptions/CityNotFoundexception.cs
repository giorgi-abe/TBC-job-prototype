using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ApplicationCustomExceptions
{
    [Serializable]
    public class CityNotFoundexception : Exception
    {
        public CityNotFoundexception(string message)
           : base(message)
        {
        }
        public CityNotFoundexception(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public CityNotFoundexception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
