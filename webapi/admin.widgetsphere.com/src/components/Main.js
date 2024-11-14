import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  withRouter,
} from 'react-router-dom';

import Login from './Login';
import UserManager from './UserManager';
import PrivateRoute from './PrivateRoute';
import Header from './Header';

// The Main component renders one of the three provided
// Routes (provided that one matches). Both the /roster
// and /schedule routes will match any pathname that starts
// with /roster or /schedule. The / route will only match
// when the pathname is exactly the string "/"

class Main extends Component {
  render() {
    return (
      <Router>
        <main>
          <div>foo</div>
          <Header />
          <Switch>
            <Route exact path="/" component={Login} />
            <PrivateRoute path="/User" component={UserManager} />
          </Switch>
        </main>
      </Router>
    );
  }

  componentDidMount() {
    console.log('Main componentDidMount');
  }

  shouldComponentUpdate() {
    console.log('Main shouldComponentUpdate');
  }

  getSnapshotBeforeUpdate() {
    console.log('Main getSnapshotBeforeUpdate');
  }

  componentDidUpdate() {
    console.log('Main componentDidUpdate');
  }

  componentWillUnmount() {
    console.log('Main componentWillUnmount');
  }

  compoentDidCatch() {
    console.log('Main componentDidCatch');
  }

  // setState()
  // {
  //   super.setState()
  // }
}

export default connect(
  null,
  {}
)(Main);
