import React, { Component } from 'react';
import {Col, Row, Container, Button, Form, Modal} from 'react-bootstrap';
import MealType from './AddingModals/MealType';
import SaveInfo from './SaveInfo/SaveInfo';
import { IconContext } from "react-icons";
import { IoIosAdd } from "react-icons/io";
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
	}],
	ReicpeAdddStatus: false,
	fun: '',
	saveState: false
  }


  AddClick = (name) => {
	this.setState({ ReicpeAdddStatus: true});
	this.setState({ fun: name })
}

	saveBase = () => {
		this.setState({saveState: !this.state.saveState});
	}

	render () {
	  let info = null;

	  if(this.state.saveState === true) {
		  info = (
			<SaveInfo/>
		  );
	  }

	  let addModal = (
		<Modal
		show={this.state.ReicpeAdddStatus}
		aria-labelledby="simple-modal-title"
		aria-describedby="simple-modal-description"
		onHide={() => this.setState({ ReicpeAdddStatus: false })}
		centered
		size="lg"
		>
		<MealType funkcja = {this.state.fun}/>
		</Modal>
	  );
    return (
		<div>
			{info}
			<div className = "AddRecipe">
			<Container >
				<Form>
				  <Row>
					  <Col> <h1> Dodaj przepis </h1> </Col>
					  <Col md="auto" style={{paddingTop: "1%"}}>
						  <Button className="Invert" size='lg' onClick = {this.saveBase}> Zapisz przepis w bazie </Button>
						  </Col>
				  </Row>
				<Form.Row style = {{paddingTop: "5%"}}>
				<Form.Group as={Col} controlId="formGridRName">
					<Form.Label>Nazwa</Form.Label>
					<Form.Control type="przepis.nazwa" placeholder="Wpisz nazwę przepisu" />
				</Form.Group>
				<Form.Group as={Col} md = {3}>
				<Form.Label>Typ dania</Form.Label>
				<Form.Row>
					<Form.Control as="select" defaultValue="Wybierz typ dania">
							<option> Kolacja </option>
							<option> Podwieczorek </option>
							<option> Przekąska </option>
						</Form.Control>
				</Form.Row>
					<Row style = {{ paddingTop: "3%",  paddingLeft: "60%"}}>
					<Button size='sm' onClick = {() => this.AddClick('Dodaj Typ dania')}> Dodaj Typ dania </Button>
					</Row>
				</Form.Group>
				<Form.Group as={Col} md = {3} >
				<Form.Label>Dieta</Form.Label>
				<Form.Row>
					<Form.Control as="select" defaultValue="Wybierz typ dania">
							<option> Wegetariańska </option>
							<option> Bezmleczna </option>
							<option> Wegańska </option>
						</Form.Control>
				</Form.Row>
					<Row style = {{ paddingTop: "3%",  float: "right", paddingRight: "5%"}}>
					<Button size='sm'  onClick = {() => this.AddClick('Dodaj Typ Diety')}> Dodaj Dietę </Button>
					</Row>
				</Form.Group>
	
				<Form.Group as={Col} controlId="formGridRlvl" md = {2} >
					<Form.Row>
					<Form.Label>Trudność</Form.Label>
					<Form.Control as="select" defaultValue="Określ trudność wykonania">
							<option>1</option>
							<option>2</option>
						</Form.Control>
					</Form.Row>
					<Row style = {{ paddingTop: "3%",  paddingLeft: "40%"}}>
					<Button size='sm' onClick = {() => this.AddClick('Dodaj Trudność')}> Dodaj Trudność </Button>
					</Row>
				</Form.Group>
				</Form.Row>
				<Form.Row>
					<Form.Group as={Col} controlId="formGridRDescription" style = {{paddingRight: "2%"}}>
						<Form.Label>Opis</Form.Label>
						<Form.Control placeholder="Wpisz krótki opis przepisu" />
					</Form.Group>
					<Form.Group as={Col} md={2}>
						<Form.Label>Alergeny</Form.Label>
						<Form.Check type="checkbox" label="Orzechy laskowe" />
						<Form.Check type="checkbox" label="Orzechy ziemne" />
						<Form.Check type="checkbox" label="Seler" />
						<Form.Check type="checkbox" label="Mleko" />
						</Form.Group>
						<Col md={2} style = {{paddingRight: "2%", margin: "auto"}}>
						<Button size='sm' onClick = {() => this.AddClick('Dodaj Alergen')}> Dodaj Alergen </Button>
						</Col>
				</Form.Row>
	
				<Form.Row >
				<Form.Group as={Col} controlId="formGridRName">
					<Form.Row>
						<Form.Group as={Col}>
						<Form.Label>Składniki</Form.Label>
						<Form.Control as="select" defaultValue="Wybierz typ dania">
							<option> Mąka </option>
							<option> Cukier </option>
							<option> Jajka </option>
						</Form.Control>
						</Form.Group>
						<Form.Group as={Col} >
						<Form.Label>Ilość</Form.Label>
							<Form.Control type="przepis.ilosc" placeholder="Wpisz liczbę" />
						</Form.Group>
						<Form.Group as={Col} >
						<Form.Label>Jednostka</Form.Label>
						<Form.Control as="select" defaultValue="Wybierz typ dania">
							<option> gram </option>
							<option> miligram </option>
							<option> litr </option>
						</Form.Control>
						</Form.Group>
						<Col md = {2} style = {{paddingTop: "6%"}}>
							<Button className="InvertS" >
								<IconContext.Provider value={{ size: "2em", color: "whitesmoke", verticalAlign: 'middle' }}>
								 <IoIosAdd />
								</IconContext.Provider>
							</Button>
						</Col>
					</Form.Row>
					<Row style = {{paddingLeft: "3%"}}>
					<Col style = {{paddingLeft: "60%", paddingTop: "1%"}}>
						<Button size='sm'  onClick = {() => this.AddClick('Dodaj Składnik')}> Dodaj składnik </Button>
						</Col>
					</Row>
				</Form.Group>
	
				<Form.Group as={Col}>
					<Form.Row>
					<Form.Group as={Col}>
						<Form.Label>Wartość odżywcza</Form.Label>
						<Form.Control as="select" defaultValue="Wybierz typ dania">
							<option> Kalorie </option>
							<option> Węglowodany </option>
							<option> Białko </option>
							<option> Tłuszcze </option>
						</Form.Control>
						</Form.Group>
						<Form.Group as={Col}>
						<Form.Label>Ilość</Form.Label>
							<Form.Control type="przepis.ilosc" placeholder="Wpisz liczbę" />
						</Form.Group>
						<Form.Group as={Col} >
						<Form.Label>Jednostka</Form.Label>
						<Form.Control as="select" defaultValue="Wybierz typ dania">
							<option> gram </option>
							<option> miligram </option>
							<option> kcal </option>
						</Form.Control>
						</Form.Group>
						<Col md = {1} style = {{paddingTop: "6%"}}>
							<Button className="InvertS" >
								<IconContext.Provider value={{ size: "2em", color: "whitesmoke", verticalAlign: 'middle' }}>
								 <IoIosAdd />
								</IconContext.Provider>
							</Button>
						</Col>
					</Form.Row>
					<Row style = {{paddingLeft: "3%"}}>
						<Col style = {{paddingLeft: "55%", paddingTop: "1%"}}>
						<Button size='sm'  onClick = {() => this.AddClick('Dodaj Wartość odżywczą')}> Dodaj Wartosci odżywcze </Button>
						</Col>
					</Row>
				</Form.Group>
				</Form.Row>
	
				<Form.Group controlId="formGridRDescription">
					<Form.Label>Przygotowanie </Form.Label>
					<Form.Control as="textarea" aria-label="With textarea" style={{height: "300px"}}/>
				</Form.Group>
				</Form>
	
	
				{addModal}
			  </Container>
		  </div>
		</div>
		);
  }
}