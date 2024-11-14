import { LOGIN, LOGOUT } from './types';

export const Login = () => dispatch => {
  console.log('login');
  dispatch({
    type: LOGIN,
  });
};

export const Logout = () => dispatch => {
  console.log('logout');
  dispatch({
    type: LOGOUT,
  });
};
