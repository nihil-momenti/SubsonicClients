using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SubsonicApi.Data;

namespace SubsonicApi {
    [Serializable]
    public class SubsonicServerException : SubsonicApiException {
        public SubsonicErrorCode ErrorCode { get; private set; }

        public SubsonicServerException()
            : base() {
        }

        public SubsonicServerException(string message)
            : base(message) {
        }

        public SubsonicServerException(string message, Exception innerException)
            : base(message, innerException) {
        }

        public SubsonicServerException(SubsonicErrorCode code, string message)
            : base(message) {
                ErrorCode = code;
        }

        protected SubsonicServerException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
                ErrorCode = (SubsonicErrorCode)info.GetValue("ErrorCode", typeof(SubsonicErrorCode));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);
            info.AddValue("ErrorCode", ErrorCode);
        }
    }
}
