# HOTEL-MANAGEMENT-SYSTEM

---

## Built With

![C#](https://img.shields.io/badge/-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/-.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET](https://img.shields.io/badge/-ASP.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/-SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Entity Framework](https://img.shields.io/badge/-Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/-Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [System Requirements](#system-requirements)
- [Installation](#installation)
- [Configuration](#configuration)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Overview

A comprehensive hotel management system built with ASP.NET Core that handles:
- Room reservations and allocations
- Guest management and services
- Staff operations and scheduling
- Billing and payment processing
- Inventory and housekeeping management

## Features

### Core Functionality
- **Multi-role Authentication System**
  - Admin: Full system configuration
  - Manager: Operational oversight
  - Reception: Guest operations
  - Housekeeping: Room status management
  - Guest: Self-service portal

- **Room Management**
  - Real-time availability dashboard
  - Room categorization (Standard, Deluxe, Suite)
  - Maintenance scheduling

- **Guest Services**
  - Online check-in/check-out
  - Service requests (housekeeping, amenities)
  - Folio management

### Business Operations
- **Billing System**
  - Automated invoice generation
  - Multiple payment methods
  - Receipt customization

- **Reporting**
  - Occupancy analytics
  - Revenue reports
  - Staff performance

## System Requirements

```bash
# Verify .NET SDK (requires 6.0+)
dotnet --version
```

# Verify SQL Server
```bash
sqlcmd -?  # Should show version info
```
# Verify Node.js (for frontend)
```bash
node -v  # Requires 14+
```

## Installation
1. Clone the repository
```bash
   git clone https://github.com/kidusdybala/HOTEL-MANAGEMENT-SYSTEM.git
cd HOTEL-MANAGEMENT-SYSTEM
```
2. Restore dependencies
   ```bash
   dotnet restore
npm install  # For frontend dependencies
```
4. Configuration
 Set up appsettings.json
  ```bash
# Create configuration file
cp appsettings.Development.json appsettings.json

Edit with your settings:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HotelDB;User Id=sa;Password=yourStrongPassword;"
  },
  "Jwt": {
    "Key": "your-secure-key-32-chars-min",
    "Issuer": "https://localhost:5001",
    "Audience": "https://localhost:5001"
  }
}
```
Database Setup
1. Apply migrations
   ```bash
   dotnet ef database update
```2. Seed initial data (optional)
  ```bash
      dotnet run SeedData
```
## Running the Application
Development Mode
```bash
dotnet watch run
```
## Contributing
Set up development environment
```bash
git checkout -b feature/your-feature
# Make your changes...
```
2.Commit and push
```bash
git add .
git commit -m "Implement new feature"
git push origin feature/your-feature
```
3.pull request
## License
```bash
MIT License - See LICENSE for full text
# Quick license summary
cat LICENSE | head -n 10
```
