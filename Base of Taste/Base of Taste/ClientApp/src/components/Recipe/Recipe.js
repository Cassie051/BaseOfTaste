import React, {Component} from 'react';
import './Recepie.css';
import omlet from '../../assets/img/omlet.jpg'


class Recepie extends Component {
    render() {
        return(
        <div className = "Recepie">
            <h3>
                {this.props.nazwa}
            </h3>
            <img className="img" src = {omlet} alt = "aj" align = "top"/>
            <p className="text">
            {this.props.opis}
            </p>

        </div>
        );
    }
}

export default Recepie;