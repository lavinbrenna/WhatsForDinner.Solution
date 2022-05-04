import {connect} from 'react-redux';
import React from 'react';
import NewRecipeForm from './NewRecipeForm';
import RecipeList from './RecipeList';
import RecipeDetail from './RecipeDetail';
import EditRecipeForm from './EditRecipeForm';
import PropTypes from 'prop-types';
import * as a from './../actions';

class RecipeControl extends React.Component{
  constructor(props){
    super(props);
    this.state ={
      selectedRecipe : null,
      editing: false
    };
  }

  handleClick = ()=> {
    if(this.state.selectedRecipe != null){
      this.setState({
        selectedRecipe: null, 
        editing: false
      });
    }else{
      const {dispatch} = this.props;
      const action = a.toggleForm();
      dispatch(action);
    }
  }

  handleEditClick =()=>{
    this.setState({editing: true});
  }

  handleAddingNewRecipeToList = (newRecipe)=>{
    const {dispatch} = this.props;
    const action = a.addRecipe(newRecipe);
    dispatch(action);
    const action2 = a.toggleForm();
    dispatch(action2);
  }

  handleEditingRecipeInList = (recipeToEdit)=>{
    const {dispatch} = this.props;
    const action = a.addRecipe(recipeToEdit);
    dispatch(action);
    this.setState({
      editing:false,
      selectedRecipe: null
    });
  }

  handleChangingSelectedRecipe = (id) => {
    const selectedRecipe = this.props.mainRecipeList[id];
    this.setState({selectedRecipe : selectedRecipe});
  }

  handleDeletingRecipe = (id)=>{
    const {dispatch} = this.props;
    const action = a.deleteRecipe(id);
    dispatch(action);
    this.setState({selectedRecipe: null});
  }

  render(){
    let currentlyVisibleState = null;
    let buttonText = null;

    if(this.state.editing){
      currentlyVisibleState = <EditRecipeForm recipe = {this.state.selectedRecipe}
      onEditRecipe = {this.handleEditingRecipeInList}/>
      buttonText = "Return to Recipe Index";
    }
    else if(this.state.selectedRecipe != null){
      currentlyVisibleState = <RecipeDetail recipe ={this.state.selectedRecipe} onClickingDelete = {this.handleDeletingRecipe} onClickingEdit = {this.handleEditClick}/>
      buttonText = "Return to Recipe Index";
    }
    else if(this.props.formVisibleOnPage){
      currentlyVisibleState = <NewRecipeForm onNewRecipeCreation = {this.handleAddingNewRecipeToList}/>
      buttonText = "Return to Recipe Index"
    }
    else{
      currentlyVisibleState = <RecipeList recipeList = {this.props.mainRecipeList} onRecipeSelection = {this.handleChangingSelectedRecipe}/>;
      buttonText = "Add Recipe";
    }
    return(
      <React.Fragment>
        {currentlyVisibleState}
        <button onClick = {this.handleClick}>{buttonText}</button>
      </React.Fragment>
    );
  }
}

RecipeControl.propTypes = {
  mainRecipeList: PropTypes.object,
  formVisibleOnPage: PropTypes.bool
}

const mapStateToProps = state =>{
  return {
    mainRecipeList: state.mainRecipeList,
    formVisibleOnPage: state.formVisibleOnPage
  }
}

RecipeControl = connect(mapStateToProps)(RecipeControl);
export default RecipeControl;