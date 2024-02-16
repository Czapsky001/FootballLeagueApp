// App.js

import React from 'react';
import './App.css';
import MainPage from './Components/MainPage';
import RegisterForm from './Components/RegisterForm';
import LoginForm from './Components/LoginForm';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import { AuthProvider } from './AuthContext/AuthContext'; // Importuj AuthProvider

function App() {
  return (
    <Router>
      <AuthProvider>
        <div className="App">
          <header>
            <Link to="/" className="title">
              Football League
            </Link>
          </header>

          <Routes>
            <Route path="/" element={<MainPage />} />
            <Route path="/register" element={<RegisterForm />} />
            <Route path="/login" element={<LoginForm />} />
          </Routes>
        </div>
      </AuthProvider>
    </Router>
  );
}

export default App;
