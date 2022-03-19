import React from "react";
import './TabAdminUserList.css';
import { useNavigate } from "react-router-dom";

const TabAdminUserList = () => {
  const navigate = useNavigate();
  const users = [{
    firstname: "toto",
    lastname : "tutu",
    role: "Admin",
    CreatedAt: "10/05/2000"
  },{
    firstname: "too",
    lastname : "tutu",
    role: "Doctor",
    CreatedAt: "10/05/2000"
  },{
    firstname: "tto",
    lastname : "tutu",
    role: "Admin",
    CreatedAt: "10/05/2000"
  },{
    firstname: "totu",
    lastname : "tuu",
    role: "Doctor",
    CreatedAt: "10/05/2000"
  }]

  const getUserList = ()=>{
   return users.map(user => {
       return( <tr>
          <td> {user.firstname} </td>
          <td>{user.lastname}</td>
          <td>{user.role}</td>
          <td>{user.CreatedAt}</td>
          <td className="btn-block"><button className="edit-button-t">Modifier</button>
          <button className="suppr-button-t">Supprimer</button></td> 
      </tr>)
    })
  }
const handleClick =()=> {
  localStorage.removeItem("jwt");
  navigate("/");
}
  return (
    <div>
    <button onClick={handleClick}>Déconnexion</button>
    <table>

      <caption>Bienvenue dans l'espace administrateur</caption>
      <thead>
        <tr>
          <th>Nom</th>
          <th>Prénom</th>
          <th>Rôle</th>
          <th>Date de création</th>
          <th> - </th>
        </tr>
      </thead>
      {getUserList()}
    </table> 
    </div>
  );
};

export default TabAdminUserList;


