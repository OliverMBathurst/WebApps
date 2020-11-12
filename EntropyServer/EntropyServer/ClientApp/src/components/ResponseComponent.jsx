import React, { Component } from 'react';

export default class ResponseComponent extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <p>Time: {this.props.response.time} Value: {this.props.response.value}</p>
            </div>
        )
    }
}