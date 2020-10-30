import React, { Component } from 'react';

export class Entropy extends Component {
  static displayName = Entropy.name;

    constructor(props) {
        super(props);
        this.state = {}
        this.fetchEntropy = this.fetchEntropy.bind(this);
    }

    async fetchEntropy () {
        const response = await fetch('entropy/fetch/type/1')
        const data = await response.json();

        this.setState({
            number: data.value
        })        
    }

  render() {
    return (
      <div>
        <h1>Entropy</h1>

        <p>This is a simple example of a React component.</p>

        <p aria-live="polite">Entropy: <strong>{this.state.number}</strong></p>

        <button className="btn btn-primary" onClick={this.fetchEntropy}>Increment</button>
      </div>
    );
  }
}
