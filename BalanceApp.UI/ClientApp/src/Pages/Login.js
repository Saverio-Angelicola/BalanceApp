import React from "react";
//import Login from "../Components/Login";
import FormLogin from "../Components/FormLogin";
import './Login.css';
import profile from '../assets/img/images.png';

const Login = () => {
  return (
    <div className="main-l">
      <div className="box-l">
        <div>
          <div className="imgs-l">
            <div className="container-image-l">
              <img src={profile} alt="profile" className="profile-l" />
            </div>
          </div>
          <div>
          <div className="title-l">
            <h1>Connexion</h1>
          </div>
            <FormLogin/>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
