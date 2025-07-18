# 💘 CrushApp – A Modern Blazor Dating App

CrushApp is a fully custom-built dating application using **Blazor Server** for the frontend and **Azure Cosmos DB** for backend data storage. It’s designed for users to register, log in, and prepare for matchmaking functionality.

---

## 🚀 Tech Stack

| Layer        | Technology                      |
|--------------|----------------------------------|
| Frontend     | Blazor Server (.NET 8)           |
| Backend      | Azure Cosmos DB (NoSQL)          |
| Styling      | Bootstrap + Custom CSS           |
| State        | C# service + localStorage (via JS Interop) |
| Hosting      | Azure App Services (planned)     |

---

## ✅ Features Implemented

- 🔐 **User Registration** (username, email, password)
- 🔐 **User Login** with session persistence
- 🔐 **Secure Password Hashing** using `BCrypt.Net`
- 🧠 **Session Management** using `UserSessionService`
- 🌐 **Session persists on reload** via `localStorage` and `IJSRuntime`
- 📦 **Data Storage in Cosmos DB**
- 🧭 Clean navigation and layout (NavMenu + Footer)
- ⚡ **Hot reload** enabled for rapid iteration

---

## 📁 Folder Structure Overview


CrushApp/
│
├── Data/
│ ├── DTOs/ # UserCreateDto, UserReadDto, LoginDto, etc.
│ ├── Models/ # User.cs
│ ├── Services/ # CosmosUserService.cs, UserSessionService.cs
│ └── Mapping/ # AutoMapper UserProfile
│
├── Pages/
│ ├── Login.razor
│ ├── Register.razor
│ ├── Index.razor
│
├── Shared/
│ ├── NavMenu.razor
│ ├── FooterBar.razor
│
├── wwwroot/
│ └── css/ # Optional styling
│
├── App.razor # Main app router
├── Program.cs # App configuration & DI
├── _Host.cshtml # Entry point
└── appsettings.json # CosmosDB connection


## ⚙️ How to Run Locally

1. **Clone the Repo**
   ```bash
   git clone https://github.com/your-username/crushapp.git
   cd crushapp


   
##Configure Cosmos DB

### Update your appsettings.json:

"CosmosDb": {
  "Endpoint": "https://<your-account>.documents.azure.com:443/",
  "Key": "<your-primary-key>",
  "DatabaseName": "CrushAppDb"
}



## Run the App

dotnet clean
dotnet build
dotnet watch run
