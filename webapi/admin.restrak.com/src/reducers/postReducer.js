import { FETCH_POSTS, NEW_POST } from "../actions/types";
const initialState = {
  items: [],
  item: {}
};



export default function(state = initialState, action) {
  console.log("postreducer1");
  switch (action.type) {
    case FETCH_POSTS:
      return {
        ...state,
        items: action.payload
      };
    default:
      console.log("state" + action.type);
      return state;
  }
}
