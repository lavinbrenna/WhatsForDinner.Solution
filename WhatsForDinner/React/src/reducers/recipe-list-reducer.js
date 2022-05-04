import * as c from './../actions/ActionTypes';

// eslint-disable-next-line import/no-anonymous-default-export
export default(state = {}, action) => {
  const {recipeName, recipeUrl, ingredients, minDays, maxDays, id} = action;
  switch(action.type){
    case c.ADD_RECIPE:
      return Object.assign({}, state, {
        [id]: {
          recipeName: recipeName,
          recipeUrl: recipeUrl, 
          ingredients: ingredients,
          minDays: minDays,
          maxDays: maxDays,
          id: id
        }
      });
    case c.DELETE_RECIPE:
      let newState = {...state};
      delete newState[id];
      return newState;
    default:
    return state;
    }
};