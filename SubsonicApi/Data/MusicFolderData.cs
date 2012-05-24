using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi.Data {
    internal class MusicFolderData : IEquatable<MusicFolderData> {
        public string Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj) {
            return Equals(obj as MusicFolderData);
        }

        public override int GetHashCode() {
            return Id.MaybeGetHashCode() ^ Name.MaybeGetHashCode();
        }

        public bool Equals(MusicFolderData other) {
            if (other == null) {
                return false;
            }

            return Id.MaybeEquals(other.Id) && Name.MaybeEquals(other.Name);
        }
    }
}
