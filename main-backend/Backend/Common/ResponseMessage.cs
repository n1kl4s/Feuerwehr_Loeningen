using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Backend.Common
{
    public class ResponseMessage
    {
        public static string GetMessage(string message, string errorLevel = "Error", int statusCode = StatusCodes.Status400BadRequest)
        {
            IResponseMessage test = (IResponseMessage)new object();
            test.ErrorLevel = errorLevel;
            test.Message = message;
            test.StatusCode = statusCode;

            return JsonConvert.SerializeObject(test, Formatting.Indented);
        }
    }
}
