using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    public class SubsonicApiException : Exception {
        internal SubsonicApiException()
            : this("", null) {
        }

        internal SubsonicApiException(string message)
            : this(message, null) {
        }

        internal SubsonicApiException(Exception innerException)
            : this("", innerException) {
        }

        internal SubsonicApiException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }
}
