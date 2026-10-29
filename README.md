# 🚗 Driving & Vehicle License Department (DVLD)

A comprehensive **Windows desktop application** built with **C# (.NET / WinForms)** for managing all operations of a Driving & Vehicle License Department. The system covers the full lifecycle of driving licenses — from applicant registration and test scheduling to license issuance, renewal, replacement, and international license management.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Technology Stack](#technology-stack)
- [Getting Started](#getting-started)
- [Screenshots](#screenshots)
- [License Classes](#license-classes)
- [Application Types](#application-types)

---

## 🌟 Overview

The **DVLD** system digitizes and streamlines the traditionally paper-heavy operations of a government vehicle licensing department. It provides a role-based desktop interface for staff to manage people, applications, driving tests, and licenses — all backed by a structured SQL Server database.

The project was developed as a learning project under the guidance of **Mohamed Abu-hadhoud** as part of the *Fundamentals of Programming* curriculum, demonstrating real-world software engineering practices such as **3-tier architecture**, data encapsulation, and structured error handling.

---

## ✅ Features

### 👤 Person Management
- Add, edit, and delete citizen records
- Store full 4-part names, national ID number, date of birth, gender, address, phone, email, nationality, and profile photo
- Search and filter people list

### 📝 Application Management
- Create and manage service applications for each person
- Track application status: **New**, **Cancelled**, **Completed**
- Prevent duplicate open applications of the same type for the same person
- View full application history per citizen

### 📅 Test Scheduling & Management
Three mandatory sequential tests for new local driving license applicants:
| # | Test Type | Description |
|---|-----------|-------------|
| 1 | **Vision Test** | Checks applicant's eyesight suitability |
| 2 | **Written Test** | Theoretical knowledge of traffic rules |
| 3 | **Practical Test** | On-road driving skill evaluation |

- Schedule test appointments
- Record test results (Pass / Fail)
- Enforce sequential test passing before license issuance
- Manage test fees and retry tracking

### 🪪 Local Driving License Management
- **Issue new licenses** after all 3 tests are passed
- **Renew expiring licenses** with a new application
- **Replace damaged or lost licenses** — each tracked as a separate application type
- Detain (suspend) licenses and manage release
- View full license history for each driver

### 🌍 International License Management
- Issue **International Driving Licenses** linked to an active local license
- List and manage all issued international licenses
- View detailed international license info

### 👥 User & Access Management
- Add, edit, and deactivate system users
- Role-based access control (admin vs. regular users)
- Secure **login system** with username/password authentication
- Change password functionality

### 🗂️ Reference Data
- Manage **License Classes** (categories with minimum age, validity, and fees)
- Manage **Application Types** (fee structure per service type)
- Country lookup for nationality

---

## 🏗️ Architecture

The application follows a strict **3-Tier Architecture** pattern:

```
┌─────────────────────────────────────────┐
│         Presentation Layer              │
│   WinForms UI (Forms, Controls, Views)  │
└───────────────┬─────────────────────────┘
                │
┌───────────────▼─────────────────────────┐
│         Business Logic Layer            │
│  Domain Classes (clsPerson, clsLicense, │
│  clsApplication, clsDriver, ...)        │
└───────────────┬─────────────────────────┘
                │
┌───────────────▼─────────────────────────┐
│         Data Access Layer               │
│  ADO.NET – SQL Server Stored Procedures │
│  (clsPersonData, clsLicenseData, ...)   │
└─────────────────────────────────────────┘
```

| Layer | Project | Responsibility |
|-------|---------|----------------|
| **Presentation** | `DVLD_PresentationLayer` | WinForms UI, user interaction, form navigation |
| **Business Logic** | `DVLD_BusinessLogicLayer` | Domain rules, validations, orchestration |
| **Data Access** | `DVLD_DataAccessLayer` | SQL Server communication via ADO.NET |
| **Shared** | `CommonUseThings` | Shared enumerations and utility classes |

---

## 📁 Project Structure

```
DVLD/
├── CommonUseThings/                    # Shared enums & utilities
│   └── Enums.cs                        # Application-wide enumerations
│
├── DVLD_DataAccessLayer/               # Data Access Layer (DAL)
│   ├── clsPersonData.cs
│   ├── clsApplicationData.cs
│   ├── clsLicenseData.cs
│   ├── clsLocalDrivingLicenseApplicationData.cs
│   ├── clsInternationalLicenseData.cs
│   ├── clsDetainedLicenseData.cs
│   ├── clsDriverData.cs
│   ├── clsTestAppointmentData.cs
│   ├── clsTestData.cs
│   ├── clsTestTypeData.cs
│   ├── clsLicenseClassData.cs
│   ├── clsApplicationTypeData.cs
│   ├── clsUserData.cs
│   ├── clsCountryData.cs
│   └── clsDataAccessSettings.cs        # DB connection string settings
│
├── DVLD_BusinessLogicLayer/            # Business Logic Layer (BLL)
│   ├── clsPerson.cs
│   ├── clsApplication.cs
│   ├── clsApplicationType.cs
│   ├── clsLicense.cs
│   ├── clsLicenseClass.cs
│   ├── clsLocalDrivingLicenseApplication.cs
│   ├── clsInternationalLicense.cs
│   ├── clsDetainedLicense.cs
│   ├── clsDriver.cs
│   ├── clsTestAppointment.cs
│   ├── clsTest.cs
│   ├── clsTestType.cs
│   ├── clsUser.cs
│   └── clsCountries.cs
│
└── DVLD_PresentationLayer/             # Presentation Layer (UI)
    ├── frmLogin.cs                     # Login screen
    ├── frmMain.cs                      # Main dashboard & navigation
    ├── Person/                         # Person management forms
    │   ├── frmPeopleList.cs
    │   ├── frmAddEditPerson.cs
    │   └── frmPersonInfo.cs
    ├── Application/                    # Application type management
    │   └── Application Types/
    ├── Local Driving License/          # Local DL workflows
    │   ├── Applications/
    │   │   ├── frmAddEditLocalDrivingLicenseApplication.cs
    │   │   ├── frmLocalDrivingLicenseApplicationsList.cs
    │   │   ├── frmRenewLicenseApplication.cs
    │   │   └── frmShowLDLAppInfo.cs
    │   └── Control/
    ├── License/                        # License management forms
    │   ├── frmIssueLicense.cs
    │   ├── frmDriverLicenseInfo.cs
    │   ├── Local/
    │   │   ├── frmDetainLicense.cs
    │   │   ├── frmManageDetainedLicensesList.cs
    │   │   ├── frmReleaseDetainedLicense.cs
    │   │   └── frmReplacementForDamagedOrLostLicense.cs
    │   └── International/
    │       ├── frmIssueInternationalLicense.cs
    │       ├── frmInternationalLicensesList.cs
    │       └── frmDriverInternationalLicenseInfo.cs
    ├── Test/                           # Test management forms
    │   ├── Tests/
    │   │   ├── frmScheduleTest.cs
    │   │   ├── frmTakeTest.cs
    │   │   └── frmTestAppointments.cs
    │   └── Test Type/
    ├── Driver/                         # Driver records & history
    │   ├── frmDriversList.cs
    │   └── frmDriverLicenseHistory.cs
    └── User/                           # User account management
        ├── frmUsersList.cs
        ├── frmAddEditUser.cs
        ├── frmChangeUserPassword.cs
        └── frmUserFullInformaion.cs
```

---

## 🗄️ Database Schema

The database schema is visualized below:

![Database Schema](Database%20Schema.png)

Key tables include:

| Table | Description |
|-------|-------------|
| `People` | Core citizen records (name, NID, DOB, contact, photo) |
| `Applications` | All service applications with status & fees |
| `ApplicationTypes` | Reference table for 6 service types |
| `LocalDrivingLicenseApplications` | Tracks new local license applications and test progress |
| `TestAppointments` | Scheduled test sessions per application |
| `Tests` | Individual test results (pass/fail, date, fee) |
| `TestTypes` | Vision, Written, Practical |
| `Licenses` | Issued local licenses with validity, class, and reason |
| `LicenseClasses` | Categories (A, B, C…) with min age, validity, and fees |
| `InternationalLicenses` | Issued international licenses linked to local licenses |
| `DetainedLicenses` | Suspended licenses with release tracking |
| `Drivers` | Driver records linked to a person |
| `Users` | System users with credentials and roles |
| `Countries` | Country lookup for nationality |

---

## 🛠️ Technology Stack

| Component | Technology |
|-----------|-----------|
| **Language** | C# (.NET Framework) |
| **UI Framework** | Windows Forms (WinForms) |
| **Database** | Microsoft SQL Server |
| **Data Access** | ADO.NET (SqlConnection, SqlCommand, SqlDataReader) |
| **Architecture** | 3-Tier (Presentation / Business Logic / Data Access) |
| **IDE** | Visual Studio |

---

## 🚀 Getting Started

### Prerequisites

- **Windows OS** (Windows 10 or later recommended)
- **Visual Studio 2019+** (with .NET Framework support)
- **Microsoft SQL Server** (Express or higher)
- **SQL Server Management Studio (SSMS)** *(optional, for DB inspection)*

### Setup Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/AhmedHossni/Driving-Vehicle-License-Departement-DVLD-.git
   ```

2. **Restore the Database**
   - Open SSMS and connect to your SQL Server instance
   - Create a new database named `DVLD`
   - Run the provided SQL script (or restore from backup if included)

3. **Configure the Connection String**
   - Open `DVLD_DataAccessLayer/clsDataAccessSettings.cs`
   - Update the connection string to point to your SQL Server instance:
     ```csharp
     // Example:
     public static string ConnectionString = 
         "Server=YOUR_SERVER_NAME;Database=DVLD;Integrated Security=True;";
     ```

4. **Build & Run**
   - Open `Driving & Vehicle License Departement (DVLD).slnx` in Visual Studio
   - Set `DVLD_PresentationLayer` as the **Startup Project**
   - Build the solution (`Ctrl+Shift+B`)
   - Run the application (`F5`)

5. **Login**
   - Use the default admin credentials set up in the database to log in

---

## 📸 Screenshots

### Login Screen
![Login Screen](Project%20Screens/Login%20Screen.png)

### Main Dashboard
![Main Screen](Project%20Screens/Main%20Screen.png)

---

## 🪪 License Classes

The system supports multiple driving license categories, each configured with:

| Attribute | Description |
|-----------|-------------|
| `ClassName` | Category identifier (e.g., A, B, C, D) |
| `ClassDescription` | Human-readable description |
| `MinimumAllowedAge` | Minimum applicant age requirement |
| `DefaultValidityLength` | License validity period in years |
| `ClassFees` | Application fee for this class |

---

## 📂 Application Types

Six service types are supported, each mapped to its own workflow:

| # | Application Type | Description |
|---|-----------------|-------------|
| 1 | **New Local Driving License** | First-time license application (requires tests) |
| 2 | **Renew Driving License** | Renewal upon expiry |
| 3 | **Replacement for Lost License** | Replacement with "Lost" reason |
| 4 | **Replacement for Damaged License** | Replacement with "Damaged" reason |
| 5 | **Release Detained License** | Reinstate a suspended license |
| 6 | **New International License** | Issue an international license |

---

## 🔑 Key Business Rules

- A person cannot have **two open applications** of the same type simultaneously.
- A local driving license can only be issued after **passing all three tests** in order (Vision → Written → Practical).
- An **international license** can only be issued if the applicant holds a **valid, active local license**.
- Licenses can be **detained (suspended)** by authorized users and later **released** upon processing a release application.
- License **issue reasons** are tracked: `FirstTime`, `RenewLicense`, `LostLicense`, `DamagedLicense`.
- Each license has a configurable **expiration date** based on the class's default validity length.

---

## 👨‍💻 Author

**Ahmed Hossny**  
Developed as a coursework project under the supervision of **Mohamed Abu-hadhoud**.

---

## 📄 License

This project is intended for **educational purposes**. Feel free to use it as a reference for learning 3-tier architecture with C# and SQL Server.
