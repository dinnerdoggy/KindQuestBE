KindQuest Backend
KindQuest is a volunteer-based task management platform that connects individuals who need help with community members willing to lend a hand. This repository contains the backend API built with .NET 8, EF Core, and PostgreSQL.

📦 Tech Stack
C# / .NET 8

Entity Framework Core

PostgreSQL

Minimal APIs

Repository Pattern

Firebase Authentication (UID-based user matching)

📁 Project Structure
pgsql
Copy
Edit
KindQuestBE/
├── Controllers/
├── Data/
│   └── KindQuestDbContext.cs
├── Endpoints/
├── Interfaces/
├── Migrations/
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json
🧠 ERD Overview
The database includes the following entities:

User – Application users (volunteers and posters)

Project – A collection of volunteer jobs grouped under a cause

Job – Tasks needing volunteer help

Volunteer – Join table representing users volunteering for jobs

🔄 Many-to-many relationships are modeled via the Volunteers table
🔑 Firebase Uid is used to link frontend-authenticated users to backend users

🚀 Getting Started
1. Clone the Repository
bash
Copy
Edit
git clone https://github.com/your-org/KindQuestBE.git
cd KindQuestBE
2. Set Up Environment Variables
Create a secrets.json or use the dotnet user-secrets CLI to store your PostgreSQL connection string:

bash
Copy
Edit
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=KindQuest;Username=postgres;Password=yourpassword"
3. Run Database Migrations
bash
Copy
Edit
dotnet ef database update
4. Run the Application
bash
Copy
Edit
dotnet run
Visit the Swagger UI at:
📄 https://localhost:PORT/swagger

📬 API Endpoints
For full API docs, run the app and visit Swagger UI.

Sample routes:

GET /users

POST /projects

GET /jobs/{id}

PUT /users/{id}

POST /jobs/volunteer → Assign a user to a job

GET /users/{uid} → Get user by Firebase UID

✅ Unit Testing
Unit tests are written using xUnit and Moq. Run all tests with:

bash
Copy
Edit
dotnet test
🔐 Authentication
KindQuest uses Firebase Authentication on the frontend. When a user logs in, their uid is passed to the backend to identify or create a user account. Ensure UID-based lookup logic is used in checkuser and related endpoints.

🤝 Contributing
Fork the repo

Create a feature branch (git checkout -b feature/YourFeature)

Commit changes (git commit -m 'Add some feature')

Push to the branch (git push origin feature/YourFeature)

Open a Pull Request
