# 🛒 StoreAPI

A REST API for an e-commerce store, built with **ASP.NET Core** and **Entity Framework Core**. It is the backend for the [storeapp](https://github.com/majid99h/storeapp) Angular front-end.

![.NET](https://img.shields.io/badge/ASP.NET%20Core-2.2-512BD4?logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-2.2-512BD4)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)
![JWT](https://img.shields.io/badge/Auth-JWT-000000?logo=jsonwebtokens)

## ✨ Features

- **Products and categories:** catalog management
- **Cart:** add, update and remove cart items
- **Orders:** place orders and track order details
- **Shipments:** shipment information for orders
- **Users:** login endpoint that issues **JWT** tokens with role claims
- **Excel export** with EPPlus

## 🏗️ Architecture

```
StoreAPI/          → ASP.NET Core Web API (controllers, JWT auth, CORS)
DataAcccess/       → Core: domain entities, EF Core DbContext, repositories, Unit of Work
InfraStructure/    → Shared interfaces and services
```

Patterns used: **Repository**, **Unit of Work** and a generic `BaseResponse` wrapper for API results.

### Domain model
`Product` · `Category` · `Cart` · `CartDetail` · `Order` · `OrderDetail` · `Shipment` · `User`

## 🔌 API endpoints

| Controller | Route |
|---|---|
| Login | `POST /api/Login` |
| Product | `/api/Product` |
| Category | `/api/Category` |
| Cart | `/api/Cart` |
| Order | `/api/Order` |
| Shipment | `/api/Shipment` |

## 🚀 Getting started

1. Restore the sample database from `StoreDB2019.bak` into SQL Server.
2. Update `AppSettings:ConnectionString` in `StoreAPI/appsettings.json`.
3. Add the JWT settings (`Issuer`, `Audience`, `SigningKey`) to your configuration.
4. Run the API:
   ```bash
   dotnet restore
   dotnet run --project StoreAPI
   ```

## 🔗 Related
- Front-end: [storeapp](https://github.com/majid99h/storeapp) (Angular)
