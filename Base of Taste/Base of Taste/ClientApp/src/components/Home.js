import React, { Component } from 'react';
// import {Button, Modal} from 'react-bootstrap';
import Recepie from './Recipe/Recipe';
import './Home.css'


export class Home extends Component {
  static displayName = Home.name;
  state = {
	  przepis:[{
		  nazwa: 'Omlet',
		  opis: 'Bardzo smaczny jajeczny omlecik',
		  trudnosc: 2,
		  przygotowanie: 'Rozpuszczam tłuszcz na patelni z nieprzywierającą powierzchnią, wlewam jajka. Po 30 sekundach mieszam szpatułką środek omletu i jeszcze raz rozprowadzam masę. Po 4-5 minutach masa się zetnie, wtedy składam omlet na pół i wykładam na talerz.'
	  },{
		nazwa: 'Jajka na twardo',
		opis: 'Jajeczka na twardo czyli bez płynnego żółtka',
		trudnosc: 1,
		przygotowanie: 'Do garnka nalewam wodę. Wkładam jajka i wstawiam na gaz. Czekam aż woda się zagotuje. Od momentu zagotowania się wody, jajka powinny się gotować 8 minut. Dokładnie 8 minut. Ostrożnie wylewam wodę z garnka. Wlewam na jej miejsce zimną wodę, aby lekko schłodzić jajka i zatrzymać proces gotowania.'
	},{
		nazwa: 'Placki ziemniaczane',
		opis: 'Placuszki z ziemniaczków, idealne do cacyków',
		trudnosc: 3,
		przygotowanie: 'Ziemniaki obieramy płuczemy. cebulę obieramy. Dodajemy jajko i mąkę pszenną ok 3 duże łyżki. Doprawiamy do smaku solą i pieprzem. Na patelni rozgrzewamy tłuszcz i nakładamy ok 2 łyżki masy na jednego placka. Smażymy na złoto ok 2 do 3 minut z każdej strony. Podajemy z ulubionym dodatkiem bądź same.'
	}
	]
	}
  render () {
	let Recepies = (
		<div className = "rec">
			{this.state.przepis.map(rec =>
				<Recepie
				nazwa = {rec.nazwa}
				opis= {rec.opis}
				trudnosc = {rec.trudnosc}
				przygotowanie = {rec.przygotowanie}>
				</Recepie>
			)}
		</div>
	);

    return (
      <div className = "Home">
        <h1> Przepisy </h1>
		<p> jAKIEŚ CUDA Z css WIĘC DAJE OPISIK </p>
		{Recepies}
      </div>
    );
  }
}
