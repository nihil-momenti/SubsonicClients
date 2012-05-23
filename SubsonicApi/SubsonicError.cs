using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    public class SubsonicError {
        public int Code { get; set; }

        public SubsonicErrorCode ErrorCode {
            get {
                return (SubsonicErrorCode)Code;
            }
        }

        public string Message { get; set; }
    }
}
