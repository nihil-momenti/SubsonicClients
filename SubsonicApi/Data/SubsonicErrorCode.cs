
namespace SubsonicApi.Data {
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
