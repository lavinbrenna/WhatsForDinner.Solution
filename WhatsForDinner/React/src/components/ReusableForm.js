import React from 'react';
import PropTypes from 'prop-types';

function ReusableForm(props){
  return(
    <React.Fragment>
      <form onSubmit={props.formSubmissionHandler}>
        <label>Recipe Name:</label>
        <input
        type='text'
        name='recipeName'
        placeholder='Recipe Name'/>
        <label>Recipe URL(optional): </label>
        <input
        type='text'
        name='recipeUrl'
        placeholder='URL (optional)'
        />
        <label>Ingredients:</label>
        <textarea
        name ='ingredients'
        placeholder = 'Enter your ingredients here'/>
        <label>How often could you eat this meal? (in days)</label>
        <input
        type='number'
        name='minDays'
        placeholder = 'Minimum #'/>
        <label>How many days max would you go without this meal?</label>
        <input
        type='number'
        name='maxDays'
        placeholder='Maximum #'/>
        <button type='submit'>{props.buttonText}</button>
      </form>
    </React.Fragment>
  );
}

ReusableForm.propTypes = {
  formSubmissionHandler: PropTypes.func,
  buttonText: PropTypes.string
};

export default ReusableForm;