using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SubsonicApi {
    [Serializable]
    public class ConnectionException : SubsonicApiException {
        public ConnectionException()
            : base() {
        }

        public ConnectionException(string message)
            : base(message) {
        }

        public ConnectionException(string message, Exception innerException)
            : base(message, innerException) {
        }

        protected ConnectionException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
