
# 🏥 Hospital Patient Treatment Record (ASP.NET Core MVC)

A simple hospital patient management system built using **ASP.NET Core MVC** and **Entity Framework Core**.

You can **add/edit/delete patients**, **upload patient images**, and **manage treatment types dynamically** using a separate dropdown system.  
Basic **login and registration** are implemented using **ASP.NET Identity** (without role-based access).

---

## ✅ Features

- 👤 Patient CRUD operations  
- 🖼️ Patient image upload  
- 📋 Add multiple treatment details per patient (with name and cost)  
- 🔽 Dynamic dropdown for Treatment Types  
- 🔐 Login/Register with ASP.NET Identity  
- 🗂️ Clean MVC architecture using ViewModels and separate Controllers  

---

## 🗃️ Dynamic Dropdown Logic

**Treatment Types** (e.g., Surgery, Diagnostic, Neurology) are stored in a separate table and managed by their own **Controller and Views**.  
You can independently **Create, Edit, or Delete** treatment types from the UI. These will dynamically populate the dropdown in the Patient form.

For example:  
1. Go to `/TreatmentType/Create` → Add "Cardiology"  
2. Now when adding a patient, "Cardiology" will show in the dropdown

---

## 🛠️ Technologies Used

- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server (LocalDB or SQLExpress)  
- Bootstrap (for styling)  
- ASP.NET Identity (for authentication)

---

## ⚙️ Setup Instructions

**1. Download or get the code**

```bash
You can download the source code from the repository or get it using your preferred method.

```

**2. Open the project** in Visual Studio (or Visual Studio Code)

**3. Configure Database**

In `appsettings.json`, set your SQL Server connection string:


**4. Apply Migrations & Update Database**

Open the **Package Manager Console** and run:

```bash
Add-Migration <YourMigrationName>
Update-Database
```

This will generate all necessary tables:  
- Patients  
- TreatmentTypes  
- TreatmentDetails  
- ASP.NET Identity tables

**5. Run the Project**

Press `F5` to launch the application.

---

## 👨‍⚕️ Example Use Cases

- Add a patient with multiple treatments under a selected treatment type  
- Upload a profile image for each patient  
- Dynamically create new treatment types like "Cardiology" or "Psychiatry"  
- View all patient details, including treatment costs and admission status  
- Register and log in to manage patient records (admin-like access, without roles)


---

## 🔐 Authentication Note

This project includes **Login and Registration** functionality using ASP.NET Identity.  
However, **no role-based restrictions** are applied — any logged-in user can manage data.

---

## 📝 Summary

This project is ideal for learning or demonstrating how to build a simple hospital patient management system with dynamic dropdowns, image uploads, and basic user authentication.
