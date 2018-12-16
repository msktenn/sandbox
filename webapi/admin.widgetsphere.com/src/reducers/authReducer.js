import { LOGIN, LOGOUT } from '../actions/types';

const initialState = { Authentication: { isAuthenticated: false } };

export default function(state = initialState, action) {
  console.log('postreducer1');
  switch (action.type) {
    case LOGIN:
      return {
        ...state,
      };

    case LOGOUT:
      return {
        ...state,
      };

    default:
      console.log('state' + action.type);
      return state;
  }
}
