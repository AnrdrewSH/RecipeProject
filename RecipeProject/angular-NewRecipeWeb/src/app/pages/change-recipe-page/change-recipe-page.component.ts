import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { RecipeDto } from 'src/app/Classes/RecipeDto';
import { StepItem } from 'src/app/Classes/StepItem';
import { TagItem } from 'src/app/Classes/TagItem';
import { IngredientItem } from 'src/app/Classes/IngredientItem';

var recipeDtoById: RecipeDto;

@Component({
  selector: 'app-change-recipe-page',
  templateUrl: './change-recipe-page.component.html',
  styleUrls: ['./change-recipe-page.component.css']
})
export class ChangeRecipePageComponent implements OnInit {

  recipeDtosById: RecipeDto[] = [];

  private _http: HttpClient;

  constructor(http: HttpClient, private route: ActivatedRoute, private router: Router)
  {
    this._http = http;
  }
  
  currentRecipeDtoName = '';
  currentRecipeDtoDescription = '';
  currentRecipeDtoPersonNumber = 1;
  currentRecipeDtoCookingTime = 1;
  currentRecipeDtoLikes = 0;
  currentRecipeDtoStars = 0;
  currentRecipeDtoIsLiked = "../../../assets/like.svg";
  currentRecipeDtoImage = '';

  currentStepItemNumber = 1;
  currentStepItemName = '';
  steps: StepItem[] = [];

  currentTagItemName = '';
  tags: TagItem[] = [];
  StringTags: string[] =[];
  StringTagsLine: string = '';

  currentIngredientItemName = '';
  currentIngredientItemProducts = '';
  ingredientItems: IngredientItem[] = [];

  currentRecipeDtoId = 0;

  async ngOnInit(): Promise<void>
  {
    this.currentRecipeDtoId = Number(this.route.snapshot.paramMap.get('id'));
    recipeDtoById = await this._http.get<RecipeDto>('/api/Recipe/' + this.currentRecipeDtoId).toPromise();
    this.recipeDtosById.push(recipeDtoById);
    this.currentRecipeDtoName = recipeDtoById.recipeName;
    this.currentRecipeDtoDescription = recipeDtoById.recipeDescription;
    this.currentRecipeDtoPersonNumber = recipeDtoById.personNumber;
    this.currentRecipeDtoCookingTime = recipeDtoById.cookingTime;
    this.currentRecipeDtoLikes = recipeDtoById.likes;
    this.currentRecipeDtoStars = recipeDtoById.stars;
    this.currentRecipeDtoImage = recipeDtoById.recipeImage;
    this.steps = recipeDtoById.steps;
    this.tags = recipeDtoById.tags;
    this.StringTags = this.tags.map(tag => tag.name)
    this.StringTagsLine = this.StringTags.join(' ')
    this.ingredientItems = recipeDtoById.ingredientItems;

    for (let i = 0; i < this.steps.length; i++)
    {
      this.steps[i].StepNumber = i + 1;
    }
  }
  
  async updateRecipe(recipe: RecipeDto)
  {
    await this._http.put(`/api/Recipe/${recipe.recipeId}`, recipe).toPromise();
    this.router.navigate(['/'])
  }

  async deleteRecipe()
  {
    await this._http.delete<RecipeDto>('/api/Recipe/' + this.currentRecipeDtoId).toPromise();
    this.router.navigate(['/'])
  }

  deleteStep(){
    this.steps.pop();
  }

  async addStepItem() {
      this.currentStepItemNumber = this.steps.length + 1;
      let newStep: StepItem = new StepItem(this.currentStepItemName, this.currentStepItemNumber);

      this.steps.push( newStep );
      this.currentStepItemName = '';
  }

  async addTagItem() {
    this.tags = [];
    this.StringTags = this.StringTagsLine.split(' ');

    for (let tag of this.StringTags)
      if (tag)
        this.tags.push(new TagItem(tag));
  }

  async addIngredientItem() {
    let newIngredientItem: IngredientItem = new IngredientItem(
      this.currentIngredientItemName, this.currentIngredientItemProducts);

    this.ingredientItems.push( newIngredientItem );
    this.currentIngredientItemName = '';
    this.currentIngredientItemProducts = '';
}

  async ChangeRecipeDto()
  {
    this.addTagItem();
    let newRecipeDto: RecipeDto = new RecipeDto(
    this.currentRecipeDtoId,
    this.currentRecipeDtoName,
    this.currentRecipeDtoDescription,
    this.currentRecipeDtoPersonNumber,
    this.currentRecipeDtoCookingTime,
    this.currentRecipeDtoLikes,
    this.currentRecipeDtoIsLiked,
    this.currentRecipeDtoStars,
    this.currentRecipeDtoImage,
    this.steps,
    this.tags,
    this.ingredientItems);
    
    this.updateRecipe(newRecipeDto)
  }

}
