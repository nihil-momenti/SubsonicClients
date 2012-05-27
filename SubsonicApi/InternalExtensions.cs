using System.Collections.Generic;
using System.Linq;
using RestSharp;
using SubsonicApi.RestData;

namespace SubsonicApi {
    internal static class InternalExtensions {
        internal static void ThrowOnErrors(this IRestResponse<RestData.SubsonicRestResponse> response) {
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
