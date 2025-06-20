# BookNestAPI

BookNestAPI is a application designed to help users manage their book collections. It features a .NET backend API for data management for user interaction.

## Features

*   **Book Management:**
    *   Add new books with details like title, author, year published, and read status.
    *   View a list of all books.
    *   Edit existing book details.
    *   Delete books from the collection.
*   **RESTful API:** A backend API built with .NET for handling book data.

## Tech Stack

**Backend:**
*   .NET 9
*   ASP.NET Core
*   Entity Framework Core 9
    *   SQL Server (for production, as per `Microsoft.EntityFrameworkCore.SqlServer`)
    *   In-Memory Database (for development/testing, as per `Microsoft.EntityFrameworkCore.InMemory`)
*   Swashbuckle (for API documentation / Swagger UI)


**Backend:**
*   .NET 9 SDK
*   SQL Server (Optional, if you plan to use it instead of the in-memory database for development)
*   An IDE or text editor (e.g., Visual Studio, VS Code, Rider)


## Setup and Installation

1.  **Clone the repository:**
    ```bash
    git clone <your-repository-url>
    cd BookNestAPI- # Or your main project root directory
    ```

2.  **Backend Setup:**
    *   Navigate to the backend project directory:
        ```bash
        cd BookNestAPI  # Assuming this is the directory with BookNestAPI.csproj
        ```
    *   Restore .NET dependencies:
        ```bash
        dotnet restore
        ```
    *   **(Optional)** If using SQL Server:
        *   Update the connection string in `appsettings.json` (you'll need to create this file if it doesn't exist and configure it in `Program.cs`).
        *   Apply database migrations (if you have any):
            ```bash
            dotnet ef database update

## Running the Application

1.  **Run the Backend API:**
    *   Navigate to the backend project directory (`BookNestAPI`).
    *   Start the API:
        ```bash
        dotnet run
        ```
    *   The API will typically be available at `https://localhost:xxxx` or `http://localhost:yyyy`. Check your `launchSettings.json` or console output for the exact URLs.
    *   You can access the Swagger UI for API documentation, usually at `/swagger`.

## API Endpoints

The backend API provides the following (or similar) endpoints for managing books. Refer to the Swagger UI (`/swagger` on the running API) for detailed information.

*   `GET /api/books` - Retrieves all books.
*   `GET /api/books/{id}` - Retrieves a specific book by ID.
*   `POST /api/books` - Adds a new book.
*   `PUT /api/books/{id}` - Updates an existing book.
*   `DELETE /api/books/{id}` - Deletes a book.

*(Adjust the base path `/api/books` if it's different in your application)*

