import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AddRecipe } from './components/AddRecipe/AddRecipe';


 class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={ Home } />
        <Route exact path='/AddRecipe' component={ AddRecipe } />
        {/* <Route path='/counter' component={ Menu } />
        <Route path='/fetch-data' component={ Flirt } /> */}
      </Layout>
    );
  }
}

export default App;