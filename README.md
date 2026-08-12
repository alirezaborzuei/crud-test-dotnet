# CRUD Test — .NET Architecture & Testing Sample

A backend-focused .NET sample demonstrating structured application design, domain-oriented thinking, testing practices, and maintainable CRUD workflows.

## 🎯 Purpose

This repository is a technical portfolio sample rather than a production system. It demonstrates how a typical business CRUD requirement can be implemented with attention to architecture, separation of concerns, and automated testing.

## 🧩 Engineering Focus

- Clean Architecture principles
- Domain-Driven Design concepts
- CQRS-oriented application structure
- SOLID principles
- Test-Driven Development practices
- Acceptance / integration testing concepts
- Separation of domain, application, infrastructure, and API concerns
- Maintainable business logic instead of controller-heavy implementation

## 🏗️ Architecture

```text
                ┌────────────────────┐
                │      API / UI      │
                └─────────┬──────────┘
                          │
                          ▼
                ┌────────────────────┐
                │    Application     │
                │ Commands / Queries │
                └─────────┬──────────┘
                          │
                          ▼
                ┌────────────────────┐
                │       Domain       │
                │ Entities / Rules   │
                └─────────┬──────────┘
                          │
                          ▼
                ┌────────────────────┐
                │  Infrastructure    │
                │ Persistence / I/O  │
                └────────────────────┘
```

The goal is to keep business rules independent from infrastructure and delivery mechanisms so the core application remains easier to test and evolve.

## 🧪 Testing

Testing is treated as part of the design rather than an afterthought. The project demonstrates a layered approach in which business behavior can be verified independently from external infrastructure, with higher-level tests used to validate application workflows.

## 🧰 Technology

- C#
- .NET
- REST API concepts
- Clean Architecture
- DDD
- CQRS
- TDD
- Automated testing

## 🚀 Why This Repository Matters

Simple CRUD applications are easy to build. The interesting engineering problem is keeping a growing business application understandable, testable, and changeable.

This project is included in my portfolio to demonstrate that distinction.

## 📌 Portfolio Note

This is a personal technical sample. It contains no company credentials, production secrets, or confidential business data.

## 👨‍💻 Author

**Alireza Borzouei**

- GitHub: https://github.com/alirezaborzuei
