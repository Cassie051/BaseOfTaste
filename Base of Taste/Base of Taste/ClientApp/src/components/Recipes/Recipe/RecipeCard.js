import React from 'react';
import ModalHeader from 'react-bootstrap/ModalHeader';
import ModalBody from 'react-bootstrap/ModalBody';
import ModalTitle from 'react-bootstrap/ModalTitle';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Container from 'react-bootstrap/Container'


const RecipeCard = (props) => {
    return(
    <div className = "RecipeCard">
        <ModalHeader closeButton>
            <Container fluid style={{ paddingLeft: "0", paddingRight: "0" }}>
            <Row>
            <Col style={{ maxWidth: "50%" }}>
            <ModalTitle>
                {props.przepis.nazwa}
            </ModalTitle>
            </Col>
            <Col style={{ maxWidth: "20%" , paddingRight: "2%"}}>
                trudność: {props.przepis.trudnosc}
            </Col>
            </Row>
            <Row>
            <p><i>
            {props.przepis.opis}
            </i></p>
            </Row>
            </Container>
        </ModalHeader>
        <ModalBody>
        </ModalBody>

    </div>
    );
}

export default RecipeCard;