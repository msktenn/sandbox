import React, { Component } from 'react';
import { BrowserRouter as Router, withRouter } from 'react-router-dom';

import PropTypes from 'prop-types';
import { connect } from 'react-redux';

import Header from './Header';
import Main from './Main';
import Footer from './Footer';
import PostForm from './Postform';
import Posts from './Posts';

class Layout extends Component {
  render() {
    return (
      <div>
        <Main />
        <Footer />
      </div>
    );
  }
}

export default connect(
  null,
  {}
)(Layout);
