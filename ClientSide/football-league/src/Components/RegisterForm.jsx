import React, { useState } from 'react';
import axios from 'axios'; // Importuj bibliotekę Axios

const RegisterForm = () => {
  const [formData, setFormData] = useState({
    username: '',
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

      const response = await axios.post('https://localhost:7233/Auth/Register', formData);
      console.log('Response:', response.data);


      setFormData({
        username: '',
        email: '',
        password: '',
      });
    } catch (error) {
      console.error('Error:', error.response.data);
    }
  };

  return (
    <form className="register-form" onSubmit={handleSubmit}>
      <label>
        Username:
        <input type="text" name="username" value={formData.username} onChange={handleChange} />
      </label>

      <label>
        Email:
        <input type="email" name="email" value={formData.email} onChange={handleChange} />
      </label>

      <label>
        Password:
        <input type="password" name="password" value={formData.password} onChange={handleChange} />
      </label>

      <button type="submit">Register</button>
    </form>
  );
};

export default RegisterForm;
