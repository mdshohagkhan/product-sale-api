# 📦 Product & Sales Management API

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-69217E?style=for-the-badge&logo=dot-net&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-purple?style=for-the-badge&logo=dot-net&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![Database](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

---

## 🌟 Overview

This is a robust **ASP.NET Core Web API** designed for managing products and their associated sales data. Built with **Entity Framework Core**, it provides a comprehensive set of RESTful endpoints for CRUD (Create, Read, Update, Delete) operations on product and sales entities, including relationships.

This API serves as a backend solution for e-commerce platforms, inventory management systems, or any application requiring efficient product and sales data handling.

---

## ✨ Features

* **RESTful API Endpoints**: Full CRUD support for `Product` entities.
* **Sales Relationship**: Seamlessly manage `Sale` data associated with products.
* **Eager Loading**: Retrieve product data along with their related sales using `Include`.
* **Database Integration**: Leverages **Entity Framework Core** for efficient data access and persistence.
* **Swagger/OpenAPI Documentation**: Interactive API documentation for easy testing and understanding of endpoints.
* **Environment-Specific Configuration**: Handles development and production settings appropriately.
* **Image Upload (Potential)**: Integration with `IWebHostEnvironment` suggests capability for file uploads, likely product images.

---

## 🚀 Getting Started

Follow these steps to get a copy of the project up and running on your local machine.

### Prerequisites

Make sure you have the following installed:

* [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later.
* A SQL Server instance (LocalDB, Express, or full SQL Server) or another database supported by Entity Framework Core (configured in `appsettings.json`).
* (Optional but Recommended) A tool like [Postman](https://www.postman.com/downloads/) or your browser for testing API endpoints.

### Installation & Setup

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/mdshohagkhan/product-sale-api.git](https://github.com/mdshohagkhan/product-sale-api.git)
    cd product-sale-api
    ```
    *(If your repository URL is different, please update this line.)*

2.  **Update Database Connection String:**
    Open `appsettings.json` and configure your database connection string under the `ConnectionStrings` section.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProductSaleDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      },
      // ... other settings
    }
    ```
    *Adjust `Server` and `Database` names as per your setup.*

3.  **Apply Migrations:**
    Navigate to the project directory in your terminal and run the following commands to create or update your database schema:
    ```bash
    dotnet ef database update
    ```
    *(If you haven't created initial migrations, you might need to run `dotnet ef migrations add InitialCreate` first, then `dotnet ef database update`)*.

4.  **Restore NuGet Packages:**
    ```bash
    dotnet restore
    ```

5.  **Run the application:**
    ```bash
    dotnet run
    ```
    The API will typically run on `http://localhost:5000` or `http://localhost:5001` (for HTTPS).

---

## 🗺️ API Endpoints

Once the application is running, you can access the API at the base URL (e.g., `http://localhost:5000/api/products`).

### Products (`/api/Products`)

* **`GET /api/Products`**: Get a list of all products.
* **`GET /api/Products/Sales/Include`**: Get a list of all products including their associated sales.
* **`GET /api/Products/{id}`**: Get a product by its ID.
* **`GET /api/Products/{id}/Include`**: Get a product by its ID, including its associated sales.
* **`POST /api/Products`**: Create a new product.
    * **Request Body Example (JSON):**
        ```json
        {
          "productName": "Laptop",
          "price": 1200.00,
          "description": "High-performance laptop",
          "sales": [
            {
              "saleDate": "2025-07-15T10:00:00Z",
              "quantity": 1,
              "totalAmount": 1200.00
            }
          ]
        }
        ```
* **`PUT /api/Products/{id}`**: Update an existing product and its related sales.
    * **Request Body Example (JSON):**
        ```json
        {
          "productId": 1,
          "productName": "Gaming Laptop Pro",
          "price": 1500.00,
          "description": "Updated gaming laptop with more features",
          "sales": [
            {
              "saleId": 101, // Existing SaleId to update
              "saleDate": "2025-07-15T11:00:00Z",
              "quantity": 1,
              "totalAmount": 1500.00
            },
            {
              "saleId": 0, // New Sale (SaleId should be 0 or omitted for new sales)
              "saleDate": "2025-07-16T09:30:00Z",
              "quantity": 2,
              "totalAmount": 3000.00
            }
          ]
        }
        ```
* **`DELETE /api/Products/{id}`**: Delete a product by its ID.

### Swagger UI (Interactive API Documentation)

In your **development environment**, you can access the interactive Swagger UI at:
`http://localhost:5000/swagger` (or your specific port)

---

## 🛠️ Project Structure

* `Controllers/ProductsController.cs`: The main API controller handling product and sales operations.
* `Models/Product.cs`: Entity class for `Product`.
* `Models/Sale.cs`: Entity class for `Sale` (assuming you have this, if not, adjust `README`).
* `Models/ProductDbContext.cs`: Entity Framework Core DbContext for database interaction.
* `Program.cs`: Application startup, service configuration, and middleware setup.
* `appsettings.json`: Configuration file for connection strings and other settings.

---

## 🤝 Contributing

Contributions are welcome! If you have suggestions for improvements or find issues, please:

1.  Fork the repository.
2.  Create a new branch (`git checkout -b feature/YourFeatureName` or `bugfix/FixIssue`).
3.  Make your changes.
4.  Commit your changes (`git commit -m 'feat: Add new feature'`).
5.  Push to the branch (`git push origin feature/YourFeatureName`).
6.  Open a Pull Request.

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---