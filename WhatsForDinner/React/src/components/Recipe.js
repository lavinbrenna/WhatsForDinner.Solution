import React from 'react';
import PropTypes from 'prop-types';

function Recipe(props){
  return(
    <React.Fragment>
      <div onClick = {()=> props.whenRecipeClicked(props.id)}>
        <h4>{props.recipeName}</h4>
        <hr/>
      </div>
    </React.Fragment>
  );
}

Recipe.propTypes = {
  recipeName: PropTypes.string.isRequired,
  id: PropTypes.string,
  whenRecipeClicked: PropTypes.func
};

export default Recipe;