import React, {useEffect} from 'react';
import FormLogin from '../components/Forms/FormLogin/FormLogin';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const navigate = useNavigate();
    useEffect(()=>{
        const token = localStorage.getItem("jwt")
        if(token)
        {
            navigate("/admin")
        }
    })
    return (
        <div>
            <h1>Connexion</h1>
            <FormLogin/>
        </div>
    );
};

export default Login;