# 📌 Reservation Management System (Web API + WinForms)

## 📖 Overview

This project is a layered **Reservation Management System** built with **ASP.NET Core Web API, Entity Framework Core, Dapper, and Windows Forms (WinForms)**.

It simulates a real-world enterprise architecture where the backend API handles all business logic and database operations, while a desktop client consumes the API for reservation management in real time.

The system includes secure authentication, logging, and full CRUD operations.

---

## 🏗️ Architecture

The solution is designed using a layered architecture approach:

- **WebApi** → REST API (backend service)
- **BLL** → Business logic layer (rules and processing)
- **DAL** → Data access layer (EF Core + Dapper)
- **EL** → Entity / DTO models
- **UI** → Windows Forms client application

This separation ensures scalability, maintainability, and clean code structure.

---

## 🌿 Branch Structure

The project uses multiple branches for development separation:

- **master** → Stable production version
- **api-branch** → Web API development and backend logic
- **ui-branch** → WinForms client integration with API

---

## 🔄 System Workflow

1. User authenticates via API or UI
2. JWT token is generated and returned
3. Token is used for authorized API requests
4. Reservation operations (Create, Read, Update, Delete) are performed
5. EF Core handles database transactions
6. Dapper is used for optimized queries
7. Logs are stored in the database
8. WinForms UI displays and consumes API data

---

## 🚀 Features

- 🔐 JWT Authentication & Authorization
- 🌐 RESTful API architecture
- 🧾 Full Reservation CRUD operations
- 🗄️ Entity Framework Core integration
- ⚡ Dapper for high-performance queries
- 🧠 Clean layered architecture design
- 🪵 Database logging system
- 🖥️ WinForms API client integration
- 🔒 Secure `[Authorize]` protected endpoints

---

## 🛠️ Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- Dapper
- Windows Forms (WinForms)
- SQL Server
- JWT Authentication
- REST API
- LINQ

---

## 🔐 Authentication

This system uses **JWT Bearer Token authentication**:

- Users must log in to receive a token
- The token is required for all protected endpoints
- API endpoints are secured using `[Authorize]` attribute
- Token is validated on every request

---

## 💡 Key Learnings

- Designing real-world REST APIs
- Implementing layered architecture in .NET
- Managing authentication with JWT
- Integrating WinForms with Web APIs
- Combining EF Core and Dapper effectively
- Building scalable backend systems

---

## 📌 Notes

This project is designed as a real-world simulation of an enterprise reservation system.

Potential future improvements:

- Role-based access control
  
---

## 🧠 Summary

This project demonstrates a full-stack .NET ecosystem:

**Web API + Database + Desktop Client + Authentication + Logging**
