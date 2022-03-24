import React, {useEffect} from 'react';
import TabAdminUserList from "../Components/TabAdminUserList";
import { useNavigate } from "react-router-dom";
import './AdminUserList.css';

const AdminUserList = () => {
    const navigate = useNavigate();
    useEffect(()=>{
        const token = localStorage.getItem("jwt");
        if(!token)
        {
            navigate("/");
        }
    })
    return (
        <div className='main-a'>
            <TabAdminUserList/>
        </div>
    );
};

export default AdminUserList;