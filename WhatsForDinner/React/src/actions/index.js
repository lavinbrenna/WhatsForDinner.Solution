import * as c from './ActionTypes';

export const deleteRecipe = id =>({
  type: c.DELETE_RECIPE,
  id
});

export const toggleForm = () =>({
  type: c.TOGGLE_FORM
});

export const addRecipe = (recipe) => {
  const {recipeName, recipeUrl, ingredients, minDays, maxDays, id} = recipe;
  return{
    type: c.ADD_RECIPE,
    recipeName: recipeName,
    recipeUrl: recipeUrl,
    ingredients: ingredients,
    minDays: minDays,
    maxDays: maxDays,
    id: id
  }
}