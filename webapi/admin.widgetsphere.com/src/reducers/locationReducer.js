import { URL_CHANGED } from '../actions/types';

const initialState = { location: '/' };

export default function(state = initialState, action) {
  console.log('locationreducer');
  switch (action.type) {
    case URL_CHANGED:
      return {
        ...state,
      };
    default:
      console.log('state' + action.type);
      return state;
  }
}
