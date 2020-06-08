import React, { Component } from 'react';
import Recipes from './Recipes/Recipes';
import RecipeCard from './Recipes/Recipe/RecipeCard';
import Modal from 'react-bootstrap/Modal';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;
  state = {
	  przepis:[{
		  id: 'melsf',
		  nazwa: 'Omlet',
		  opis: 'Bardzo smaczny jajeczny omlecik',
		  trudnosc: 2,
		  przygotowanie: 'Rozpuszczam tłuszcz na patelni z nieprzywierającą powierzchnią, wlewam jajka. Po 30 sekundach mieszam szpatułką środek omletu i jeszcze raz rozprowadzam masę. Po 4-5 minutach masa się zetnie, wtedy składam omlet na pół i wykładam na talerz.'
	  },{
		id: 'sdasfd',
		nazwa: 'Jajka na twardo',
		opis: 'Jajeczka na twardo czyli bez płynnego żółtka',
		trudnosc: 1,
		przygotowanie: 'Do garnka nalewam wodę. Wkładam jajka i wstawiam na gaz. Czekam aż woda się zagotuje. Od momentu zagotowania się wody, jajka powinny się gotować 8 minut. Dokładnie 8 minut. Ostrożnie wylewam wodę z garnka. Wlewam na jej miejsce zimną wodę, aby lekko schłodzić jajka i zatrzymać proces gotowania.'
	},{
		id: 'sfscza',
		nazwa: 'Placki ziemniaczane',
		opis: 'Placuszki z ziemniaczków, idealne do cacyków',
		trudnosc: 3,
		przygotowanie: 'Ziemniaki obieramy płuczemy. cebulę obieramy. Dodajemy jajko i mąkę pszenną ok 3 duże łyżki. Doprawiamy do smaku solą i pieprzem. Na patelni rozgrzewamy tłuszcz i nakładamy ok 2 łyżki masy na jednego placka. Smażymy na złoto ok 2 do 3 minut z każdej strony. Podajemy z ulubionym dodatkiem bądź same.'
	}],
	ModalShow: false,
	chosenRecepie: 'id'
	}

	RecepieClick = (recepieKey) => {
		this.setState({ModalShow: true});
		// let recepie = { ...this.state.przepis[recepieIndex] };
		// this.setState( {chosenRecepie: this.state.przepis[recepieIndex]});
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
				  <Modal
					show={this.state.ModalShow}
					aria-labelledby="simple-modal-title"
					aria-describedby="simple-modal-description"
					onHide={() => this.setState({ ModalShow: false })}
					centered
					size="lg"
					aria-labelledby="contained-modal-title-vcenter"
				  >
					<RecipeCard
					przepis = {this.state.przepis[recepieIndex]}
					/>
				  </Modal>
			  );
		}

    return (
      <div className = "Home">
        <h1> Przepisy </h1>
		<p> jAKIEŚ CUDA Z css WIĘC DAJE OPISIK </p>
		{recipes}
		{recepie}
      </div>
    );
  }
}
