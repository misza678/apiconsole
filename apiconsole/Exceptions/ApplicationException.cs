using System;
using System.Globalization;

namespace Legacy.Platform.Core.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException() : this(String.Empty) { }

        public ApplicationException(string message) : base(message) { }

        public ApplicationException(string message, params object[] args)
          : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
