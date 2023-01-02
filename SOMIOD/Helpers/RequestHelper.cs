﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;
using SOMIOD.Exceptions;

namespace SOMIOD.Helpers
{
    public class RequestHelper
    {
        public static HttpResponseMessage CreateError(HttpRequestMessage request, Exception exception)
        {
            var httpStatusCode = HttpStatusCode.InternalServerError;

            if (exception is ModelNotFoundException)
                httpStatusCode = HttpStatusCode.NotFound;

            if (exception is UnprocessableEntityException)
                httpStatusCode = (HttpStatusCode) 422;

            return request.CreateErrorResponse(httpStatusCode, exception.Message);
        }


        public static HttpResponseMessage CreateMessage(HttpRequestMessage request, object obj)
        {
            var xmlDoc = XmlHelper.Serialize(obj);
            return request.CreateResponse(HttpStatusCode.OK, xmlDoc, "application/xml");
        }
    }
}
