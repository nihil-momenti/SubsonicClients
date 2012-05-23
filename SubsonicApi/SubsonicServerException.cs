using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    public class SubsonicServerException : SubsonicApiException {
        public readonly SubsonicErrorCode ErrorCode;

        internal SubsonicServerException(SubsonicError error)
            : base(error.Message) {
                ErrorCode = error.ErrorCode;
        }
    }
}
