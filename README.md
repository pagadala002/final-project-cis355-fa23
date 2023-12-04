# CIS 355 Lab 2 

# CIS 355 Lab 2 Project Installation Guide

Welcome to the CIS 355 Lab 2 Project. This README provides a comprehensive guide to setting up your development environment and getting started with Docker for containerization of the project.

## Software and Tools Requirements

To work on this project, you will need the following software and tools installed on your machine:

- [.NET Core SDK](https://dotnet.microsoft.com/download) - Required to build and run the backend services.
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) - Recommended IDE for development with support for C# and .NET.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - The database platform used for storing project data.
- [Docker](https://www.docker.com/products/docker-desktop) - For creating, deploying, and running applications using containers.
- [Git](https://git-scm.com/downloads) - For version control and collaboration.
- [Postman](https://www.postman.com/downloads/) - For testing and interacting with the REST API endpoints.

## Step-by-Step Installation Instructions

### 1. Install .NET Core SDK
   - Download and install the .NET Core SDK from the provided link.
   - Confirm the installation by running `dotnet --version` in your terminal or command prompt.

### 2. Install Visual Studio
   - Follow the installation guide on the official website.
   - Make sure to include the 'ASP.NET and web development' workload during installation.

### 3. Set Up SQL Server
   - Download and install SQL Server following the official guidelines.
   - Optionally, you can use Docker to run SQL Server in a container.

### 4. Install Docker
   - Download Docker Desktop and install it on your system.
   - Ensure Docker is running by checking for the Docker icon in your system tray.

### 5. Install Git
   - Download and install Git using the provided link.
   - Verify the installation with `git --version` in your command line.

### 6. Clone the Project Repository
   - Use `git clone https://github.com/pagadala002/final-project-cis355-fa23.git` to clone the project repository to your local machine.
   - Open the cloned repository in Visual Studio.

### 7. Install Postman
   - Download and install Postman for testing the API endpoints.

### 8. Set Up the Development Environment
   - Within Visual Studio, build the project to restore all NuGet packages.
   - Set up the database connection strings within the `appsettings.json` file.
   - Use Entity Framework migrations to initialize the database schema.

## Docker Setup Instructions

### Creating a Dockerfile

Create a `Dockerfile` in the root directory of your project with the following content, replacing `YourApp.dll` with your project's DLL name:

```Dockerfile
# Use the official Microsoft .NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:latest

# Set the working directory in the container
WORKDIR /app

# Copy the binaries from the publish folder to the workdir in container
COPY ./bin/Release/netcoreapp3.1/publish/ .

# Make port 80 available to the world outside this container
EXPOSE 80

# Run the application when the container launches
ENTRYPOINT ["dotnet", "YourApp.dll"]
