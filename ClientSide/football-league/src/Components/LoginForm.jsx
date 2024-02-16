import React, { useState } from 'react';
import axios from 'axios';
import { useAuth } from '../AuthContext/AuthContext';
import { useNavigate } from 'react-router-dom'; // Zmieniono import na useNavigate

const LoginForm = () => {
  const { login } = useAuth();
  const navigate = useNavigate(); // Zmieniono useHistory na useNavigate
  const [formData, setFormData] = useState({
    email: '',
    password: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('https://localhost:7233/Auth/Login', formData);
      login(response.data);
      if(response.data.token != null){
        navigate("/")
      }
    } catch (error) {
      console.error('Error during login:', error);
    }
  };

  return (
    <form className="login-form" onSubmit={handleSubmit}>
      <label>
        Email:
        <input type="email" name="email" value={formData.email} onChange={handleChange} />
      </label>

      <label>
        Password:
        <input type="password" name="password" value={formData.password} onChange={handleChange} />
      </label>

      <button type="submit">Login</button>
    </form>
  );
};

export default LoginForm;
