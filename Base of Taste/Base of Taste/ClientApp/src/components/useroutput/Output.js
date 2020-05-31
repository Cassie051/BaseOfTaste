import React from 'react'

const Output = (props) => {
    let msg = 'Text long enought';
    if (props.InputLength < 5){
        msg = 'Text too short!';
    }


    return(
        <div>
            <p> {msg} </p>
        </div>
    );
};

export default Output;