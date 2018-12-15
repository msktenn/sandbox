import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { Link, withRouter } from 'react-router-dom';

// The Header creates links that can be used to navigate
// between routes.
class Header extends Component {
  render() {
    return (
      <header>
        <nav>
          <ul>
            <li>
              <Link to="/">Login</Link>
            </li>
            <li>
              <Link to="/User">Users</Link>
            </li>
          </ul>
        </nav>
      </header>
    );
  }
}

export default connect(
  null,
  {}
)(Header);
