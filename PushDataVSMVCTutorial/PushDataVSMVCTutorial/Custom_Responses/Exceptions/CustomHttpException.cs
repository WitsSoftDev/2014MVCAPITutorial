using System;
using System.Net;

namespace PushDataVSMVCTutorial.Custom_Responses.Exceptions
{
    public class CustomHttpException : Exception
    {
      public HttpStatusCode StatusCode { get; set; }
      public string Reason { get; set; }
      public string ResponseBody { get; set; }
    }
}