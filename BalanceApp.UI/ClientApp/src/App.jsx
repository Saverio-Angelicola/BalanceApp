import React from 'react';
import { Route, Routes } from 'react-router-dom';
import AdminHome from './pages/AdminHome';
import Login from './pages/Login';

const App = ()=>  {
    return (
     <Routes>
         <Route index path='/' element={<Login/>} />
         <Route path='/admin' element={<AdminHome/>} />
     </Routes>
    );
}

export default App;
