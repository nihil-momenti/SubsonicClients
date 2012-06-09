using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Nemo157.Common;

namespace SubsonicApi.Data {
    [CompareByProperties]
    public class SubsonicVersion {
        public int Major { get; internal set; }
        public int Minor { get; internal set; }
        public int Patch { get; internal set; }

        internal static SubsonicVersion Parse(string data) {
            var sections = data.Split('.');
            if (sections.Length != 3) {
                throw new FormatException("The data must be a triple-dotted version string");
            }
            return new SubsonicVersion {
                Major = int.Parse(sections[0], CultureInfo.InvariantCulture),
                Minor = int.Parse(sections[1], CultureInfo.InvariantCulture),
                Patch = int.Parse(sections[2], CultureInfo.InvariantCulture),
            };
        }
    }
}
