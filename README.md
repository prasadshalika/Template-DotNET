# Template-DotNET

A .NET Web API application template with PostgreSQL integration.

---

## Features

- RESTful API for resource management.
- PostgreSQL support using `Npgsql` and optional `Entity Framework Core`.
- JSON-based data exchange.
- Built-in Swagger UI for API documentation and testing.

---

## Tech Stack

- **Backend:** .NET 8 Web API
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core
- **API Documentation:** Swagger

---

## NuGet Packages

The following NuGet packages are used in this project:

| Package                                   | Description                                         |
|-------------------------------------------|-----------------------------------------------------|
| `Npgsql`                                  | PostgreSQL database driver for .NET.               |
| `Microsoft.EntityFrameworkCore`           | Entity Framework Core ORM framework.               |
| `Microsoft.EntityFrameworkCore.Design`    | EF Core design-time tools (e.g., migrations).      |
| `Npgsql.EntityFrameworkCore.PostgreSQL`   | EF Core provider for PostgreSQL.                   |
| `Swashbuckle.AspNetCore`                  | Swagger integration for Web APIs.                  |
| `Newtonsoft.Json` (optional)              | Advanced JSON serialization/deserialization.       |

---

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download)

---

### Setup Instructions

1. **Clone the repository**:
	```bash
	   git clone https://github.com/prasadshalika/Template-DotNET.git
	   cd Template-DotNET
    ```
	**This will:**
	 - Download the project code from the repository.
	 - Navigate into the project directory.
   
2. **DB Migration**
    - The application uses PostgreSQL as the default database. Before running the application, set up the database schema by performing migrations.	
	**Database Configuration**
	- The database connection string is configured in the appsettings.json file. The default configuration is:
	  ```bash
	     "DefaultConnection": "Server=localhost;Port=5433;Database=test;Username=penta;Password=penta"
	  ```
	- Ensure PostgreSQL is running on your system.
	- Update the appsettings.json file if your database credentials or server address differ.

3. **Steps to Apply Migrations**
	1. Add a Migration:
	 - Open the terminal or Package Manager Console in Visual Studio and run:
		```bash
	       dotnet ef migrations add InitialCreate
	    ```
		- This generates migration scripts for the database tables based on the entity models.

    2. Apply Migrations to the Database:
		- Run the following command to update the database schema:
		```bash
	       dotnet ef database update
	    ```
	    - This will create the required tables in your PostgreSQL database.

4. Run Docker Compose
    - The project uses Docker Compose for containerized deployment.

	**Steps to Start the Application**
	  - Verify File Paths
	  - Ensure that the file paths in docker-compose.yml and Dockerfile are correctly set to match your project structure.	

	** Build and Run Containers **
	  - Build the necessary Docker images and start the containers.
	  ```bash
	     docker-compose up -d
	  ```
5.**Access the Application**
  - Open your browser and navigate to:  
	- http://localhost:5051/swagger/index.html