import { combineReducers } from 'redux';
import postReducer from './postReducer';
import authReducer from './authReducer';
import locationReducer from './locationReducer';

export default combineReducers({
  authentication: authReducer,
  posts: postReducer,
  location: locationReducer,
});
