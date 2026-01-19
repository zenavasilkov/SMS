# Student Management System (SMS)

C#/.NET Student Management System for managing students, groups, subjects and academic records (marks). The repository contains a domain model, an EF Core DbContext (SQLite), and a WPF UI to browse and manage data.

This README describes the project structure, how to build and run the application, and pointers for contributors.

---

## Table of contents

- [Overview](#overview)
- [Features](#features)
- [Requirements](#requirements)
- [Database](#database)
- [Project notes & design decisions](#project-notes--design-decisions)
- [Contact](#contact)

---

## Overview

This project implements a Student Management System (SMS) that models:

- Students (record book number, name, group membership)
- Groups (specialty, abbreviation, faculty, year of admission)
- Subjects (designation)
- Records (grades/marks, semester, whether a course project)

<img width="43" height="33" alt="image" src="https://github.com/user-attachments/assets/3abee9ee-7799-4f0c-b66c-79f3263b50e1" />A lightweight WPF application is included to view and interact with the data.


---

## Features

- Domain entities for Student, Group, Subject and Record
- EF Core DbContext configured to use SQLite
- Basic relationships and cascade delete behavior
- WPF UI with views and viewmodels for Students, Groups, Subjects and Records
- Example ViewModels that load data from the database

---

## Requirements

- .NET SDK 6.0 or later (the project uses C# modern features — adjust if necessary)
- Visual Studio (recommended for WPF) or another IDE supporting WPF and .NET
- No external database required; the app uses SQLite by default

Check your SDK:

```bash
dotnet --version
```

---

## Getting started (build & run)

1. Clone the repository:

```bash
git clone https://github.com/zenavasilkov/SMS.git
cd SMS
```

2. Restore and build:

```bash
dotnet restore
dotnet build
```

3. Run the WPF application (from the Univesity1 project folder):

```bash
cd Univesity1
dotnet run
```

Note: Running the WPF app via `dotnet run` works on Windows. For Visual Studio, open the solution and run the Univesity1 project.

---

## Database

- The project is configured to use SQLite: `Data Source=University.db`.
- On first run the DB file (`University.db`) will be created in the working directory.
- Model relationships (defined in `OnModelCreating`) include:
  - Student has key `RecordBookNumber`
  - Student → Group (many-to-one)
  - Record → Student and Record → Subject (many-to-one)
  - Cascade delete configured for foreign-key relationships

If you want to manage migrations manually, add EF Core tools and create migrations:

```bash
dotnet tool install --global dotnet-ef
cd UniversityApp.Data   # or solution root if projects are referenced
dotnet ef migrations add InitialCreate -p UniversityApp.Data -s Univesity1
dotnet ef database update -p UniversityApp.Data -s Univesity1
```

(Adjust project and startup project names as needed.)

---

## Running the WPF UI & Using the App

- The MainWindow loads `StudentsView` by default and provides navigation buttons for Groups, Records and Subjects.
- ViewModels load data from `AppDbContext` into `ObservableCollection<T>` for binding.
- Dialog windows provide UI scaffolding for creating and editing entities.
- The UI is an example scaffolding — extend commands, validation and persistence logic in the viewmodels and dialogs.

---

## Project notes & design decisions

- The project follows MVVM pattern for WPF: Views, ViewModels and Models separated.
- Persistence uses EF Core with code-first style and SQLite.
- `RecordBookNumber` is used as the Student primary key and as the foreign key in `Record`.

---

## Contact

Maintainer: zenavasilkov  
Repository: https://github.com/zenavasilkov/SMS

---

