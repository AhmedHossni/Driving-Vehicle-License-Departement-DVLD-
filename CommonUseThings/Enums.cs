namespace CommonUseThings
{
    public enum enGettingRecordResult { eError, eUserNotFounded, eUserFounded }
    public enum enPersonGender { Male, Female }

    public enum enApplicationTypes
    {
        NewLocalDrivingLicenseService = 1,
        RenewDrivingLicenseService,
        ReplacementForLostDrivingLicense,
        ReplacementForDamagedDrivingLicense,
        ReleaseDetailedDrivingLicense,
        NewInternationalLicense
    }

    public enum enApplicationStatus
    {
        None = 0,
        New,
        Canceled,
        Completed
    }

}
