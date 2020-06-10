import React from 'react';
import {Row, Container, ModalBody, InputGroup, Button, FormControl} from 'react-bootstrap';
import ModalHeader from 'react-bootstrap/ModalHeader';


const MealType = (props) => {
    const style = {
        height: "auto",
        float: "right",
        display: "block",
        margin: "10px",
        clear: "right"
    };

    let formrow = null;

    if((props.funkcja === 'Dodaj Wartość odżywczą') || (props.funkcja  === 'Dodaj Składnik')){
        formrow = (
            <InputGroup>
                <InputGroup.Prepend>
                    <Button className = "Invert" variant="outline-secondary">Dodaj</Button>
                </InputGroup.Prepend>
                <FormControl placeholder = "Podaj Składnik" aria-describedby="basic-addon1" />
                <FormControl placeholder = "Podaj Ilość" aria-describedby="basic-addon1" />
                <FormControl placeholder = "Podaj Jednostkę" aria-describedby="basic-addon1" />
            </InputGroup>
        );
    }
    else {
        formrow = (
            <InputGroup>
                <InputGroup.Prepend>
                    <Button className = "Invert" variant="outline-secondary">Dodaj</Button>
                </InputGroup.Prepend>
                <FormControl placeholder = "Wpisz wartość" aria-describedby="basic-addon1" />
            </InputGroup>
        );
    }

    return(
    <div className = "MealType" style = {style}>
        <ModalHeader closeButton>
            <Container fluid style={{ paddingLeft: "0", paddingRight: "0" }}>
            <Row>
            <h2>
                {props.funkcja}
            </h2>
            </Row>
            </Container>
        </ModalHeader>
        <ModalBody>
            <Container>
                <Row>
                { formrow }
                </Row>
            </Container>
        </ModalBody>

    </div>
    );
}

export default MealType;