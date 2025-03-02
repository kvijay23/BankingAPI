using Dapper;
using System.Data;

namespace BankingAPI.Data.Database
{
    public static class DbInitializer
    {
        public static void InitializeDatabase(IDbConnection db)
        {
            var sql = @"
                CREATE TABLE IF NOT EXISTS Customer (
                    CustomerNo INTEGER PRIMARY KEY AUTOINCREMENT,
                    CustomerName TEXT NOT NULL,
                    Address TEXT NOT NULL,
                    PostCode TEXT NOT NULL,
                    City TEXT NOT NULL,
                    Country TEXT NOT NULL,
                    IsActive BOOLEAN NOT NULL DEFAULT 1
                );

                CREATE TABLE IF NOT EXISTS AccountType (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TypeName TEXT UNIQUE NOT NULL,
                    IsEnabled BOOLEAN NOT NULL DEFAULT 1
                );

                CREATE TABLE IF NOT EXISTS CustomerAccount (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    CustomerNo INTEGER NOT NULL,
                    AccountTypeId INTEGER NOT NULL,
                    IsActive BOOLEAN NOT NULL DEFAULT 1,
                    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (CustomerNo) REFERENCES Customer(CustomerNo) ON DELETE CASCADE,
                    FOREIGN KEY (AccountTypeId) REFERENCES AccountType(Id) ON DELETE CASCADE
                );";

            db.Execute(sql);
        }
    }
}
