import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom'

class UserList extends Component {
  state = {  }
  render() { 
    return ( 
       
        <div>
          <ul>
            {
                <li key={1}>
                  <Link to={`/User/${1}`}>{'User Name'}</Link>
                </li>
            }
          </ul>
        </div>
     );
  } 
}

export default connect(null, {})(UserList)
