using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class SubsonicId {
        internal string Id { get; private set;}

        public SubsonicId(string id) {
            Id = id;
        }
    }
}
