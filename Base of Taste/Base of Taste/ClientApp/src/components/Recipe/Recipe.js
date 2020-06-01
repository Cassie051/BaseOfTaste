import React, {Component} from 'react';
import './Recepie.css';
import FigureCaption from 'react-bootstrap/FigureCaption'
import omlet from '../../assets/img/omlet.jpg'


class Recepie extends Component {
    render() {
        return(
        <div className = "Recepie">
            <h3>
                {this.props.nazwa}
            </h3>
            <img className="img" src = {omlet}/>
            <FigureCaption>
                {this.props.opis}
            </FigureCaption>
        </div>
        );
    }
}

export default Recepie;