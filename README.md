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
.github/
  |_ workflows/                 # GitHub Actions workflows
src/
  |_ App.razor                 # Main Blazor app component
  |_ Program.cs                # Application entry point
  |_ Pages/                    # Razor pages (Home, Error, etc.)
  |_ Components/               # Reusable UI components
  |_ Layout/                   # Layout components and styles
  |_ wwwroot/                  # Static assets (CSS, etc.)
  |_ appsettings.json          # App configuration
  |_ Transporter.Web.csproj    # Project file
  |_ Dockerfile                # Docker container definition
  |_ package.json              # npm dependencies (Tailwind CSS)
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
2. Install npm dependencies:
   ```pwsh
   npm install
   ```
3. Build CSS assets:
   ```pwsh
   npm run build:css
   ```
4. Restore .NET dependencies:
   ```pwsh
   dotnet restore
   ```
5. Build the project:
   ```pwsh
   dotnet build
   ```
6. Run the application:
   ```pwsh
   dotnet run
   ```
7. Open your browser and navigate to the displayed URL (usually `https://localhost:5001` or `http://localhost:5000`).

### Running with Docker
1. Build the Docker image:
   ```pwsh
   docker build -t transporter src/
   ```
2. Run the container:
   ```pwsh
   docker run -p 5000:8080 transporter
   ```
3. Access the app at [http://localhost:5000](http://localhost:5000).

## CI/CD Pipeline

This project includes a GitHub Actions workflow that automatically:
- Builds the .NET application
- Runs tests
- Creates a Docker image
- Pushes the image to Docker Hub

### Setting up Docker Hub Integration

To enable automatic Docker image publishing, configure the following secrets in your GitHub repository:

1. Go to your repository's Settings → Secrets and variables → Actions
2. Add the following repository secrets:
   - `DOCKER_USERNAME`: Your Docker Hub username
   - `DOCKER_PASSWORD`: Your Docker Hub access token or password

The workflow will automatically build and push Docker images to `docker.io/[your-username]/transporter` when changes are pushed to the main branch.

### Workflow Triggers

- **Pull Requests**: Builds and tests the application
- **Push to main**: Builds, tests, creates Docker image, and pushes to Docker Hub

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
