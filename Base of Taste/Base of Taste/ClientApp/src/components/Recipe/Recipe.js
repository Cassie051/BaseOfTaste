import React, {Component} from 'react';
import './Recepie.css';
import omlet from '../../assets/img/omlet.jpg'


const Recepie = (props) => {
        return(
        <div className = "Recepie" onClick={props.click}>
            <h3>
                {props.nazwa}
            </h3>
            <img className="img" src = {omlet} alt = "aj" align = "top"/>
            <p className="text">
            {props.opis}
            </p>

        </div>
        );
}

export default Recepie;