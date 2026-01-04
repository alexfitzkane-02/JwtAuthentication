# JWT Authentication Project

A simple and secure authentication system built using **JSON Web Tokens (JWT)**.  
This project demonstrates how to implement user authentication, authorization, and protected routes using JWTs.

---

## 🚀 Features

- User registration (sign up)
- User login (sign in)
- Password hashing
- JWT generation and verification
- Token-based authorization

---

## 🛠️ Tech Stack

- **C#**
- **Authentication:** JSON Web Tokens (JWT)  
- **Database:** SQL 
- **Environment Management:** dotenv  

---

## ⚙️ Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/alexfitzkane-02/JwtAuthentication.git
2. Navigate into the project folder:
   ````bash
   cd JwtAuthentication
3. Install dependencies:
   ````bash
   npm install

## 🔐 appsettings.json
  
- DefaultConnection= your_database_connection_string
- Key= your_jwt_key
- Issuer= your_issuer_portnumber
- Listener= your listener_portnumber


## 🔒 How JWT Authentication Works

1. User logs in with valid credentials

2. Server creates a JWT

3. Token is sent to the client

4. Client sends token in request headers

5. Middleware verifies token before allowing access

## 🔗 Example API Endpoints

### Authentication Routes

#### Register User
- **Method:** `POST`
- **Endpoint:** `/api/Auth/register`
- **Description:** Creates a new user account.

**Request Body:**
```json
{
  "email": "johndoe@example.com",
  "password": "password123"
}
```

#### Login User
- **Method:** `POST`
- **Endpoint:** `/api/Auth/login`
- **Description:** Authenticates the user and returns a JWT.

**Request Body:**
```json
{
  "email": "johndoe@example.com",
  "password": "password123"
}
```

#### Learning Outcomes
- Understanding JWT-based authentication
- Securing APIs
- Middleware-based route protection
- Backend authentication best practices

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.








