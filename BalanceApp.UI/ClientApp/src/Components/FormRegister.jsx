import React from "react";
import './FormRegister.css';

const FormRegister = () => {
    return (
      <form>
        <h1>Inscription</h1>
        <div>
          <input type="text" placeholder="Nom" className="name-r" />
        </div>
        <div>
          <input type="text" placeholder="Prénom" className="name-r" />
        </div>
        <div className="box-input">
        <p>Rôle :</p>
          <div>
            <input type="radio" id="Administrateur" name="rôle" value="Administrateur" checked/>
            <label for="Administrateur">Administrateur</label>
          </div>

          <div>
            <input type="radio" id="Médecin" name="rôle" value="Médecin" checked/>
            <label for="Médecin">Médecin</label>
          </div>
        </div>
        {/*
        <div>
            <input type="text" placeholder="Rôle" className="name-r" /> 
        </div>
        */}
        <div>
            <input type="text" placeholder="Nom d'utilisateur" className="name-r" />
        </div>
        <div>
            <input type="text" placeholder="Mot de passe" className="name-r" />
        </div>
        <div>
            <input type="text" placeholder="Mot de passe confirmé" className="name-r" />
        </div>
        <div>
          <input className="button-r" type="button" value="Crée compte"/>
        </div>
      </form>
    );
  };
  
  export default FormRegister;