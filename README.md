# Lao Airlines Ticket Selling System

A modern, high-aesthetic web application for selling domestic flight tickets in Laos, built using **F#** and the **Giraffe** web framework.

## 🚀 Project Overview
This project demonstrates a functional programming approach to web development. It features a clean, type-safe architecture designed to show progress from data modeling to user interface and business logic.

## 🛠️ Features
- **Domestic Flight Search**: Search flights from Vientiane (VTE) to Pakse, Xieng Khouang, Luang Prabang, and Xayaboury.
- **Dynamic Pricing**: Realistic domestic pricing with Economy ($100) and Business ($500) classes.
- **Type-Safe HTML**: Built using `Giraffe.ViewEngine`, ensuring the UI logic is consistent with the data models.
- **Premium Aesthetics**: Custom CSS styling with Lao Airlines branding (Blue/Gold theme).

## 📂 Project Structure
To show the logical flow of the application, the code is organized into separate modules:

1. **`Models.fs`**: Defines the central data structures and flight classes.
2. **`Views.fs`**: Contains the visual layout and HTML generation logic.
3. **`Handlers.fs`**: Implements the business logic and request processing.
4. **`Program.fs`**: The application's entry point and server configuration.

## 💻 How to Run
1. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Open your terminal in the project folder.
3. Navigate into the source directory:
   ```bash
   cd LaoAirline
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Open your browser and go to: `http://localhost:5000`
## 🐳 Docker Deployment
You can easily build and run this application using Docker:

```bash
# Build the Docker image
docker build -t laoairline-app .

# Run the container
docker run -d -p 8080:8080 laoairline-app
```
After running the container, open your browser and navigate to `http://localhost:8080`.

## 🎓 Academic Note
This project was built from the ground up to explore F# concepts like **Discriminated Unions**, **Records**, and **Functional Routing**. The commit history reflects the step-by-step development of each component.
