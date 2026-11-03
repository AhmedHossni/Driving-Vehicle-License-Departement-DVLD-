use DVLD;

GO;

CREATE OR ALTER VIEW PeopleWithCountryName AS
SELECT 
    P.PersonID,
    P.NationalNo,
    P.FirstName,
    P.SecondName,
    P.ThirdName,
    P.LastName,
    P.DateOfBirth,
    CASE P.Gender
        WHEN 0 THEN 'Male'
        ELSE 'Female'
    END AS Gender,
    P.Address,
    p.NationalityCountryID,
    C.CountryName,
    P.Phone,
    P.Email
FROM People AS P
INNER JOIN Countries AS C ON P.NationalityCountryID = C.CountryID;

GO;

CREATE OR ALTER VIEW UsersWithPersonFullName AS
SELECT
    U.UserID,
    P.PersonID,
    CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],
    U.UserName,
    U.IsActive
FROM People AS P
INNER JOIN Users AS U ON P.PersonID = U.PersonID;

GO;

SELECT * FROM Users;

-- is person allow to issue this licese class
SELECT 
    IsEligible = CASE WHEN P.Age >= L.MinimumAllowedAge THEN 1 ELSE 0 END
FROM 
(
    SELECT PersonID, DateOfBirth = DateOfBirth,
        Age = DATEDIFF(YEAR, DateOfBirth, GETDATE()) - 
              CASE 
                  WHEN (MONTH(DateOfBirth) > MONTH(GETDATE())) OR 
                       (MONTH(DateOfBirth) = MONTH(GETDATE()) AND DAY(DateOfBirth) > DAY(GETDATE())) 
                  THEN 1 
                  ELSE 0
              END
    FROM People 
    WHERE PersonID = 2036
) P
CROSS JOIN (
    SELECT MinimumAllowedAge 
    FROM LicenseClasses 
    WHERE LicenseClassID = 1
) L;

---------------------------------------------------------------------
-- Application Queries
GO;

CREATE OR ALTER VIEW LDLApplicationFullInfo AS
SELECT LDL.ApplicationID,
    CONVERT(VARCHAR(10), App.ApplicationDate, 103) ApplicaionDate,
    LDL.LicenseClassID,
    App.PaidFees,
    U.UserName
FROM Applications AS App 
INNER JOIN People AS P
    ON APP.ApplicationPersonID = P.PersonID
INNER JOIN LocalDrivingLicenseApplications AS LDL 
    ON App.ApplicationID = LDL.ApplicationID
INNER JOIN Users AS U 
    ON App.CreatedByUserID = U.UserID;

GO;

SELECT * FROM LDLApplicationFullInfo;

GO;
CREATE OR ALTER FUNCTION dbo.GetApplicationFullInfo(
    @ApplicationID INT) RETURNS TABLE AS RETURN
(
    SELECT Apps.ApplicationID,
           Apps.ApplicationPersonID,
           Apps.ApplicationTypeID,
           Apps.CreatedByUserID,  
           Apps.ApplicationStatus,
           CAST(Apps.ApplicationDate AS DATE) AS ApplicationDate,
           CAST(Apps.LastStatusDate AS DATE) AS LastStatusDate,
           Apps.PaidFees,
           AppTypes.ApplicationTypeTitle,
           CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS 'Full Name',
           U.UserName
    FROM Applications Apps
    INNER JOIN ApplicationTypes AppTypes ON Apps.ApplicationTypeID = AppTypes.ApplicationTypeID
    INNER JOIN People P ON Apps.ApplicationPersonID = P.PersonID
    INNER JOIN Users U ON Apps.CreatedByUserID = U.UserID
    WHERE Apps.ApplicationID = @ApplicationID
);

---------------------------------------------------------------------
-- Lical Driving License Application Queries
GO;

CREATE OR ALTER VIEW LocalDrivingLicenseAppicationListDetails AS
SELECT 
	LDLA.LocalDrivingLicenseApplicationID AS 'L.D.L.AppID',
	'Driving Class' = LC.ClassName,
	P.NationalNo AS 'National No.',
	CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ',P.LastName) AS 'Full Name',
	APPs.ApplicationDate AS 'Application Date',
	'Passed Tests' =
	(SELECT COUNT(*) FROM TestAppointments
		INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
	WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
	AND Tests.TestResult = 1),
	'Status' = CASE APPs.ApplicationStatus
        WHEN 1 THEN 'New'
        WHEN 2 THEN 'Cancel'
        WHEN 3 THEN 'Complete'
        ELSE 'Empty'
    END	
FROM LocalDrivingLicenseApplications LDLA
INNER JOIN LicenseClasses LC
	ON LDLA.LicenseClassID = LC.LicenseClassID
INNER JOIN Applications APPs
	ON LDLA.ApplicationID = APPs.ApplicationID
INNER JOIN People P
	ON APPs.ApplicationPersonID = P.PersonID;

GO;

CREATE OR ALTER FUNCTION dbo.GetLocalDrivingLicenseAppBasicDetails
(
    @LocalDrivingLicenseApplicationID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        LDLA.LocalDrivingLicenseApplicationID AS 'L.D.L.AppID',
        'Driving Class' = LC.ClassName,
        'Passed Tests' = (
            SELECT COUNT(*) 
            FROM TestAppointments
            INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
            WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
              AND Tests.TestResult = 1
        )
    FROM LocalDrivingLicenseApplications LDLA
    INNER JOIN LicenseClasses LC ON LDLA.LicenseClassID = LC.LicenseClassID
    INNER JOIN Applications APPs ON LDLA.ApplicationID = APPs.ApplicationID
    WHERE LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
);

GO;
SELECT * FROM dbo.GetLocalDrivingLicenseAppBasicDetails(30);
GO;

---------------------------------------------------------------------
-- TESTS Appointments QUERIES

-- (The Goal of query) If the user passes the previous test, allow them to schedule a new test.
SELECT CASE
    WHEN EXISTS (SELECT * FROM TestAppointments TA
                INNER JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                WHERE LocalDrivingLicenseApplicationID = 32
                AND TestTypeID = 1 AND IsLocked = 1 AND TestResult = 1)
    THEN 1
    ELSE 0
END AS Result;

-- (The Goal of query) Select Improtant Data For Schedule Test Form
GO;

CREATE OR ALTER FUNCTION dbo.GetTestAppointmentDetails 
(
    @TestAppointmentID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        VT.TestAppointmentID,
        VT.LocalDLAppId,
        VT.ClassName,
        VT.[Full Name],
        VT.Trials,
        VT.Date,
        VT.TestTypeFees,
        [RTAppID] = CASE
            WHEN VT.[R.T.App Id] = VT.TestAppointmentID THEN NULL
            ELSE VT.[R.T.App Id]
        END,
        [RTFees] = CASE
            WHEN EXISTS (SELECT TOP 1 1
                FROM TestAppointments 
                WHERE LocalDLAppId = VT.LocalDLAppId AND TestTypeID = VT.TestTypeID) THEN 5
            ELSE 0
        END,
        VT.IsLocked
    FROM (
        SELECT 
            BaseQuery.*,
            [R.T.App Id] = CASE 
                WHEN Trials > 1 THEN (
                    SELECT TOP 1 TAs.TestAppointmentID 
                    FROM TestAppointments TAs 
                    WHERE TAs.LocalDrivingLicenseApplicationID = BaseQuery.LocalDLAppId
                      AND TAs.TestTypeID = BaseQuery.TestTypeID
                    ORDER BY TAs.AppointmentDate DESC
                )
                ELSE NULL
            END
        FROM (
            SELECT TA.TestAppointmentID,
                TA.LocalDrivingLicenseApplicationID AS LocalDLAppId,
                TA.TestTypeID,
                LC.ClassName,
                CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],                    
                (SELECT COUNT(*) 
                    FROM TestAppointments TAin
                    WHERE TAin.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID 
                      AND TAin.TestTypeID = TA.TestTypeID) AS Trials,
                TA.AppointmentDate AS Date,
                TT.TestTypeFees,
                TA.IsLocked
            FROM TestAppointments TA 
            INNER JOIN LocalDrivingLicenseApplications AS LDLApps
                ON TA.LocalDrivingLicenseApplicationID = LDLApps.LocalDrivingLicenseApplicationID
            INNER JOIN LicenseClasses LC
                ON LDLApps.LicenseClassID = LC.LicenseClassID
            INNER JOIN Applications AS Apps
                ON LDLApps.ApplicationID = Apps.ApplicationID
            INNER JOIN People AS P
                ON Apps.ApplicationPersonID = P.PersonID
            INNER JOIN TestTypes AS TT
                ON TT.TestTypeID = TA.TestTypeID
            WHERE TA.TestAppointmentID = @TestAppointmentID
        ) AS BaseQuery
    ) AS VT
);

GO;

SELECT * FROM GetTestAppointmentDetails(75);


-- (The Goal of query) Select Improtant Data For Shedule Test Form Without TestAppointmentID
SELECT 
    LDLApp.LocalDrivingLicenseApplicationID,
    LC.ClassName,
    CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],
    (SELECT TT.TestTypeFees FROM TestTypes TT WHERE TT.TestTypeID = 1) AS Fees,
    (SELECT COUNT(*) 
                    FROM TestAppointments 
                    WHERE 
                        TestAppointments.LocalDrivingLicenseApplicationID 
                        = LDLApp.LocalDrivingLicenseApplicationID
                        AND TestAppointments.TestTypeID = 2
                    ) AS Trials
FROM LocalDrivingLicenseApplications LDLApp
INNER JOIN LicenseClasses LC ON LDLApp.LicenseClassID = LC.LicenseClassID
INNER JOIN Applications Apps ON LDLApp.ApplicationID = Apps.ApplicationID
INNER JOIN People P ON Apps.ApplicationPersonID = P.PersonID
WHERE LocalDrivingLicenseApplicationID = 31;

GO;
CREATE OR ALTER FUNCTION dbo.GetDrivingLicenseAppScheduleTestInfo
(
    @LocalDrivingLicenseApplicationID INT,
    @TestTypeID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
    LDLApp.LocalDrivingLicenseApplicationID,
    LC.ClassName,
    CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],
    (SELECT TT.TestTypeFees FROM TestTypes TT WHERE TT.TestTypeID = @TestTypeID) AS Fees,
    (SELECT COUNT(*) 
                    FROM TestAppointments 
                    WHERE 
                        TestAppointments.LocalDrivingLicenseApplicationID 
                        = @LocalDrivingLicenseApplicationID
                        AND TestAppointments.TestTypeID = @TestTypeID
                    ) AS Trials
FROM LocalDrivingLicenseApplications LDLApp
INNER JOIN LicenseClasses LC ON LDLApp.LicenseClassID = LC.LicenseClassID
INNER JOIN Applications Apps ON LDLApp.ApplicationID = Apps.ApplicationID
INNER JOIN People P ON Apps.ApplicationPersonID = P.PersonID
WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
);

GO;

SELECT * FROM GetDrivingLicenseAppScheduleTestInfo(37,1);

GO;

-- (The Goal of query) Get All Person Test Appointments By LocalDrivingLicenseApplicationID & TestTypeID
SELECT * FROM TestAppointments 
WHERE LocalDrivingLicenseApplicationID = 31 AND TestTypeID = 1;

-- (The Goal of query) if this local driving license application 
-- id any have test schedule isLocked and result of it is pass the test
GO

CREATE OR ALTER FUNCTION dbo.FN_DoesApplicationHavePassedOrUnlockedTest
(
    @LocalDrivingLicenseApplicationID INT,
    @TestTypeID INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Result INT;

    SELECT @Result = CASE 
        WHEN EXISTS (
            SELECT 1
            FROM TestAppointments TA
            LEFT JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
            WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
              AND TA.TestTypeID = @TestTypeID
              AND (T.TestResult = 1 OR TA.IsLocked = 0)
        ) 
        THEN 1
        ELSE 0 
    END;

    RETURN @Result;
END;
GO

SELECT dbo.FN_DoesApplicationHavePassedOrUnlockedTest(37,1) AS Result;

---------------------------------------------------------------------
-- License Table QUERIES
GO

CREATE OR ALTER FUNCTION IsThisLDLAppHaveLocalDrivingIssue
(
	@LocalDrivingLicenseAppID INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Result INT;

    SELECT @Result = CASE
    WHEN EXISTS(SELECT L.*, LDLApps.LocalDrivingLicenseApplicationID FROM Licenses L
        INNER JOIN LocalDrivingLicenseApplications LDLApps 
        ON L.ApplicationID = LDLApps.ApplicationID WHERE LDLApps.LocalDrivingLicenseApplicationID
            = @LocalDrivingLicenseAppID)
        THEN 1
        ELSE 0
        END
    RETURN @Result;
END;

GO
select * from Licenses

SELECT dbo.IsThisLDLAppHaveLocalDrivingIssue(37) AS Result;

GO

SELECT TOP 1 * FROM Licenses
WHERE ApplicationID = 52;

GO

CREATE OR ALTER PROCEDURE SP_AddNewLocalDrivingLicense
    @ApplicationID INT,
    @DriverID INT,
    @LicenseClass INT,
    @IssueDate DATETIME,
    @Notes NVARCHAR(500),
    @IsActive BIT,
    @IssueReason TINYINT,
    @CreatedByUserID INT,
    @LicenseID INT OUTPUT
AS
BEGIN
    DECLARE @PaidFees SMALLMONEY;
    DECLARE @ExpirationDate DATETIME;

    SELECT @ExpirationDate = 
    DATEADD(year, (SELECT LC.DefaultValidityLength FROM LicenseClasses LC WHERE LicenseClassID = @LicenseClass),
    GETDATE());

    SELECT @PaidFees = CONVERT(SMALLMONEY, LC.ClassFees)
    FROM LicenseClasses LC
    WHERE LC.LicenseClassID = @LicenseClass;

    INSERT INTO [dbo].[Licenses] (
        [ApplicationID],
        [DriverID],
        [LicenseClass],
        [IssueDate],
        [ExpirationDate],
        [Notes],
        [PaidFees],
        [IsActive],
        [IssueReason],
        [CreatedByUserID]
    )
    VALUES (
        @ApplicationID,
        @DriverID,
        @LicenseClass,
        @IssueDate,
        @ExpirationDate,
        @Notes,
        @PaidFees,
        @IsActive,
        @IssueReason,
        @CreatedByUserID
    );

    SET @LicenseID = SCOPE_IDENTITY();
END

-- Get paid fees by applicationID
SELECT CONVERT(SMALLMONEY, (
    SELECT ATs.ApplicationFees 
    FROM ApplicationTypes ATs
    INNER JOIN Applications Apps ON ATs.ApplicationTypeID = Apps.ApplicationTypeID
    WHERE Apps.ApplicationID = 43
));

SELECT * FROM Drivers

-- Get expiration date by license class id and issue date
SELECT ExpirationDate = 
DATEADD(year, (SELECT LC.DefaultValidityLength FROM LicenseClasses LC WHERE LicenseClassID = 1), GETDATE());

SELECT * FROM Drivers D
 INNER JOIN Applications Apps
  ON D.PersonID = Apps.ApplicationPersonID
 INNER JOIN LocalDrivingLicenseApplications LDLApps
  ON Apps.ApplicationID = LDLApps.ApplicationID
WHERE LDLApps.LocalDrivingLicenseApplicationID = 30;

UPDATE [dbo].[Applications]
SET [ApplicationStatus] = 3,
[LastStatusDate] =  GETDATE()
WHERE ApplicationID = (SELECT LDLApp.ApplicationID FROM LocalDrivingLicenseApplications LDLApp
INNER JOIN Applications App ON App.ApplicationID = LDLApp.ApplicationID
WHERE LDLApp.LocalDrivingLicenseApplicationID = 37);

select * from TestAppointments TAs 
where TAs.LocalDrivingLicenseApplicationID = 30 and TestTypeID = 10;

GO

CREATE OR ALTER FUNCTION dbo.GetDriverLicenseInfoByLDLAppID 
(
    @LocalDrivingLicenseApplicationID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 1
        L.LicenseID, 
        LC.ClassName, 
        D.DriverID,
        CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],
        P.NationalNo,
        CASE P.Gender
            WHEN 0 THEN 'Male'
            ELSE 'Female'
        END AS Gender,
        L.IssueDate,
        L.ExpirationDate,
        L.IssueReason,
        L.Notes,
        L.IsActive,
        P.DateOfBirth,
        P.ImagePath,
        CASE 
            WHEN EXISTS (
                    SELECT TOP 1 1
                    FROM DetainedLicenses DL
                    WHERE DL.LicenseID = L.LicenseID AND DL.IsReleased = 0
                    ) THEN 1
                ELSE 0
            END [IsDetained]
        FROM Licenses L
    INNER JOIN LicenseClasses LC 
        ON L.LicenseClass = LC.LicenseClassID
    INNER JOIN Drivers D 
        ON L.DriverID = D.DriverID
    INNER JOIN People P 
        ON D.PersonID = P.PersonID
    INNER JOIN LocalDrivingLicenseApplications LDLApps 
        ON L.ApplicationID = LDLApps.ApplicationID 
    WHERE LDLApps.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
);

GO

SELECT * FROM dbo.GetDriverLicenseInfoByLDLAppID(43)

GO 

CREATE OR ALTER FUNCTION dbo.GetDriverLicenseInfoByApplicationID (
    @ApplicationID INT
)
RETURNS TABLE 
AS 
RETURN 
(
    SELECT TOP 1
        L.LicenseID, 
        L.ApplicationID,
        LC.ClassName, 
        D.DriverID,
        CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],
        P.NationalNo,
        CASE P.Gender
            WHEN 0 THEN 'Male'
            ELSE 'Female'
        END AS Gender,
        L.IssueDate,
        L.ExpirationDate,
        L.IssueReason,
        L.Notes,
        L.IsActive,
        P.DateOfBirth,
        P.ImagePath,
        CASE 
            WHEN EXISTS (
                    SELECT TOP 1 1
                    FROM DetainedLicenses DL
                    WHERE DL.LicenseID = L.LicenseID AND DL.IsReleased = 0
                    ) THEN 1
                ELSE 0
            END [IsDetained]
    FROM Licenses L
    INNER JOIN LicenseClasses LC 
        ON L.LicenseClass = LC.LicenseClassID
    INNER JOIN Drivers D 
        ON L.DriverID = D.DriverID
    INNER JOIN People P 
        ON D.PersonID = P.PersonID
    WHERE L.ApplicationID = @ApplicationID
);

GO;

-- Data for driver local licenses
SELECT
	LicenseID AS [Lic.ID],
	L.ApplicationID AS [App.ID],
	LC.ClassName AS [Class Name],
	L.IssueDate AS [Issue Date],
	L.ExpirationDate AS [Expiration Date],
	L.IsActive AS [Is Active]
FROM Licenses L
INNER JOIN Applications Apps ON  L.ApplicationID = Apps.ApplicationID
INNER JOIN LocalDrivingLicenseApplications LDLApps ON  L.ApplicationID = LDLApps.ApplicationID
INNER JOIN LicenseClasses LC ON  LDLApps.LicenseClassID = LC.LicenseClassID
INNER JOIN People P ON  Apps.ApplicationPersonID = P.PersonID
WHERE P.NationalNo LIKE 'N4';

SELECT 
    L.LicenseID,
    L.ApplicationID,
    LDLApps.LocalDrivingLicenseApplicationID,
    L.LicenseClass,
    L.DriverID
FROM Licenses L
INNER JOIN LocalDrivingLicenseApplications LDLApps 
    ON L.ApplicationID = LDLApps.ApplicationID
WHERE L.LicenseID = 1;

---------------------------------------------------------------------
-- International License Table QUERIES

-- Data for driver international licenses
SELECT 
    IL.InternationalLicenseID AS [Int.License ID],
    IL.ApplicationID AS [Application ID],
    IL.IssuedUsingLocalLicenseID AS [Issue Date],
    IL.IssueDate AS [Issue Date],
    IL.ExpirationDate AS [Expiration Date],
    IL.IsActive AS [Is Active]
FROM InternationalLicenses IL
INNER JOIN Applications Apps
    ON IL.ApplicationID = Apps.ApplicationID
INNER JOIN People P 
    ON Apps.ApplicationPersonID = P.PersonID
WHERE P.NationalNo LIKE 'N4';


SELECT 
    IL.InternationalLicenseID AS [Int.License ID],
    IL.ApplicationID AS [Application ID],
    IL.IssuedUsingLocalLicenseID AS [Issue Date],
    IL.IssueDate AS [Issue Date],
    IL.ExpirationDate AS [Expiration Date],
    IL.IsActive AS [Is Active]
FROM InternationalLicenses IL
WHERE IL.DriverID = 1;

GO

-- not complete
CREATE OR ALTER FUNCTION IsThisLDLAppHaveLocalInternationalDrivingLicense
(
	@LocalDrivingLicenseAppID INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Result INT;

    SELECT @Result = CASE
    WHEN EXISTS(SELECT L.*, LDLApps.LocalDrivingLicenseApplicationID FROM Licenses L
        INNER JOIN LocalDrivingLicenseApplications LDLApps 
        ON L.ApplicationID = LDLApps.ApplicationID WHERE LDLApps.LocalDrivingLicenseApplicationID
            = @LocalDrivingLicenseAppID)
        THEN 1
        ELSE 0
        END
    RETURN @Result;
END;

GO

SELECT
    CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Fullname],
    ILs.InternationalLicenseID,
    ILs.IssuedUsingLocalLicenseID,
    P.NationalNo,
    CASE P.Gender
        WHEN 0 THEN 'Male'
        ELSE 'Female'
    END AS Gender,
    ILs.IssueDate,
    ILs.ApplicationID,
    ILs.IsActive,
    P.DateOfBirth,
    ILs.DriverID,
    ILs.ExpirationDate,
    P.ImagePath
FROM InternationalLicenses ILs
INNER JOIN Applications APPs
    ON ILs.ApplicationID = APPs.ApplicationID
INNER JOIN People P
    ON APPs.ApplicationPersonID = P.PersonID
WHERE ILs.InternationalLicenseID = 12;

SELECT
    ILs.InternationalLicenseID,
    ILs.ApplicationID,
    ILs.DriverID,
    ILs.IssuedUsingLocalLicenseID,
    ILs.IssueDate,
    ILs.ExpirationDate,
    ILs.IsActive,
    D.PersonID
FROM InternationalLicenses ILs
INNER JOIN Drivers D
    ON ILs.DriverID = D.DriverID;

---------------------------------------------------------------------
-- Drivers Table QUERIES
SELECT 
    D.DriverID AS [Driver ID],
    D.PersonID AS [Person ID],
    P.NationalNo AS [National No],
    CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],
    D.CreatedDate AS [Created Date],
    [Active Licenses] 
        = (SELECT COUNT(*) FROM Licenses L WHERE L.DriverID = D.DriverID AND L.IsActive = 1) +
        (SELECT COUNT(*) FROM InternationalLicenses IL WHERE IL.DriverID = D.DriverID AND IL.IsActive = 1)
FROM Drivers D
INNER JOIN People P ON D.PersonID = P.PersonID;

-- Show if license is expired
SELECT
    L.ExpirationDate,
    IsExpired = CASE
        WHEN L.ExpirationDate < GETDATE() THEN 1
        ELSE 0
    END
FROM Licenses L
WHERE LicenseID = 10 AND L.IsActive = 1;

-- Renew control important data for this controller
SELECT
    L.LicenseID, L.PaidFees AS LPaidFees,
    Apps.PaidFees AS AppPaidFees,
    Apps.ApplicationDate, 
    L.IssueDate, L.ExpirationDate, 
    U.UserName AS [CreateBy]
FROM Licenses L
INNER JOIN Applications Apps
    ON L.ApplicationID = Apps.ApplicationID
INNER JOIN Users U
    ON L.CreatedByUserID = U.UserID
WHERE L.LicenseID = 10;

---------------------------------------------------------------------
-- LicenseClasses Table QUERIES

-- Get LicenseClasses info by LicenseClassID
SELECT 
	LicenseClassID,
	ClassName,
	ClassDescription,
	MinimumAllowedAge,
	DefaultValidityLength,
	ClassFees
FROM LicenseClasses 
WHERE LicenseClassID = 1;

---------------------------------------------------------------------
-- DetainedLicenses Table QUERIES

-- Get if this license is detained or not
SELECT
    CASE 
        WHEN EXISTS (
                SELECT TOP 1 1
                FROM DetainedLicenses DL
                WHERE DL.LicenseID = 43 AND DL.IsReleased = 0
                ) 
        THEN 1
        ELSE 0
    END [IsDetained]

-- Get if this license is detained or not
SELECT
    CASE 
        WHEN EXISTS (
                SELECT TOP 1 1
                FROM DetainedLicenses DL
                WHERE DL.DetainID = 43 AND DL.IsReleased = 0
                ) 
        THEN 1
        ELSE 0
    END [IsDetained]

-- Select data for list of detained licenses
SELECT 
    DL.DetainID AS [D.ID],
    DL.LicenseID AS [L.ID],
    DL.DetainDate AS [D.Date],
    DL.IsReleased AS [Is Released],
    DL.FineFees AS [Fine Fees],
    DL.ReleaseDate AS [Release Date], -- nullable
    P.NationalNo AS [N.NO.],
    CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],
    DL.ReleaseApplicationID AS [Releas App.ID] -- nullable
FROM DetainedLicenses DL
INNER JOIN Licenses L 
    ON L.LicenseID = DL.LicenseID
INNER JOIN Drivers D
    ON D.DriverID = L.DriverID
INNER JOIN People P
    ON D.PersonID = P.PersonID;

select * from Licenses

select * from LocalDrivingLicenseApplications

update Licenses
set IsActive = 1
where LicenseID = 35;

delete Licenses
where LicenseID = 37;

delete Applications
where ApplicationID = 108;

select * from Licenses

select * from Applications