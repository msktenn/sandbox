import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';

class Login extends Component {
  render() {
    console.log('Login');
    return (
      <div>
        <h1>Welcome to the Tornadoes Website!</h1>
      </div>
    );
  }
}

export default connect(
  null,
  {}
)(Login);
