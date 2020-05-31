import React, { Component } from 'react';
import Output from './useroutput/Output';
import Char from './useroutput/Char';
import './Home.css'

export class Home extends Component {
  static displayName = Home.name;
  state = {
    words: ''
  }

  delateChar = (index) =>{
    const text = this.state.words.split('');
    text.splice(index, 1);
    const updateText = text.join('');
    this.setState({ words: updateText});
  }

  nameChangedHandler = ( event ) => {
    this.setState({
			words: event.target.value
  })
}
  render () {
    const List = this.state.words.split('').map((ch, index) => {
      return <Char
      charCh = {ch}
      key = {index}
      clicked = { () => this.delateChar(index)}
      />
    });
    return (
      <div className="Home">
        <ol>
          <li>Create an input field (in App component) with a change listener which outputs the length of the entered text below it (e.g. in a paragraph).</li>
          <li>Create a new component (=> ValidationComponent) which receives the text length as a prop</li>
          <li>Inside the ValidationComponent, either output "Text too short" or "Text long enough" depending on the text length (e.g. take 5 as a minimum length)</li>
          <li>Create another component (=> CharComponent) and style it as an inline box (=> display: inline-block, padding: 16px, text-align: center, margin: 16px, border: 1px solid black).</li>
          <li>Render a list of CharComponents where each CharComponent receives a different letter of the entered text (in the initial input field) as a prop.</li>
          <li>When you click a CharComponent, it should be removed from the entered text.</li>
        </ol>
        <hr/>
        <h3>Type word</h3>
        <input type="text" onChange={this.nameChangedHandler} value={this.state.words} />
        <Output
        InputLength = {this.state.words.length}
        ></Output>
         <p> {this.state.words} </p>
         {List}
		</div>
    );

  }
}
