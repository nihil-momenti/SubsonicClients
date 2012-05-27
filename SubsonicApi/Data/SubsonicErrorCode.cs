using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsonicApi {
    public enum SubsonicErrorCode {
        Generic = 0,
        ParameterMissing = 10,
        ClientMustUpgrade = 20,
        ServerMustUpgrade = 30,
        WrongUserNameOrPassword = 40,
        UserIsNotAuthorizedForTheGivenOperation = 50,
        TrialPeriodExpired = 60,
        RequestedDataNotFound = 70,
    }
}
