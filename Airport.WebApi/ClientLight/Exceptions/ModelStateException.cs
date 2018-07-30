namespace ClientLight.Exceptions
{
    using System;
    using System.Collections.Generic;

    using Windows.Web.Http;

    public class ModelStateException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
        
        public ModelStateException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
        public Dictionary<string, string[]> ModelErrors { get; set; }

        public ModelStateException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public ModelStateException(HttpStatusCode statusCode, Dictionary<string, string[]> deserializedErrors)
        {
            StatusCode = statusCode;
            ModelErrors = deserializedErrors;
        }
    }
}
