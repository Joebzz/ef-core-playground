# ef-core-playground
The purpose of this repository is to learn Entity Framework Core Code First, including migrations.

I will be creating a basic Employee Database.

Below are some of the things I will be testing with Entity Framework Migrations:
1. Create a basic Employee DB
   * Works As Expected
2. Migrate DB with Seed Data
   * NOTE: When Seeding Data it recommends using negative numbers to avoid conflicts with non-seeded data
3. Add data to DB after migration – shouldn’t effecting Seed data.
   * Works As Expected
4. Add a new Migrations with new field – shouldn't effect existing data (might need to change seed data) 
   * Needed to update Seeded Data and set defaults for non-seeded data for non-nullable fields
5. Backup Database and Restore as 'Employees_Production'
6. Add a new Migrations with new foreign key (Office entity) – shouldn't effect existing data (might need to change seed data)
   * Publish new Migration to Old 'Employees' DB
7. Change Connection String to use 'Employees_Production' and run database update
   ~~~
   dotnet ef database update
   ~~~
8. Revert migration – should revert schema to what it was before update command
   ~~~
   dotnet ef database update <Previous Migration>
   ~~~ 
9. Remove Title Property from Employee Class - Should Warn about 'loss of data'
   ~~~
   dotnet ef migrations add RemovedEmployeeTitle
   ---------------------------------------------
   An operation was scaffolded that may result in the loss of data. Please review the migration for accuracy.
   ~~~

## EF Core Findings
* Can set Default Values for Foreign Keys using .HasDefaultValue(-1) function e.g.
    ~~~
    // Default Value for Office
    modelBuilder.Entity<Department>()
        .Property(b => b.OfficeId)
        .HasDefaultValue(-1);
    ~~~
* Can run raw SQL statments during Migrations using migrationBuilder.Sql in the generated Migration File e.g.
    ~~~
    migrationBuilder.Sql("UPDATE Departments SET OfficeId = -2 WHERE Title = 'Finance'");
    ~~~
* If adding a Unique Key with existing fields that are not Unique they will need to be changed manually for the migration to work.
* If any migration could delete existing data it will provide a warning and suggest a review of the migration for accuracy.

## Migrations in Production
https://www.thereformedprogrammer.net/handling-entity-framework-core-database-migrations-in-production-part-1/ 

## Concurrency
https://docs.microsoft.com/en-us/ef/core/saving/concurrency
https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/concurrency?view=aspnetcore-2.2#detecting-concurrency-conflicts 
Implemented in this project using the Row Version.

## Visualization Tools
https://docs.microsoft.com/en-us/ef/core/extensions/

## SQL Server Dynamic Data Masking
https://hryniewski.net/2017/03/28/dynamic-data-masking-and-entity-framework/ - Not easy to acheive

## Scaffold Pages
https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-2.2&tabs=visual-studio-code 

aspnet-codegenerator example command.
~~~
dotnet aspnet-codegenerator razorpage -m Employee -dc EFCore.Playground.DataAccess.EmployeeContext  udl -outDir Pages/Employees --referenceScriptLibraries
~~~