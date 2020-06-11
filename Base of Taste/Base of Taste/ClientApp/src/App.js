import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AddRecipe } from './components/AddRecipe/AddRecipe';
import { Menu } from './components/Menu/Menu';
import { Filtr } from './components/Flirt/Filtr';


 class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={ Home } />
        <Route exact path='/AddRecipe' component={ AddRecipe } />
        <Route exact path='/Menu' component={ Menu } />
        <Route exact path='/Filtr' component={ Filtr } />
      </Layout>
    );
  }
}

export default App;