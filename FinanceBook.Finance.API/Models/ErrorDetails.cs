using System.Text.Json.Serialization;

namespace FinanceBook.Finance.API.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string Tag { get; set; }

        [JsonIgnore]
        public string StackTrace { get; set; }

        [JsonIgnore]
        public string TraceId { get; set; }

        public override string ToString()
        {
            return $"TraceID={TraceId}, Message=StatusCode:{StatusCode} {Message} | Tag={Tag} - StackTrace={StackTrace}";
        }
    }
}
