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

- **Backend:** .NET 6/7/8 Web API
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core (optional)
- **API Documentation:** Swagger (Swashbuckle)

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

- [.NET SDK](https://dotnet.microsoft.com/download) (6 or later)
- [PostgreSQL](https://www.postgresql.org/download)

---

### Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-repo-name.git
   cd Template-DotNET```

