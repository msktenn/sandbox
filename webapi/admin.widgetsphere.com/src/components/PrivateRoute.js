import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { Route } from 'react-router-dom';

class PrivateRoute extends Component {
  render() {
    debugger;
    console.log('Private Route render called');
    return <PrivateRouteJSX {...this.props} />;
  }
}

const PrivateRouteJSX = ({ component: Component, ...rest }) => (
  <Route {...rest} render={props => <Component {...props} />} />
);

export default connect(
  null,
  {}
)(PrivateRoute);
