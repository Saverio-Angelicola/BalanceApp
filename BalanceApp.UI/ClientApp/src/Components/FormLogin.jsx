import React, {useState, useEffect} from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import './FormLogin.css';

const FormLogin = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage,setErrorMessage]= useState("");
  const navigate = useNavigate();
  useEffect(()=>{
        const token = localStorage.getItem("jwt");
        if(token)
        {
            navigate("/admin");
        }
    })

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
        break;
    }
  }

  const handleSubmit = async (event)=>{
    event.preventDefault();
    try
    {
      const token = await axios.post("https://localhost:7298/api/auth/login",{
        email: email,
        password: password
      })

      localStorage.setItem("jwt",token);
      setErrorMessage("");
      setEmail("")
      setPassword("")
      navigate("admin");
    }
    catch(err)
    {
      setErrorMessage("Email ou mot de passe invalide!")
      setEmail("")
      setPassword("")
    }
  }

  return (
    <div>
      {errorMessage}
    <form onSubmit={handleSubmit}>
      <div>
        {/* <img src={email} alt="enveloppe" className="email"/>*/}
        <input type="email" placeholder="Email" value={email} onChange={handleChange} name="email" className="name-l" required/>
      </div>
      <div className="second-input-l">
        {/*<img src={pass} alt="cadenas" className="pass"/>*/}
        <input type="password" placeholder="Mot de passe" value={password} onChange={handleChange} name="password" className="name-l" required/>
      </div>
      <div className="login-button-l">
        <button className="button-l" type="submit">Connexion</button>
      </div>
    </form>
    </div>
  );
};

export default FormLogin;

