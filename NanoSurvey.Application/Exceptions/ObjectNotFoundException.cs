using System;

namespace NanoSurvey.Application.Exceptions
{
    public class ObjectNotFoundException : InvalidOperationException
    {
        public ObjectNotFoundException(string message) : base(message) { }
    }
}
