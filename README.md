# e-commerce-app

An eCommerce API built with .NET Core 9 that provides functionalities for product management, user authentication, and order processing. This API serves as the backend for an eCommerce platform.


## Table of Contents

1. [Installation](#installation)
2. [Dependencies](#dependencies)
3. [Usage](#usage)
4. [Features](#features)
5. [Contributing](#contributing)

## Installation

1. Clone the repository:
   git clone https://github.com/yousef547/e-commerce-app.git
   cd ecommerce-api

2. Open the solution in Visual Studio

3. Set up the SQL Server database:
    Make sure you have SQL Server installed and running.
    Create a new database for the application.
    Update the connection string in appsettings.json.

4. Run database migrations (dotnet ef database update)

## Dependencies

This application requires the following dependencies:

.NET Core 9: The framework used to build the API.
Entity Framework Core: An ORM for .NET that allows for data access using SQL Server.
SQL Server: The database management system used to store the application data.
Swashbuckle.AspNetCore: For generating Swagger API documentation.


## Usage
To start the eCommerce API, follow these steps:
1. Open the project in Visual Studio and build the solution.
2. Run the application: (dotnet run).
3. The API will be available at https://localhost:44355 (or as configured).
4. You can view the API documentation at https://localhost:44355/swagger/index.html once the application is running.


## Features
 
1. When the application is run, data is generated in the products table (Data Seeder).
2. Customer (creates , retrieves, retrieves by cutomer id) functionality.
3. Order processing and management.
    create order with more than one product.
    When an order is created, the quantity is deducted from the product's stock.
    update order status.
4. Swagger UI for testing endpoints and checking documentation. 

## Contributing

We welcome contributions! If you'd like to help improve the eCommerce API, please follow these steps:

1. Fork the repository.
2. Create a feature branch:(git checkout -b new-feature).
3. Make your changes and commit them:(git commit -m "Add new feature").
4. Push to the branch:(git push origin new-feature).
5. Open a pull request.





