using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class SubsonicError {
        public int Code { get; set; }
        public string Message { get; set; }

        public SubsonicServerException ToException() {
            return new SubsonicServerException((SubsonicErrorCode)Code, Message);
        }
    }
}
