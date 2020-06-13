import React, { useState } from 'react';


function Page2( ) {

    const [count, setCount] = useState(0);

    function clickHandler() {
        setCount(count + 1);
    }

    return (
        <div>
            <h1>Page 2</h1>
            <p>You clicked {count} times</p>
            <button onClick={clickHandler}>Click me</button>
        </div>
    );
}
export default Page2;