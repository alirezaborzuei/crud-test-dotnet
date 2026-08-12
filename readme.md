# CRUD Test — .NET Sample Application

A practical **.NET CRUD sample** demonstrating backend engineering practices, layered architecture, validation, automated testing, and maintainable application structure.

This repository is kept public as a **personal portfolio / technical sample**.

## What it demonstrates

- CRUD operations
- Clean architecture principles
- Domain-driven design concepts
- CQRS-oriented application structure
- TDD / BDD testing practices
- Acceptance tests
- Backend validation
- Database constraints and uniqueness rules
- Separation of presentation and application concerns

## Project Structure

- `Mc2.CrudTest.Presentation` — presentation/API layer
- `Mc2.CrudTest.AcceptanceTests` — acceptance-level tests
- `Mc2.CrudTest.sln` — Visual Studio solution

## Domain

The sample uses a `Customer` domain containing fields such as:

- First name / Last name
- Date of birth
- Phone number
- Email
- Bank account number

The project focuses on **engineering practices and system design**, not on real customer information. No production customer data is intended to be stored in this repository.

## Testing

The solution includes automated test coverage and an acceptance-test project to demonstrate testing at different levels.

## Getting Started

Open `Mc2.CrudTest.sln` in Visual Studio and restore/build the solution. Run the available test projects through the Visual Studio Test Explorer or your preferred .NET test runner.

## Portfolio Note

This is a personal technical sample demonstrating how I approach a small business application from domain modeling through presentation and testing.

## Author

Alireza Borzouei
