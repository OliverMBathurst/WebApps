import React from 'react';

export default Response = (props) => {
    const { response: { time, value, exception } } = props
    return (
        <div>
            <p>Time: {time} Value: {value}</p>
        </div>
    )
}