import React, { Component } from 'react';
import {Col, Row, Container, Button, Form} from 'react-bootstrap';
import './AddRecipe.css';

export class AddRecipe extends Component {
  static displayName = AddRecipe.name;
  state = {
    przepis:[{
        id: 'melsf',
        nazwa: 'Omlet',
        opis: 'Bardzo smaczny jajeczny omlecik',
        trudnosc: 2,
        przygotowanie: 'Rozpuszczam tłuszcz na patelni z nieprzywierającą powierzchnią, wlewam jajka. Po 30 sekundach mieszam szpatułką środek omletu i jeszcze raz rozprowadzam masę. Po 4-5 minutach masa się zetnie, wtedy składam omlet na pół i wykładam na talerz.'
    }]
  }


  render () {
    return (
      <div className = "AddRecipe">
        <Container>
			<Form>
			  <Row>
				  <Col> <h1> Dodaj przepis </h1> </Col>
				  <Col md="auto" style={{paddingTop: "2%", paddingRight: "2%"}}>
					  <Button type="submit"> Zapisz przepis w bazie </Button>
					  </Col>
			  </Row>
            <Form.Row style = {{paddingTop: "5%"}}>
            <Form.Group as={Col} controlId="formGridRName">
                <Form.Label>Nazwa</Form.Label>
                <Form.Control type="przepis.nazwa" placeholder="Wpisz nazwę przepisu" />
            </Form.Group>

            <Form.Group as={Col} controlId="formGridRlvl">
            	<Form.Label>Trudność</Form.Label>
				<Form.Control as="select" defaultValue="Określ trudność wykonania">
                		<option>1</option>
                		<option>2</option>
                	</Form.Control>
            </Form.Group>
            </Form.Row>

            <Form.Group controlId="formGridRDescription">
            	<Form.Label>Opis</Form.Label>
            	<Form.Control placeholder="Wpisz którki opis przepisu" />
            </Form.Group>

            <Form.Row >
            <Form.Group as={Col} controlId="formGridRName">
                <Form.Label>Składniki</Form.Label>
				<Form.Row>
					<Form.Group as={Col}>
                		<Form.Control type="przepis.skladnik" placeholder="Wpisz składnik" />
					</Form.Group>
					<Form.Group as={Col} >
						<Form.Control type="przepis.ilosc" placeholder="Wpisz ilość i jednostkę" />
					</Form.Group>
					{/* Dodaj składnikik! */}
				</Form.Row>
            </Form.Group>

            <Form.Group as={Col} controlId="formGridPassword">
				<Form.Row>
					<Form.Group as={Col}>
            	<Form.Label>Typ dania</Form.Label>
				<Form.Control as="select" defaultValue="Wybierz typ dania">
                		<option> Kolacja </option>
                		<option> Podwieczorek </option>
						<option> Przekąska </option>
                	</Form.Control>
					</Form.Group>
					<Form.Group as={Col}>
					<Form.Label>Alergeny</Form.Label>
            		<Form.Check type="checkbox" label="Check me out" />
					</Form.Group>
				</Form.Row>
			</Form.Group>
            </Form.Row>

			<Form.Group controlId="formGridRDescription">
            	<Form.Label>Przygotowanie </Form.Label>
    			<Form.Control as="textarea" aria-label="With textarea" style={{height: "300px"}}/>
            </Form.Group>

            <Form.Row>
            	<Form.Group as={Col} controlId="formGridCity">
            		<Form.Label>City</Form.Label>
            		<Form.Control />
            	</Form.Group>

            	<Form.Group as={Col} controlId="formGridState">
                	<Form.Label>State</Form.Label>
                	<Form.Control as="select" defaultValue="Choose...">
                		<option>Choose...</option>
                		<option>...</option>
                	</Form.Control>
            	</Form.Group>

            	<Form.Group as={Col} controlId="formGridZip">
            		<Form.Label>Zip</Form.Label>
                	<Form.Control />
            	</Form.Group>
            </Form.Row>

            <Form.Group id="formGridCheckbox">
            	<Form.Check type="checkbox" label="Check me out" />
            </Form.Group>
			</Form>
		  </Container>
      </div>
    );
  }
}