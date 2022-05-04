import React from 'react';
import Recipe from './Recipe';
import PropTypes from 'prop-types';

function RecipeList(props){
  return(
    <React.Fragment>
      <hr/>
      {Object.values(props.recipeList).map((recipe, index)=>
        <Recipe
        whenRecipeClicked = {props.onRecipeSelection}
        recipeName = {recipe.recipeName}
        recipeUrl = {recipe.recipeUrl}
        ingredients = {recipe.ingredients}
        minDays = {recipe.minDays}
        maxDays = {recipe.maxDays}
        id = {recipe.id}
        key = {recipe.id}
        />
      )}
    </React.Fragment>
  );
}

RecipeList.propTypes = {
  recipeList: PropTypes.object,
  onRecipeSelection: PropTypes.func
};

export default RecipeList;