import React from 'react';
import PropTypes from 'prop-types';
import ReusableForm from './ReusableForm';

function EditRecipeForm(props){
  const {recipe} = props;
  function handleEditRecipeFormSubmission(event){
    event.preventDefault();
    props.onEditRecipe({recipeName: event.target.recipeName.value, recipeUrl: event.target.recipeUrl.value, ingredients: event.target.ingredients.value, minDays: parseInt(event.target.minDays.value), maxDays: parseInt(event.target.maxDays.value), id: recipe.id});
  }
  return(
    <React.Fragment>
      <ReusableForm formSubmissionHandler = {handleEditRecipeFormSubmission} buttonText = "Add Recipe"/>
    </React.Fragment>
  );
}

EditRecipeForm.propTypes = {
  onEditRecipe: PropTypes.func
};

export default EditRecipeForm;