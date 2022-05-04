import formVisibleReducer from './form-visible-reducer';
import recipeListReducer from './recipe-list-reducer';
import { combineReducers } from 'redux';

const rootReducer = combineReducers({
  formVisibleOnPage: formVisibleReducer,
  mainRecipeList: recipeListReducer
});

export default rootReducer;

