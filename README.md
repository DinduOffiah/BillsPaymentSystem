# BillsPaymentSystem

The Bills Payment System is a software project built using .NET Core C# with a Web API and MS SQL Database. The system facilitates the payment of various bills, such as AIRTIME, DATA, CABLE, and ELECTRICITY, and integrates with two mocked biller agents. The project consists of the following components:

1. Web API:

Implementation of a Web API with endpoints for:
Retrieving a list of available bills.
Submitting a payment for a bill.

2. Database (MS SQL):

Design of a database schema to store information about bills and payments.
Inclusion of tables for bills, payments, and any other necessary entities.
Utilization of Entity Framework Core for data access.

3. Biller Agent Integration:

Creation of two mocked biller agent integrations.
Each biller agent includes methods for:
Retrieving a list of bills.
Submitting a payment for a specific bill.

4. Functionalities:

Users are able to:
View a list of available bills.
Make a payment for a selected bill.
View payment history.
Setting up and Running the Project (Readme):

To set up and run the Bills Payment System project, follow these steps:

Clone the Repository:
Clone the project repository from the provided URL.
bash
Copy code
git clone [repository_url]
Database Setup:

Ensure that MS SQL Server is installed and running.
Update the database connection string in the project's configuration files.
Entity Framework Migrations:

Run Entity Framework Core migrations to create the database schema.
bash
Copy code
dotnet ef database update
Build and Run the Project:
Build the project using the following command:
bash
Copy code
dotnet build
Run the project:
bash
Copy code
dotnet run
Access the API:

Utilize API endpoints to:
Retrieve a list of available bills (GET /api/bills).
Submit a payment for a bill (POST /api/payments).
View payment history (GET /api/payments/history).
