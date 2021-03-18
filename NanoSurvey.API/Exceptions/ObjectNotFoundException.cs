using System;

namespace NanoSurvey.API.Exceptions
{
    public class ObjectNotFoundException : InvalidOperationException
    {
        public ObjectNotFoundException(string message) : base(message) { }
    }
}
