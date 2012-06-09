using Nemo157.Common;
using SubsonicApi.Data;

namespace SubsonicApi.RestData {
    [CompareByProperties]
    public class SubsonicError {
        public int? Code { get; set; }
        public string Message { get; set; }

        public SubsonicServerException ToException() {
            return new SubsonicServerException((SubsonicErrorCode)Code, Message);
        }
    }
}
