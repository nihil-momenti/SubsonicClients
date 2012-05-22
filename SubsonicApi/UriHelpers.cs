using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    internal static class UriHelpers {
        internal static Uri SetParameters(this Uri uri, Dictionary<string, string> parameters) {
            return new Uri(
                uri.ToString()
                + (string.IsNullOrEmpty(uri.Query) ? "?" : "&")
                + string.Join("&", parameters.Select(pair => Uri.EscapeDataString(pair.Key) + "=" + Uri.EscapeDataString(pair.Value)).ToArray()));
        }
    }
}
