using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SubsonicApi.Data {
    public class MusicFolder {
        public MusicFolder() {
        }

        public SubsonicId Id { get; set; }
        public SubsonicId Parent { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<Child> Children { get; set; }
    }
}
