import React from 'react';
import Recipe from './Recipe/Recipe'

const Recipes = (props) => {

    return props.przepis.map((rec, id) => {
        return(
            <Recipe
			nazwa = {rec.nazwa}
			opis= {rec.opis}
			trudnosc = {rec.trudnosc}
			przygotowanie = {rec.przygotowanie}
			key={rec.id}
			click = {() => props.clicked(rec.id)}
			/>
        );
    });
}

export default Recipes;