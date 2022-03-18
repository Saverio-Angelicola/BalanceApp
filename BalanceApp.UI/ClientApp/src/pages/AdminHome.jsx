import React, {useEffect} from 'react';
import { useNavigate } from 'react-router-dom';

const AdminHome = () => {
    const navigate = useNavigate();
    useEffect(()=>{
        const token = localStorage.getItem("jwt")
        if(!token)
        {
            navigate("/")
        }
    })
    return (
        <div>
            Admin
        </div>
    );
};

export default AdminHome;