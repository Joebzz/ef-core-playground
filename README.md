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
