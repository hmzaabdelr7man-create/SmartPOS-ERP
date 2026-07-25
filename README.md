# Smart POS ERP

A modular, multi-tenant-ready point-of-sale and ERP desktop application built on **.NET 8** and **WPF**, following Clean Architecture and the MVVM pattern.

> **Status:** Sprint 2 — Core architecture established. The layering has been restructured around a dependency-free `SmartPOS.Core` and a shared-contracts `SmartPOS.Contracts` assembly. Business domain entities, real authentication, and feature implementations arrive in later sprints.

---

## Table of Contents

- [Overview](#overview)
- [Technology Stack](#technology-stack)
- [Solution Architecture](#solution-architecture)
- [Project Structure](#project-structure)
- [Architectural Decisions](#architectural-decisions)
- [Dependency Graph](#dependency-graph)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Theming & Localization](#theming--localization)
- [Feature Modules](#feature-modules)
- [Database](#database)
- [Testing](#testing)
- [Coding Standards](#coding-standards)

---

## Overview

Smart POS ERP is a Windows desktop application designed for retail point-of-sale operations with ERP capabilities. The foundation establishes a robust, maintainable architecture that supports:

- **Clean Architecture** with strictly inward-only dependencies and no circular references.
- **CQRS** via MediatR for separating read and write concerns.
- **Multi-database support** — SQLite for local deployments and PostgreSQL for server deployments.
- **Bilingual UI** — Arabic (RTL) and English (LTR) with runtime switching.
- **Light/Dark theming** with runtime switching and persistence.
- **Pluggable feature modules** discovered and registered at startup.
- **A dependency-free Core** that owns base entities, the `Result`/`Error` primitives, constants, enums, configuration options, guard clauses, helpers, and extensions.
- **A shared Contracts assembly** that decouples the UI from the Application layer by owning cross-layer interfaces (theme, language, settings, exception handling).

## Technology Stack

| Concern              | Choice                                                          |
| -------------------- | --------------------------------------------------------------- |
| Runtime / Target     | .NET 8, WPF (`net8.0-windows`)                                  |
| Architecture         | Clean Architecture (12 projects)                               |
| UI pattern           | MVVM via CommunityToolkit.Mvvm (source generators)             |
| Application hosting  | Microsoft.Extensions.Hosting / DI / Configuration              |
| CQRS                 | MediatR 12 + FluentValidation pipeline behavior                |
| Object mapping       | AutoMapper                                                      |
| Persistence          | Entity Framework Core 8 — SQLite (default) + PostgreSQL (Npgsql)|
| Logging              | Serilog (Console + rolling file)                                |
| Reporting            | QuestPDF (Community license)                                    |
| Barcode generation   | ZXing (Code 128, EAN-13) + QRCoder (QR codes)                   |
| Backup               | File-based ZIP archives with retention pruning                  |
| Testing              | xUnit + FluentAssertions + Moq + EF Core InMemory               |
| Package management   | Central (`Directory.Packages.props`)                            |

## Solution Architecture

The solution follows the Clean Architecture dependency rule: dependencies point **inward** only. No inner layer references an outer layer. `SmartPOS.Core` sits at the center with zero project dependencies; `SmartPOS.Contracts` depends only on Core and is referenced by any layer that needs its shared interfaces.

```
Core  ──►  Domain  ──►  Application  ──►  Database
 │                              ▲      ──►  Infrastructure ──► Feature Modules
 │                              │             ▲
 └──►  Contracts  ◄─────────────┴─────────────┘
                                  ▲
                                 UI  (WPF — composition root)
```

- **Core** — `BaseEntity`, `BaseAuditableEntity`, `Result`, `Error`, constants, enums, configuration options, guard clauses, helpers, and extensions. Depends on nothing.
- **Contracts** — cross-layer shared interfaces: `IThemeService`, `ILanguageService`, `ISettingsService`, `IExceptionHandler`, `ErrorInfo`, `ErrorSeverity`. Depends on Core only.
- **Domain** — repository/unit-of-work abstractions, specifications, and domain exceptions. Depends on Core only (entities and common interfaces live in Core).
- **Application** — use-case abstractions, CQRS base types (commands/queries), validation pipeline behavior, exception handling implementation, and feature service interfaces (barcode, backup, printing, reporting). Depends on Core, Contracts, and Domain.
- **Database** — the EF Core `AppDbContext`, audit/soft-delete conventions, and provider factories (SQLite/PostgreSQL). Depends on Core and Domain.
- **Infrastructure** — repository and unit-of-work implementations, Serilog configuration, file-backed settings service, headless theme/language services, and the `IFeatureModule` plug-in contract. Depends on Application, Contracts, Database, Domain, and Core.
- **Feature Modules** — each implements `IFeatureModule.Register` and is discovered by `AddInfrastructure`. Each depends on Application, Infrastructure, and Core.
- **UI** — the WPF composition root: `App.xaml.cs` builds the host, wires all layers, and manages the SplashScreen → Login → Shell window flow. Depends on Contracts, Core, Infrastructure, Database, and the four feature modules (no direct dependency on Application).

## Project Structure

```
SmartPOS-ERP/
├── SmartPOS-ERP.sln
├── Directory.Build.props          # Shared build properties (LangVersion, Nullable, WarningsAsErrors)
├── Directory.Packages.props       # Central NuGet package version management
├── .editorconfig                  # C# coding conventions and naming rules
├── src/
│   ├── SmartPOS.Core/             # BaseEntity, BaseAuditableEntity, Result, Error, Constants, Enums, Configuration, Guards, Helpers, Extensions
│   ├── SmartPOS.Contracts/        # IThemeService, ILanguageService, ISettingsService, IExceptionHandler, ErrorInfo, ErrorSeverity
│   ├── SmartPOS.Domain/           # IRepository<T>, IUnitOfWork, ISpecification, DomainException, IAggregateRoot (via Core)
│   ├── SmartPOS.Application/      # CQRS, Exceptions, ExceptionHandler impl, Abstractions (barcode/backup/printing/report), Mapping, DI
│   ├── SmartPOS.Database/         # AppDbContext, SoftDeleteConvention, Provider factories, DI
│   ├── SmartPOS.Infrastructure/   # Repository, UnitOfWork, Serilog, SettingsService, NullTheme/Language services, IFeatureModule, DI
│   ├── SmartPOS.Barcode/          # BarcodeFeatureModule + ZXing/QRCoder generator
│   ├── SmartPOS.Backup/           # BackupFeatureModule + FileBackupService
│   ├── SmartPOS.Printing/         # PrintingFeatureModule + WindowsPrintService
│   ├── SmartPOS.Reporting/        # ReportingFeatureModule + QuestPDF renderer
│   ├── SmartPOS.UI/               # WPF: App, Views, ViewModels, Navigation, Services, Themes, Localization
│   └── SmartPOS.Tests/            # xUnit test project
└── README.md
```

## Architectural Decisions

- **Dependency-free Core** — `SmartPOS.Core` owns primitives (`BaseEntity`, `BaseAuditableEntity`, `Result`, `Error`), enums, configuration options, constants, guard clauses, helpers, and extensions. Every other layer may reference Core, and Core references nothing. This eliminates the previous `SmartPOS.Shared` assembly and centralizes all foundational types in a single inward-most layer.
- **Shared Contracts decouple UI from Application** — `SmartPOS.Contracts` owns the interfaces the UI needs (`IThemeService`, `ILanguageService`, `ISettingsService`, `IExceptionHandler`) plus `ErrorInfo`/`ErrorSeverity`. The UI references Contracts directly and reaches Application only transitively through Infrastructure, removing the previous direct UI→Application dependency.
- **Clean Architecture** — each layer has a single responsibility and depends only on inner layers. No circular references exist in the dependency graph.
- **CQRS with MediatR** — commands and queries are distinct types, routed through a mediator with a validation pipeline behavior.
- **Repository + Unit of Work** — generic `IRepository<T>` and `IUnitOfWork` abstract EF Core behind domain-owned contracts.
- **Soft delete + audit conventions** — entities implementing `ISoftDeletable` are filtered out of queries and marked rather than removed; `BaseEntity` stamps `CreatedAtUtc` / `UpdatedAtUtc` automatically via `SaveChanges` overrides.
- **Feature modules** — cross-cutting features (barcode, backup, printing, reporting) are self-contained assemblies that register their services through `IFeatureModule`.
- **Central package management** — all NuGet versions are pinned in `Directory.Packages.props`.
- **Treat warnings as errors** — enforced in `Directory.Build.props`.

## Dependency Graph

```
SmartPOS.Core          → (none)
SmartPOS.Contracts     → Core
SmartPOS.Domain        → Core
SmartPOS.Application   → Core, Contracts, Domain
SmartPOS.Database      → Core, Domain
SmartPOS.Infrastructure→ Application, Contracts, Database, Domain, Core
SmartPOS.Barcode       → Application, Infrastructure, Core
SmartPOS.Backup        → Application, Infrastructure, Core
SmartPOS.Printing      → Application, Infrastructure, Core
SmartPOS.Reporting     → Application, Infrastructure, Core
SmartPOS.UI            → Contracts, Core, Infrastructure, Database, Backup, Barcode, Printing, Reporting
SmartPOS.Tests         → Application, Contracts, Core, Domain, Infrastructure
```

No circular references: Core is the root, every path terminates at Core, and no layer references an outer layer.

## Getting Started

### Prerequisites

- Windows 10/11 (the UI project targets `net8.0-windows` and uses WPF).
- .NET 8 SDK.
- Visual Studio 2022 (17.8+) or the .NET CLI.

### Build

```bash
dotnet restore SmartPOS-ERP.sln
dotnet build SmartPOS-ERP.sln
```

### Run

```bash
dotnet run --project src/SmartPOS.UI/SmartPOS.UI.csproj
```

On startup the application shows a splash screen, then the login window. The foundation's login accepts any non-empty username and password; real authentication is a later-sprint concern.

### Tests

```bash
dotnet test src/SmartPOS.Tests/SmartPOS.Tests.csproj
```

## Configuration

The application reads two JSON files from the output directory:

- `appsettings.json` — shipped defaults.
- `appsettings.user.json` — optional user overrides (created on first preference change; takes precedence at runtime).

Sections: `Database`, `Theme`, `Language`, `Company`, `Printer`, `Backup`, `Serilog`. User-scoped theme and language preferences persist across restarts.

## Theming & Localization

- **Themes** — `Themes/LightTheme.xaml` and `Themes/DarkTheme.xaml` define color brushes, fonts, corner radii, and control styles. The `WpfThemeService` swaps the merged resource dictionary at runtime and raises a `ThemeChanged` event.
- **Localization** — `Resources/Localization/Strings.ar.xaml` and `Strings.en.xaml` hold all UI string resources. The `WpfLanguageService` swaps the resource dictionary, sets the current culture, and toggles flow direction (RTL for Arabic, LTR for English).

Both choices persist across restarts through the settings service.

## Feature Modules

| Module      | Interface             | Implementation          | Status                |
| ----------- | --------------------- | ----------------------- | --------------------- |
| Barcode     | `IBarcodeGenerator`   | `BarcodeGenerator`      | Implemented (ZXing + QRCoder) |
| Backup      | `IBackupService`      | `FileBackupService`     | Implemented (ZIP + retention) |
| Printing    | `IPrintService`       | `WindowsPrintService`   | Stub (logs the job)   |
| Reporting   | `IReportRenderer`     | `QuestPdfReportRenderer`| Stub (returns text)   |

## Database

The `DatabaseOptions.Provider` setting selects the engine:

- **SQLite** (default) — embedded, file-based. The backup service archives the SQLite data file into a dated ZIP under the configured `Backup.DestinationFolder`.
- **PostgreSQL** — server-based. Selected when `Provider` is `PostgreSql`; connection string taken from `PostgreSqlConnectionString`.

`AppDbContext` applies audit timestamps and soft-delete filters automatically. `AutoMigrate` runs EF Core migrations on startup when enabled.

## Testing

The test project (`SmartPOS.Tests`) is configured with xUnit, FluentAssertions, Moq, and EF Core InMemory. Tests will be added alongside domain entity and use-case implementations in subsequent sprints.

## Coding Standards

- `TreatWarningsAsErrors` and `EnforceCodeStyleInBuild` are enabled solution-wide.
- `.editorconfig` enforces file-scoped namespaces, `var` usage, pattern matching, braces, and Pascal-case naming.
- XML documentation comments are required on all public APIs.
- Line endings are CRLF; UTF-8 charset; trailing whitespace trimmed.
