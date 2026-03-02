# Time

This repository contains a C# project demonstrating Object-Oriented Programming (OOP) concepts, featuring a custom `Time` class with robust validation, time calculations, and formatting logic.

## 🚀 Features

- **Encapsulation**: Private fields with public properties using expression-bodied members.
- **Validation**: Custom logic to ensure valid hours, minutes, seconds, and milliseconds.
- **Constructors**: Multiple constructor overloads, including default, hour-only, hour+minute, hour+minute+second, and full hour+minute+second+millisecond.
- **Time Calculations**: Methods to add time, check if it passes to the next day, and convert to total milliseconds, seconds, or minutes.
- **Formatting**: Custom `ToString` override for standardized 12-hour format with AM/PM.

## 🛠 Prerequisites

Before running this project, ensure you have the following installed:
- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or higher recommended)
- [Visual Studio Code](https://code.visualstudio.com/)
- [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) for VS Code


## 🏃 How to Run

Follow these steps to get the project running locally:

1. **Clone the repository:**
   ```bash
    git clone https://github.com/dcanosu/Time.git
    cd Time/Time

2. **Restore dependencies:**
    ```bash
    dotnet restore

3. **Build the project:**
    ```bash
    dotnet build

3. **Run the application:**
    ```bash
    dotnet run --project Frontend