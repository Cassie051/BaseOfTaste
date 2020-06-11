import React, { Component } from 'react';
import { Container, Col, Row, Button, Form } from 'reactstrap';
import './Filtr.css'

export class Filtr extends Component {
  static displayName = Filtr.name;
  render () {
    return (
      <div className = "Filtr">
        <Container>
            <Row>
            	<Col> <h1> Filtruj przepisy </h1> </Col>
            	<Col md="auto" style={{paddingTop: "1%"}}>
					<Button > Filtruj </Button>
				</Col>
            </Row>
			<p> <b> Zatwierdź filtr, zeby wyświetlić wybrane przepisy.</b></p>
        </Container>
      </div>
    );
  }
}
