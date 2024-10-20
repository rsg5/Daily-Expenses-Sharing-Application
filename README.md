# Daily-Expenses-Sharing-Application

Expense Sharing App
This is an expense-sharing application built with ASP.NET Core, Entity Framework Core, MySQL, and follows a repository pattern for managing users and expenses.

Prerequisites
Before you can run this project, ensure you have the following installed:


.NET 6 SDK
MySQL Server
Git
Visual Studio 2022 or VS Code

Steps to Run the Project
1. Clone the Repository
Clone the GitHub repository to your local machine using the following command:

bash
Copy code
git clone https://github.com/your-username/expense-sharing-app.git
Navigate to the project directory:

bash
Copy code
cd expense-sharing-app
2. Setup MySQL Database
Install MySQL (if not already installed).
Create a database using the following commands:
sql
Copy code
CREATE DATABASE ExpenseSharingDb;
Use ExpenseSharingDb;
Set up your MySQL credentials:
Make sure your MySQL user credentials match those in appsettings.json file.
If needed, update the connection string in the appsettings.json file located in the root of the project:
json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ExpenseSharingDb;User=root;Password=yourPassWord;"
}
You can replace root and yourPassWord with your MySQL username and password, or use environment variables for better security in production environments.

3. Restore Dependencies
Restore the required packages by running:

bash
Copy code
dotnet restore
This command restores the NuGet packages required by the project.

4. Run Database Migrations
To create the necessary tables for the database, apply the migrations with the following command:

bash
Copy code
dotnet ef migrations add InitialCreate
dotnet ef database update
This command will create all necessary tables in the ExpenseSharingDb database based on the ExpenseSharingContext defined in the project.

Note: If you haven't installed the EF Core CLI tools, you can do so with:

bash
Copy code
dotnet tool install --global dotnet-ef
5. Build and Run the Application
To build and run the application, use the following commands:

bash
Copy code
dotnet build
dotnet run
This will start the application on https://localhost:5001 (or http://localhost:5000).

6. Access the API
You can now access the API endpoints through the following routes:

Create a User: POST /api/users
Get User by ID: GET /api/users/{id}
Add an Expense: POST /api/expenses
Get Expenses for a User: GET /api/expenses/user/{userId}
You can use tools like Postman or curl to interact with the API.

7. Swagger API Documentation (Optional)
Swagger is configured for easy API testing. Once the application is running, you can access Swagger UI at:

bash
Copy code
https://localhost:5001/swagger/index.html
This will give you a user-friendly interface to test API endpoints.




Folder Structure
Controllers: Contains the UsersController and MVCController for handling HTTP requests.
Models: Contains the domain models User, Expense, ExpenseParticipant.
Repositories: Contains repository interfaces and implementations to perform CRUD operations on the database.
appsettings.json: Contains the database connection string.
Common Errors
Invalid Connection String:

Ensure that the MySQL server is running and the credentials in appsettings.json are correct.
EF Migrations Not Applied:

If you receive an error regarding the database tables, make sure you have run the migrations using:
bash
Copy code
dotnet ef database update
Contributing
Feel free to contribute to this project by submitting issues or pull requests.

License
This project is open-source and available under the MIT License.
