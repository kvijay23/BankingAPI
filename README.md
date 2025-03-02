# Banking Solutions

This document outlines improvements for the Banking API, which is built using .NET 8, SQLite, Dapper, and follows Clean Architecture principles. The API manages customer accounts, supports different account types, and allows freezing accounts.

## Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022

## Getting Started

### Clone the Repository

git clone https://github.com/kvijay23/BankingAPI.git

### Build the Solution

Open the solution in Visual Studio 2022 and build the entire solution to restore the necessary packages and compile the projects.

### Running the Application

1. Set BankingAPI.Services` as the startup project.
2. Run the application using Visual Studio or the .NET CLI:


### Running Unit Tests

To run the unit tests, you can use the Test Explorer in Visual Studio or the .NET CLI:


**Future Improvements**

Authentication and Authorization

Add try-catch blocks for proper error handling.

Implement transaction support when inserting/updating multiple records.

Minimal APIs lack validation and structured responses.

Missing logging for request tracking and debugging.

No pagination in GET endpoints, which can cause performance issues.

Use FluentValidation to validate incoming requests.

No logging framework is used, making debugging difficult.

No monitoring tools are integrated.

No database migration strategy exists.
