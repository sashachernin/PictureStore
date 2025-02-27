# Picture Store Application

A web application for storing pictures. The application consists of a React frontend and an ASP.NET Web API backend.

## Table of Contents

- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Running with Docker](#running-with-docker)
  - [Running Locally](#running-locally)
    - [Backend Setup](#backend-setup)
    - [Frontend Setup](#frontend-setup)
- [API Documentation](#api-documentation)
- [Technologies Used](#technologies-used)
- [Screenshots](#screenshots)

## Project Structure

The project is organized into two main directories:

```
/PictureStore
│── /Client                  # React frontend
│   ├── src/                 # Source code
│   ├── public/              # Static assets
│   ├── package.json         # Dependencies
│   ├── .env                 # API URL configuration
│
│── /API                     # ASP.NET Core backend
│   ├── PictureStore.API/     # API Controller layer
│   ├── PictureStore.Common/  # Shared entities
│   ├── PictureStore.Data/    # Data access layer
│   ├── PictureStore.Logic/   # Business logic layer
│   ├── appsettings.json      # Configuration file
│
│── docker-compose.yml        # Docker setup
│── README.md                 # Project documentation
```

## Getting Started
### Running with Docker
The easiest way to run the application is with Docker:

1. Download or clone the project repository
2. Navigate to the project root folder
3. Run the following command:

```bash
docker-compose up --build
```

Once the containers are up and running:
- The web application will be available at: http://localhost:3000/
- The API Swagger documentation will be available at: http://localhost:8080/swagger/index.html

### Running Locally
#### Prerequisites
To run the application locally, you need the following:
- SQL Server Express (or any SQL Server instance)
- .NET 8 SDK
- npm

#### Backend Setup

1. Navigate to the API folder, then to the PictureStore.API subfolder
2. Update the connection string in `appsettings.json` to point to your SQL Server instance if needed
3. Run the following command:

```bash
dotnet run
```

The API will be available at: http://localhost:5179/  
Swagger documentation will be available at: http://localhost:5179/swagger/index.html

#### Frontend Setup

1. Navigate to the Client folder
2. Update the API address in the `.env` file to match your backend URL (if different from the default)
3. Install dependencies:

```bash
npm install
```

4. Start the development server:

```bash
npm run dev
```

The application will be available at http://localhost:5173/

## Technologies Used

- **Backend**:
  - ASP.NET Core Web API (.NET 8)
  - Entity Framework Core
  - SQL Server
  
- **Frontend**:
  - React
  - Vite

## Screenshots
![image](https://github.com/user-attachments/assets/802507f9-1d3c-46b6-bb15-370565511cf0)
