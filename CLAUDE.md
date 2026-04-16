# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

ECoffeeApp is a C# WinForms application for managing a coffee shop, built on .NET 8. The UI is entirely in Vietnamese.

## Build & Run

```bash
dotnet build ECoffeeApp.sln
dotnet run --project ECoffee.Presentation
```

### Entity Framework Migrations

```bash
dotnet ef migrations add <MigrationName> --project ECoffee.Infrastructure --startup-project ECoffee.Presentation
dotnet ef database update --project ECoffee.Infrastructure --startup-project ECoffee.Presentation
dotnet ef migrations remove --project ECoffee.Infrastructure --startup-project ECoffee.Presentation
```

Database: SQL Server on `localhost:9999`, database `ECoffeeDb`. Connection string is in `AppDbContext.cs` and `Program.cs`.

## Solution Structure

Three projects following Clean Architecture / DDD:

- **ECoffee.Presentation** (net8.0-windows) — WinForms UI, DI composition root (`Program.cs`), HTML reports
- **ECoffee.Application** (net8.0) — Domain models, DTOs, service layer, repository interfaces, value objects, enums, exceptions
- **ECoffee.Infrastructure** (net8.0) — EF Core entities, repository implementations, `AppDbContext`, migrations

Dependency direction: Presentation → Application ← Infrastructure. Infrastructure references Application; Presentation references both.

## Architecture Pattern (User Management as Reference)

All feature modules follow this pattern. Use the User/Staff module as the template when adding new features:

### Flow: Form → DTO → Service → Domain Model → Repository → Entity → DB

**1. Forms (Presentation/Forms/)** — WinForms injected via DI (`AddTransient` in `Program.cs`). Constructor receives services. Two-form pattern per feature:
- `*ManagementForm` — list view with DataGridView, search timer, CRUD buttons
- `*Form` — detail/create/edit dialog using `FormMode` enum (`Create`/`Edit`)

**2. DTOs (Application/DTOs/)** — `Request/` for input (`Create*Request`, `Update*Request`), `Response/` for output (`*Response`).

**3. Services (Application/Services/)** — Business logic. Injects repository interfaces + `IUnitOfWork` + `IUserContext`. Calls domain methods, then `SaveChangesAsync()` via UoW.

**4. Domain Models (Application/Models/)** — Rich domain objects inheriting `BaseDomain` (Id, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy). Use:
- Private constructor + `Create()` static factory for new instances
- `Rehydrate()` static factory for reconstituting from DB
- Domain methods (e.g., `Rename()`, `Lock()`) that call `Touch(updatedBy)` to update audit fields
- Value Objects (Application/ValueObjects/) for Email, Password validation

**5. Repository Interfaces (Application/Repositories/)** — Define `I*Repository` interfaces. Return domain models for write operations, response DTOs for queries.

**6. Repository Implementations (Infrastructure/Repositories/)** — Use `AppDbContext` + Mapster for mapping. Pattern:
- `Save()`: Map domain → entity via `.Adapt<T>()`, add to DbSet
- `Update()`: Fetch tracked entity, manually map fields, manage relationships
- Query methods: Use `.Include()` + `.Select()` projections, reconstruct domain via `Rehydrate()`

**7. Entities (Infrastructure/Entities/)** — POCO classes inheriting `BaseEntity`, mapped by EF Core conventions. No EF attributes; configured in `AppDbContext.OnModelCreating()`.

### DI Registration (Program.cs)

All new repositories, services, and forms must be registered in `ConfigureServices()`:
- Repositories: `services.AddScoped<I*Repository, *Repository>()`
- Services: `services.AddScoped<*Service>()`
- Forms: `services.AddTransient<*Form>()`

### Mapster Configuration

Register custom mappings in `Infrastructure/Configurations/MapsterConfiguration.Configure()`. Called once at startup in `Program.cs`.

## Key Dependencies

- **EF Core 9** with SQL Server — ORM, HiLo sequence (`global_seq`) for ID generation
- **Mapster** — object mapping (domain ↔ entity)
- **Microsoft.Extensions.DependencyInjection** — DI container
- **PasswordHasher<User>** from ASP.NET Core Identity — password hashing
- **QRCoder** — QR code generation
- **WebView2** — HTML report rendering

## Roles & Routing

Three roles: Manager, Cashier, Barista. `MainForm` provides navigation for all roles. `POSForm` for cashiers, `frmKdsDashboard` for baristas (KDS = Kitchen Display System).

## Custom Exceptions

All in `Application/Exceptions/`: `BadRequestException`, `ConflictException`, `NotFoundException`, `UnauthorizedException`, `ForbiddenException`. Forms catch these and show Vietnamese error messages.
