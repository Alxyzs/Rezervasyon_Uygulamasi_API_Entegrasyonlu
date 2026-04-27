# 📌 Reservation Management System (Web API + WinForms)

## 📖 Overview

This project is a layered reservation management system built with **ASP.NET Core Web API, EF Core, Dapper, and WinForms client integration**.

It demonstrates a full-stack architecture where the backend API handles business logic and database operations, while the Windows Forms application consumes the API for real-time reservation management.

The system includes authentication, logging, and full CRUD operations.

---

## 🏗️ Architecture

The project follows a layered architecture:

- WebApi → REST API backend
- BLL → Business logic layer
- DAL → Data access layer (EF Core + Dapper)
- EL → Entity/DTO models
- UI → Windows Forms client application

---

## 🌿 Branch Structure

This project uses multiple branches for separation of concerns:

- master → stable production version
- api-branch → Web API development and backend logic
- ui-branch → Windows Forms UI integration with API

---

## 🔄 Core Workflow

- User logs in via API or UI
- JWT token is generated
- Token is used for authorized requests
- Reservation CRUD operations are performed
- EF Core manages database changes
- Dapper handles optimized queries
- Logs are stored in the database
- UI displays real-time API data

---

## 🚀 Features

- JWT Authentication & Authorization
- RESTful API structure
- Reservation CRUD operations
- EF Core integration
- Dapper optimized queries
- Layered architecture design
- Database logging system
- WinForms API client
- Secure `[Authorize]` endpoints

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

- JWT Bearer Token is used for authentication
- Users must login to receive token
- Token is required for all protected endpoints
- `[Authorize]` attribute secures API controllers

---

## 💡 Key Learnings

- Building RESTful APIs with .NET
- Layered architecture design principles
- JWT authentication flow
- WinForms + API integration
- EF Core and Dapper hybrid usage
- Real-world backend system structure

---

## 📌 Notes

This project simulates a real-world reservation system architecture used in enterprise applications.

Future improvements may include:
- Role-based authorization
- SignalR real-time updates
- Advanced logging dashboard
- Modern UI redesign (WPF/Web frontend)

---

## 🧠 Summary

This system demonstrates a full-stack .NET architecture combining:

**API + Database + Desktop Client + Authentication + Logging**
