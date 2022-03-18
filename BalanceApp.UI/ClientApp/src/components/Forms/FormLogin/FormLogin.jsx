import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import "./FormLogin.css"

const FormLogin = () => {
    const [email,setEmail] = useState("");
    const [password,setPassword] = useState("");
    const [errorMessage, setErrorMessage] = useState("");
    const navigate = useNavigate();

    const handleChange = (event)=>
    {
        switch(event.target.name)
        {
            case "email":
                setEmail(event.target.value);
                break;
            case "password":
                setPassword(event.target.value);
                break;
            default:
        }
    }

    const handleSubmit = async (event)=>
    {
        event.preventDefault();
        try{
           const token = await axios.post("https://localhost:7298/api/auth/login",{
                email : email,
                password : password
            })

            localStorage.setItem("jwt",token.data.tokenJwt);
            
            setErrorMessage("");
            setEmail("");
            setPassword("");
            navigate("/admin")
        }
        catch(error)
        {
            setErrorMessage("Email ou mot de passe invalide !");
        }
        
    }

    return (
        <form className='form-login' onSubmit={handleSubmit} >
            <p className='login-error'>{errorMessage}</p>
            <input type="email" placeholder='Email' name='email' value={email} onChange={handleChange} />
            <input type="password" placeholder='Password' name='password' value={password} onChange={handleChange}/>
            <button type="submit">Se connecter</button>
        </form>
    );
};
export default FormLogin;