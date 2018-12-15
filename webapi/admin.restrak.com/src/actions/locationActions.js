import { URL_CHANGED } from './types';

export const ChangeUrl = () => dispatch => {
  console.log('ChangeUrl');
  dispatch({
    type: URL_CHANGED,
  });
};
