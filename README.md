## ASP.NET Core Web API

A robust, production-ready Products CRUD Web API built with **ASP.NET Core 8.0/9.0** following **Clean Architecture** principles. This project serves as an end-to-end demonstration of object-oriented programming (OOP), enterprise design patterns, and secure database integration.

## Core Concepts

- **Clean Architecture:** Strict isolation of HTTP concerns from data access using the Repository Pattern.
- **Dependency Injection (DI):** Uses constructor injection. Demonstrates understanding of service lifetimes (`Scoped` database contexts vs `Transient` or `Singleton` utilities).
- **Decoupled Data Layer:** Proven ability to swap data providers. Transitioned seamlessly from an in-memory mock store to a real SQLite database by changing a single line in `Program.cs`.
- **Mass-Assignment Protection:** Utilizes Data Transfer Objects (DTOs) instead of exposing raw domain models to prevent over-posting vulnerabilities.
- **RESTful API Best Practices:** Correct implementation of HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`) and semantic status codes (`200 OK`, `201 Created`, `204 No Content`, `404 Not Found`).
- **Advanced LINQ & EF Core:** Leverages LINQ expressions (`Where`, `Select`, `FirstOrDefault`) compiled efficiently into optimized SQL queries via Entity Framework Core.

## 🛠️ Tech Stack

- **Framework:** .NET Core Web API
- **ORM:** Entity Framework Core
- **Database:** SQLite
- **Language:** C#
