import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Route, Link, Switch } from 'react-router-dom';

// import pages
import HomePage from './pages/homepage';
import Page1 from './pages/page1';
import Page2 from './pages/page2';
import Page3 from './pages/page3';
import NotFound404 from './pages/notfound404';

class App extends React.Component {

    render() {
        return (
            <Router>
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark static-top">
                    <a className="navbar-brand" href="/">Test React Project</a>
                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarResponsive">
                        <ul className="navbar-nav ml-auto">
                            <li><Link to={'/'} className="nav-link">Home</Link></li>
                            <li><Link to={'/page1'} className="nav-link">Page 1</Link></li>
                            <li><Link to={'/page2'} className="nav-link">Page 2</Link></li>
                            <li><Link to={'/page3'} className="nav-link">Page 3</Link></li>
                        </ul>
                    </div>
                </nav>

                <Switch>
                    <Route exact path='/' component={HomePage} />
                    <Route path='/page1' component={Page1} />
                    <Route path='/page2' component={Page2} />
                    <Route path='/page3' component={Page3} />
                    <Route path="*" component={NotFound404} />
                </Switch>
            </Router>
        )
    }
}


export default App;
