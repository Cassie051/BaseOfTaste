import React from 'react';
import './Recipe.css';
import omlet from '../../../assets/img/omlet.jpg'


const Recipe = (props) => {
        return(
        <div className = "Recipe" onClick={props.click}>
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

export default Recipe;