import React from 'react';
import {Row, Container} from 'react-bootstrap';
import './Recipe.css';
import omlet from '../../../assets/img/omlet.jpg'


const Recipe = (props) => {
        return(
        <div className = "Recipe" onClick={props.click}>
            <Container>
                <Row> <h3> {props.nazwa} </h3> </Row>
                <Row style={{height: "60px"}}>
                    <p className="text"> {props.opis} </p>
                </Row>
                <Row>
                    <img className="img" src = {omlet} alt = "aj" align = "top"/>
                </Row>
            </Container>
        </div>
        );
}

export default Recipe;