import React from 'react';
import PropTypes from 'prop-types';

function RecipeDetail(props){
  const {recipe, onClickingDelete} = props;
  return(
    <React.Fragment>
      <h1>{recipe.recipeName}</h1>
      <hr/>
      if({recipe.recipeUrl != null}){
        <p><a href={recipe.recipeUrl}>{recipe.recipeName}'s url</a></p>
      }
      <h3>Ingredients:</h3>
      <p>{recipe.ingredients}</p>
      <hr/>
      <button onClick={()=> onClickingDelete(recipe.id)}>Delete Recipe</button>
      <button onClick = {()=> props.onClickingEdit(recipe.id)}>Update Recipe</button>
    </React.Fragment>
  );
}

RecipeDetail.propTypes = {
  recipe: PropTypes.object,
  onClickingDelete: PropTypes.func,
  onClickingEdit: PropTypes.func
};

export default RecipeDetail;