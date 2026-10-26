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

    public enum enIssueReasons
    {
        FirstTime = 1,
        RenewLicense,
        LostLicense,
        DamagedLicense
    }

    public class EnumToString
    {
        public static string enIssueReasonsToString(enIssueReasons issueReason)
        {
            switch (issueReason)
            {
                case enIssueReasons.FirstTime:
                    return "First Time";
                case enIssueReasons.RenewLicense:
                    return "Renew License";
                case enIssueReasons.LostLicense:
                    return "Lost License";
                case enIssueReasons.DamagedLicense:
                    return "Damaged License";
            }
            return "Unknown cause";
        }
    }
}
