using System.Collections.Generic;
using System.Linq;
using RestSharp;
using SubsonicApi.RestData;

namespace SubsonicApi {
    internal static class SubsonicApiExtensions {
        internal static bool MaybeEquals<T>(this T item, T other) {
            return item == null ? other == null : item.Equals(other);
        }

        internal static bool ListEquals<T>(this List<T> list, List<T> other) {
            if (list == null && other == null) {
                return true;
            } else if (list == null || other == null || list.Count != other.Count) {
                return false;
            }

            return list.Zip(other, (val1, val2) => val1.Equals(val2)).All(result => result);
        }

        internal static int MaybeGetHashCode<T>(this T item) {
            return item == null ? 0 : item.GetHashCode();
        }

        internal static int GetListHashCode<T>(this List<T> list) {
            return list.Aggregate(13, (current, item) => current ^ item.GetHashCode());
        }

        internal static void ThrowOnErrors(this IRestResponse<SubsonicResponseData> response) {
            if (response.ResponseStatus == ResponseStatus.Error) {
                throw new ConnectionException(response.ErrorMessage, response.ErrorException);
            }

            if (!response.Data.IsOk) {
                if (response.Data.Error != null) {
                    throw response.Data.Error.ToException();
                } else {
                    throw new SubsonicServerException();
                }
            }
        }

    }
}
