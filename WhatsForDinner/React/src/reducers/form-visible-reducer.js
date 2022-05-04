import * as c from './../actions/ActionTypes';
// eslint-disable-next-line import/no-anonymous-default-export
export default(state = false, action)=>{
  switch(action.type){
    case c.TOGGLE_FORM:
      return!state;
      default: 
      return state;
  }
};