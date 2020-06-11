import React, { Component } from 'react';
import { Container, Col, Row, Form, Button } from 'reactstrap';
import './Menu.css';

export class Menu extends Component {
  static displayName = Menu.name;

  render () {
    return (
      <div className = "Menu">
        <Container>
            <Row>
            	<Col> <h1> Wygeneruj jadłospis </h1> </Col>
            	<Col md="auto" style={{paddingTop: "1%"}}>
					<Button > Generuj </Button>
				  </Col>
            </Row>
			    <p> <b> Zatwierdź wybór, żeby wyświetlić dobrany zestaw.</b></p>
          </Container>
    </div>
    );
  }
}
