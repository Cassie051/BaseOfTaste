import React from 'react';
import {Col, Row, Container, ModalBody} from 'react-bootstrap';
import ModalHeader from 'react-bootstrap/ModalHeader';
import cake from '../../../assets/img/pud.png'


const RecipeCard = (props) => {
    const style = {
        width: "100%",
        height: "auto",
        float: "right",
        display: "block",
        margin: "10px",
        clear: "right"
    };

    let listD = null;
    listD = (
        props.przepis.skladniki.map((rec, id) => {
            return(
            <li>
                {rec}
            </li>
            );
        }));
    return(
    <div className = "RecipeCard">
        <ModalHeader closeButton>
            <Container fluid style={{ paddingLeft: "0", paddingRight: "0" }}>
            <Row>
            <Col style={{ maxWidth: "50%"}}>
            <h2>
                {props.przepis.nazwa}
            </h2>
            </Col>
            <Col style={{ maxWidth: "50%" , paddingRight: "4%", paddingTop: "3px", textAlign: "right"}}>
                <b>trudność:</b> {props.przepis.trudnosc}
            </Col>
            </Row>
            <Row >
                <Col >
                    <p><i>
                    {props.przepis.opis}
                    </i></p>
                </Col>
            </Row>
            </Container>
        </ModalHeader>
        <ModalBody>
            <Container>
                <Row>
                    <Col>
                    <Row>
                        <h5> Składniki</h5>
                        <ul>
                            {listD}
                        </ul>
                    </Row>
                    <Row>
                    <h5> Wykonanie </h5>
                    <p> {props.przepis.przygotowanie} </p>
                    </Row>
                    </Col>
                    <Col>
                    <img className="img" src = { cake } alt = "aj" align = "top" style={style}/>
                    </Col>
                </Row>
            </Container>
        </ModalBody>

    </div>
    );
}

export default RecipeCard;