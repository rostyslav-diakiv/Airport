﻿namespace ClientLight.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using Windows.Web.Http;

    using Newtonsoft.Json.Linq;

    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"application/json";//@text/plain

        public HttpStatusCodeException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString()) { }

        public HttpStatusCodeException(HttpStatusCode statusCode, JObject errorObject) : this(statusCode, errorObject.ToString())
        {
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected HttpStatusCodeException(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
