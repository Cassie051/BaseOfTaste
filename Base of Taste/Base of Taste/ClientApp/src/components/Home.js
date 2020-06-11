import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import {Col, Row, Container, Modal, Button} from 'react-bootstrap';
import Recipes from './Recipes/Recipes';
import RecipeCard from './Recipes/Recipe/RecipeCard';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;
  state = {
	  przepis:[{
		id: '',
		nazwa: '',
		opis: '',
		trudnosc: 0,
		dieta: '',
		typ: '',
		alergeny: '',
		przygotowanie: '',
		skladniki:[],
		plik: ''
		}],
	ModalShow: false,
	chosenRecepie: 'id'
	}

	RecepieClick = (recepieKey) => {
		this.setState({ModalShow: true});
		this.setState({ chosenRecepie: recepieKey })
	}

	render () {
		let recepie = null;

		let recipes = (
			<Recipes
			przepis = {this.state.przepis}
			clicked = {this.RecepieClick}
			/>
		);

		if (this.state.chosenRecepie !== 'id'){
			const recepieIndex = this.state.przepis.findIndex(r => {
				return r.id === this.state.chosenRecepie;
			  });
			  recepie = (
				  <Col>
				  <Modal
					show={this.state.ModalShow}
					aria-labelledby="simple-modal-title"
					aria-describedby="simple-modal-description"
					onHide={() => this.setState({ ModalShow: false })}
					centered
					size="lg"
				  >
					<RecipeCard
					przepis = {this.state.przepis[recepieIndex]}
					/>
				  </Modal>
				  </Col>
			  );
		}


    return (
      <div className = "Home">
		  <Container>
			  <Row>
				  <Col> <h1> Przepisy </h1> </Col>
				  <Col md="auto" style={{paddingTop: "2%", paddingRight: "8%"}}>
					  <Link to="/AddRecipe">
					  <Button> Dodaj przepis </Button>
					  </Link>
					  </Col>
			  </Row>
			  <Row> <p> </p> </Row>
			  <Row>
				{recipes}
				{recepie}
			  </Row>
		  </Container>
      </div>
    );
  }
}