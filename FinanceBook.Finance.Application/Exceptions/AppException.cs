using System;

namespace FinanceBook.Finance.Application.Exceptions
{
    public class AppException : Exception
    {
        public virtual int StatusCode { get; protected set; }

        public virtual string Tag { get; protected set; }

        public AppException(int statusCode, string tag, string message, Exception innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            Tag = $"<{tag}>";
        }
    }
}
