import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';

class User extends Component {
  state = {};
  render() {
    return (
      <div>
        <h1>
          {'Bob Hope'} (#{'3'})
        </h1>
        <h2>Position: {'pitcher'}</h2>
        <Link to="/User">Back</Link>
      </div>
    );
  }
}

export default connect(
  null,
  {}
)(User);
