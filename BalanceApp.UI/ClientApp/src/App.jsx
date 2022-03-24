import React from "react";
import { BrowserRouter as Router,Routes,Route, } from "react-router-dom"; 
import Login from "./Pages/Login.js";
import Register from "./Pages/Register.js";
import AdminUserList from "./Pages/AdminUserList.js";
import "./App.css"

export default function App() 
{
  
  return(

      <Routes>
        <Route path="/" element={<Login />}/>
        <Route path="register" element={<Register />}/>
        <Route path="admin" element={<AdminUserList/>}/>
      </Routes>
     
  ); 
}


