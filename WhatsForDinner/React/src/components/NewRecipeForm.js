import React from 'react';
import { v4 } from 'uuid';
import PropTypes from 'prop-types';
import ReusableForm from './ReusableForm';

function NewRecipeForm(props){
  function handleNewRecipeFormSubmission(event){
    event.preventDefault();
    props.onNewRecipeCreation({recipeName: event.target.recipeName.value, recipeUrl: event.target.recipeUrl.value, ingredients: event.target.ingredients.value, minDays: parseInt(event.target.minDays.value), maxDays: parseInt(event.target.maxDays.value), id: v4()});
  }
  return(
    <React.Fragment>
      <ReusableForm formSubmissionHandler = {handleNewRecipeFormSubmission} buttonText = "Add Recipe"/>
    </React.Fragment>
  );
}

NewRecipeForm.propTypes = {
  onNewRecipeCreation: PropTypes.func
};

export default NewRecipeForm;