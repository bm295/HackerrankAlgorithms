# SampleDotNetApp

ASP.NET Core MVC sample that runs on Kestrel for local development. The app surfaces a health endpoint, version/environment metadata, and rolling logs so that any machine with .NET 10 can clone, build, and run without extra adjustments.

## Prerequisites

1. **.NET 10 SDK (x64)** – used for building, running, and publishing the project.

## Structure

- `SampleDotNetApp.sln` – root solution.
- `src/SampleDotNetApp.Web` – MVC application with `HealthController`, Serilog logging, and configuration files for local Development.
- `tests/SampleDotNetApp.Tests` – xUnit project that exercises `/health` via `WebApplicationFactory`.

## Manual Build + Local Run

Follow these steps to build the solution, publish it manually, and run the published output.

1. From the repository root, restore all dependencies and verify the solution:
   ```powershell
   dotnet restore SampleDotNetApp.sln
   dotnet build SampleDotNetApp.sln
   dotnet test SampleDotNetApp.sln
   ```
2. Publish the web project in Release mode into a standalone folder:
   ```powershell
   dotnet publish src/SampleDotNetApp.Web/SampleDotNetApp.Web.csproj -c Release -o publish
   ```
3. (Optional) Inspect or edit `publish/appsettings.json` if you want to tweak logging or the health message before running locally.
4. Start the published app manually:
   ```powershell
   $env:ASPNETCORE_ENVIRONMENT = "Development"
   dotnet publish\SampleDotNetApp.Web.dll
   ```
   Streaming console output mirrors what you would see when running any .NET host, including the Serilog health log.
5. Navigate to `http://localhost` in a browser to see the home page showing the environment, version, server time, and the latest `/health` payload. You can also hit `http://localhost/health` directly to confirm the JSON response.

If you prefer to keep running via `dotnet run`, use the `--project` flag and pass `--urls` to direct the server to a custom port. Setting `ASPNETCORE_ENVIRONMENT` in the shell ensures the correct `appsettings.*` file is loaded.

## Configuration & Logging

- `appsettings.json` contains the default `Health:WelcomeMessage` plus Serilog settings that write to the console and to `logs/web-.log` (rolling by day, shared for any deployment).
- `appsettings.Development.json` lowers Serilog’s level to `Debug` and customizes the welcome text so local runs stand out.
- Logs are written to the console and to `logs/web-.log` inside the published folder, making it easy to inspect when you run the published app manually or from Kestrel.

## Tests

Run `dotnet test` at the solution root. The xUnit project uses `Microsoft.AspNetCore.Mvc.Testing` to bootstrap the app and assert that `/health` returns `Status=Healthy`.

## Troubleshooting

- **500-level errors when using the published app manually** – check Event Viewer/console output and `logs/web-.log`; ensure the runtime you published with matches the SDK version.
- **Permissions** – verify the account running `dotnet publish\SampleDotNetApp.Web.dll` can read the `publish` folder and that the `logs/` subfolder is writable.
- **Environment configuration** – set `ASPNETCORE_ENVIRONMENT` before launching the DLL to ensure the desired `appsettings.*` file participates.
- **health endpoint fails** – make sure the process is running and listening on `http://localhost`; you can also hit the same endpoint when running with `dotnet run --urls http://localhost:5001`.
- **Logging / stdout** – logs are collected in `logs/web-.log`; ensure the directory exists and is writable if you publish to a fresh folder.

## Helpful Commands

- `dotnet restore`
- `dotnet build`
- `dotnet test`
- `dotnet run --project src/SampleDotNetApp.Web`
