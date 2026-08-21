# Database Structure Investigation (`lycevm.db`)

## Discovered Tables
- **Departments**: Stores company departments.
- **Employees**: Stores staff details, contact info, job titles, and assigned departments.
- **Teams**: Stores team structures linked to departments.
- **Customers**: Stores help desk client company details and contacts.
- **Tickets**: Core ticketing records tracking issue statuses, priorities, and assignments.
- **Categories**: Stores self-referencing ticket category hierarchies.

## Schema Details & Relationships

### 1. Departments
- **Primary Key:** `DepartmentId`
- **Nullable Columns:** `Description`
- **Relationships:** One-to-Many with `Employees` and `Teams`

### 2. Employees
- **Primary Key:** `EmployeeId`
- **Foreign Keys:** `DepartmentId` -> `Departments(DepartmentId)`
- **Nullable Columns:** None
- **Relationships:** Many-to-One with `Departments`

### 3. Categories
- **Primary Key:** `CategoryId`
- **Foreign Keys:** `ParentCategoryId` -> `Categories(CategoryId)`
- **Nullable Columns:** `ParentCategoryId` (Root categories have `NULL` parent)
- **Relationships:** Self-referencing (Parent/Child categories)