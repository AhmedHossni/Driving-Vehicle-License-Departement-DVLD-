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
        None = -1,
        All = 0,
        New,
        Cancel,
        Complete
    }
    public enum enTestTypes
    {
        VisionTest = 1,
        WrittenTest,
        PracticalTest
    }

}
