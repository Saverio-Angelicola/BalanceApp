import React from 'react';
import './Register.css';
import FormRegister from "../Components/FormRegister";

const Register = () => {
    return (
        <div className= "main-r">
            <div className="box-r">
                <div className="title-r">
                </div>
                <div>
                    <FormRegister/>
                </div>
            </div>
        </div>
    );
};

export default Register;