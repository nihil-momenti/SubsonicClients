using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    public class ConnectionException : SubsonicApiException {
        internal ConnectionException()
            : this("", null) {
        }

        internal ConnectionException(string message)
            : this(message, null) {
        }

        internal ConnectionException(Exception innerException)
            : this("", innerException) {
        }

        internal ConnectionException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }
}
