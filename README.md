# ContactCatalogue

A console-based contact management application built with **C\#** and **.NET 8**. This project demonstrates the use of structural design patterns, LINQ queries, custom error handling, and unit testing with Moq.

## Features

  * **Manage Contacts:** Add new contacts with Name, Email, and Tags.
  * **Validation:** Ensures email addresses are valid and prevents duplicate emails.
  * **Search & Filter:**
      * Search contacts by Name.
      * Filter contacts by Tags (e.g., "friend", "work").
  * **Listing:** View all contacts sorted alphabetically.
  * **Logging:** Integrated `Microsoft.Extensions.Logging` to log key events to the console.
  * **Architecture:** clear separation of concerns using the **Repository Pattern** and **Dependency Injection**.

## Technologies Used

  * **.NET 8** (C\# 12)
  * **xUnit** (Unit Testing)
  * **Moq** (Mocking dependencies)
  * **Microsoft.Extensions.Logging**

-----

## Project Structure

The solution is divided into logical components to ensure maintainability and testability:

```text
ContactCatalogue/
├── ConsoleUI/
│   ├── ContactAdder.cs     # UI logic for adding contacts
│   └── Program.cs          # Entry point, DI setup, Main Menu
├── Exceptions/
│   ├── DuplicateEmailException.cs
│   └── InvalidEmailException.cs
├── Models/
│   └── Contact.cs          # Data model
├── Services/
│   ├── ContactService.cs   # Business logic
│   └── IContactRepository.cs # Data access interface
└── ContactCatalogue.Tests/
    └── FilterTests.cs      # Unit tests for filtering logic
```

-----

## Reflection & Design Choices

*This section addresses the assignment requirement to reflect on data structures and LINQ.*

### Data Structures

  * **Dictionary\<int, Contact\>:** Used in the repository layer to store contacts.
      * *Why?* It provides **O(1)** time complexity for lookups when retrieving a contact by its unique ID.
  * **HashSet\<string\>:** Used to track registered emails.
      * *Why?* Checking if an email already exists is an **O(1)** operation, making validation significantly faster than iterating through a List (O(n)) every time a user adds a contact.

### LINQ Usage

  * **`Where`:** Used in `SearchByName` and `SearchByTag` to filter the collection based on string matching.
  * **`OrderBy`:** Used to ensure that lists returned to the user are always sorted alphabetically by Name, improving readability.

### Architecture

  * **Repository Pattern:** The `ContactService` does not own the data list directly; it relies on `IContactRepository`. This allows us to easily swap the storage mechanism (e.g., from Memory to Database) later without changing the business logic.
  * **Dependency Injection:** Dependencies (Logger, Repository) are injected via the constructor. This makes the code loosely coupled and allows for easy Unit Testing using **Moq**.

-----

## How to Run

1.  **Clone or Open** the project in Visual Studio.
2.  **Build** the solution (`Ctrl + Shift + B`).
3.  **Run** the application:
      * Navigate to the `ContactCatalogue` project.
      * Run `dotnet run`.

## Running Tests

To verify the filtering logic and mock interactions:

1.  Open the **Test Explorer** in Visual Studio.
2.  Run all tests (specifically `FilterTests.cs`).
3.  The tests use `Moq` to simulate the Repository, proving that `ContactService` correctly filters data without needing the actual application to run.

-----

## Example Usage

```text
=== Contact Catalogue ===
1) Add
2) List
3) Search (Name contains)
4) Filter
5) Export to CSV file
0) Exit

>> 1
=== Contact Adder ===

Name: bunlevain

Email: bun@gmail.com

Tags (ex: tag1, tag2...):
[Added 1 contact in your catalogue.]
info: ContactCatalogue.Services.ContactService[0]

Contact added: bun@gmail.com
```
