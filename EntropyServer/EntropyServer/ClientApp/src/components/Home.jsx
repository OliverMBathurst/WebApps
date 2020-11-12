import React, { Component } from 'react';
import ResponseComponent from './ResponseComponent';
import { GetEntropyResultEndpoint, GetTypeDefinitionsEndpoint } from './Functions'

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state = {
            responses: [],
            types: [],
            selectedType: 1
        }
        this.fetchEntropy = this.fetchEntropy.bind(this);
    }

    componentDidMount() {
        fetch(GetTypeDefinitionsEndpoint())
            .then(x => x.json().then(x => this.setState({ types: x })))
    }

    async fetchEntropy() {
        const response = await fetch(GetEntropyResultEndpoint(this.state.selectedType))
        const data = await response.json();

        let responses = this.state.responses;
        responses.push(data)

        this.setState({
            responses: responses
        })
    }

    render() {
        return (
            <div>
                <h1>Entropy</h1>

                <p>This is a React component that can be used to fetch entropy from the server.</p>

                <button className="btn btn-primary" onClick={this.fetchEntropy}>Fetch</button>
                
                {this.state.responses.map((x, idx) => <ResponseComponent key={idx} response={x} />)}
            </div>
        );
    }
}
