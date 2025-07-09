# 🎬 MovieTheaterBooker

**MovieTheaterBooker** is an ASP.NET Core MVC web application that allows you to manage a movie theater, including movie screenings, theaters, seats, and reservations.

## 🚀 Main Features
- Seat reservation for a selected screening
- Web interface using MVC pattern

## 🚀 Future Features 
- Identity management (admin, user)
- Movie management (add, edit, delete) as admin
- Theater/screen management as admin
- Creation of movie screenings (movie in a specific theater at a specific time) as admin


## 🧱 Project Architecture

- **ASP.NET Core MVC**
- **Entity Framework Core** for database access
- **Razor Views** for server-side rendering

### 📁 Folder Structure

```
MovieTheaterBooker/
│
├── Controllers/           # MVC controllers (Home, Movies, Screens, etc.)
├── Data/                  # Models and DbContext (Movie, Screen, Seat, etc.)
├── Views/                 # Razor views (not shown here but part of ASP.NET)
├── wwwroot/               # Static content (JS, CSS, images)
├── Program.cs             # App entry point
├── appsettings.json       # Configuration (e.g., DB connection)
└── MovieTheaterBooker.csproj
```

## ⚙️ Requirements

- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or higher
- Visual Studio 2022 (or any compatible IDE)
- SQL Server (or any EF Core-compatible provider)

## ▶️ Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/ngiani/MovieTheaterBooker.git
   cd MovieTheaterBooker/MovieTheaterBooker
   ```

2. **Restore packages**:
   ```bash
   dotnet restore
   ```

3. **Apply migrations (if applicable)**:
   ```bash
   dotnet ef database update
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

5. Open your browser and go to localhost.

## 🧪 Running Tests

If test projects are included (not present in this version), you can run them with:

```bash
dotnet test
```

## 📌 Notes

- The project uses Entity Framework with an `ApplicationDbContext`.
- Authentication is not included but can be easily added using ASP.NET Identity.
- This is a solid starting point for a cinema or event booking web application.

## 📄 License

This project is licensed under the MIT License. Feel free to use and adapt it.

---

Built with ❤️ using ASP.NET Core.
