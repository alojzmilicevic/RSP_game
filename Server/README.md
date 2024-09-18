# Rock Paper Scissors API

This project is a simple implementation of a Rock Paper Scissors game using **ASP.NET Core 8 Web API**. The API allows users to create games, join games, and make moves. The core game logic is handled by a service with an in-memory repository.

## Features

- Create a new game with a player.
- Join an existing game with a second player.
- Make moves for each player and determine the winner.
- The game follows a state-driven approach with validation to ensure the correct game flow.

---

## Prerequisites

Before you can build and run this project, make sure you have the following installed:

- **.NET 8 SDK**: You can download it from [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
- An IDE that supports .NET development:
  - [Visual Studio 2022](https://visualstudio.microsoft.com/) (recommended)
  - [Visual Studio Code](https://code.visualstudio.com/)
  - Or any other code editor that supports .NET 8 projects.

---

## Installation

### Step 1: Extract the Zip File
1. After receiving the `.zip` file, extract its contents to a directory on your machine.

### Step 2: Open the Project in Visual Studio (or another IDE)
1. If you're using **Visual Studio**:
   - Open **Visual Studio** and select **"Open a Project/Solution"**.
   - Navigate to the folder where you extracted the zip and select the `.csproj` file for this project.
   
2. If you're using **Visual Studio Code**:
   - Open **Visual Studio Code**.
   - Choose **File > Open Folder** and select the directory where you extracted the zip file.

---

## Building the Project

To build the project locally, follow these steps:

1. Open the terminal (or use the built-in terminal in your IDE).
2. Navigate to the project folder if you're not already there.
3. Run the following command to restore dependencies and build the project:

```bash
dotnet build
```
## Running the app
```bash
dotnet run
```

This will start the **ASP.NET Core web server**. By default the application will be hosted at:

- **HTTP**: http://localhost:5000
- **HTTPS**: http://localhost:5001

## Swagger UI for API Testing
After the application starts, you can test the API using the Swagger UI at the following URL:
https://localhost:5001/swagger

Swagger provides an interactive interface where you can explore the API and test its endpoints.

