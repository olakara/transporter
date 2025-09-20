# Transporter

Transporter is a web application built with ASP.NET Core and Blazor. It provides a modern, component-based UI for managing transportation-related tasks.

## Features
- Blazor-based frontend with reusable components
- ASP.NET Core backend
- Docker support for containerized deployment
- Environment-based configuration (Development/Production)

## Project Structure
```
Transporter.sln                # Solution file
Dockerfile                     # Docker container definition
src/
  |_ App.razor                 # Main Blazor app component
  |_ Program.cs                # Application entry point
  |_ Pages/                    # Razor pages (Home, Error, etc.)
  |_ Components/               # Reusable UI components
  |_ Layout/                   # Layout components and styles
  |_ wwwroot/                  # Static assets (CSS, etc.)
  |_ appsettings.json          # App configuration
  |_ Transporter.Web.csproj    # Project file
```

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Node.js and npm](https://nodejs.org/) (if using frontend build tools)
- [Docker](https://www.docker.com/) (optional, for containerization)

### Build and Run Locally
1. Navigate to the `src` directory:
   ```pwsh
   cd src
   ```
2. Restore dependencies:
   ```pwsh
   dotnet restore
   ```
3. Build the project:
   ```pwsh
   dotnet build
   ```
4. Run the application:
   ```pwsh
   dotnet run
   ```
5. Open your browser and navigate to the displayed URL (usually `https://localhost:5001` or `http://localhost:5000`).

### Running with Docker
1. Build the Docker image:
   ```pwsh
   docker build -t transporter .
   ```
2. Run the container:
   ```pwsh
   docker run -p 5000:80 transporter
   ```
3. Access the app at [http://localhost:5000](http://localhost:5000).

## Configuration
- `appsettings.json` and `appsettings.Development.json` are used for configuration.
- Update these files to change connection strings, logging, or other settings.

## Folder Overview
- `Pages/` - Razor pages for the app
- `Components/` - Reusable Blazor components
- `Layout/` - Layout and styling
- `wwwroot/` - Static files (CSS, JS, images)

## License
This project is licensed under the MIT License.
