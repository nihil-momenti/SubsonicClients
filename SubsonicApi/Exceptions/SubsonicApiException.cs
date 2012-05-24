using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SubsonicApi {
    [Serializable]
    public class SubsonicApiException : Exception {
        public SubsonicApiException()
            : base() {
        }

        public SubsonicApiException(string message)
            : base(message) {
        }

        public SubsonicApiException(string message, Exception innerException)
            : base(message, innerException) {
        }

        protected SubsonicApiException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
