import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';

import { Switch, Route } from 'react-router-dom';
import UserList from './UserList';
import User from './User';

class UserManager extends Component {
  state = {};
  render() {
    return (
      <Switch>
        <Route exact path="/User" component={UserList} />
        <Route path="/User/:number" component={User} />
      </Switch>
    );
  }
}

export default connect(
  null,
  {}
)(UserManager);
