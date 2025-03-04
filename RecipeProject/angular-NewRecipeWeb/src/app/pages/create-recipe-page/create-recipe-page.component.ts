import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { RecipeDto } from 'src/app/Classes/RecipeDto';
import { StepItem } from 'src/app/Classes/StepItem';
import { TagItem } from 'src/app/Classes/TagItem';
import { IngredientItem } from 'src/app/Classes/IngredientItem';

@Component({
  selector: 'app-create-recipe-page',
  templateUrl: './create-recipe-page.component.html',
  styleUrls: ['./create-recipe-page.component.css']
})

export class CreateRecipePageComponent implements OnInit {
  
  currentStepItemNumber = 1;
  currentStepItemName = '';
  steps: StepItem[];
  
  currentTagItemName = '';
  tags: TagItem[] = [];
  StringTags: string[] =[];

  currentIngredientItemName = '';
  currentIngredientItemProducts  = '';
  ingredientItems: IngredientItem[] = [];

  currentRecipeDtoId = 0;
  currentRecipeDtoName = '';
  currentRecipeDtoDescription = '';
  currentRecipeDtoPersonNumber = 0;
  currentRecipeDtoCookingTime = 0;
  currentRecipeDtoLikes = 0;
  currentRecipeDtoIsLiked = "../../../assets/like.svg";
  currentRecipeDtoStars = 0;
  currentRecipeDtoImage = '';

  recipeDtos: RecipeDto[] = [];

  private _http: HttpClient;

  constructor(http: HttpClient, private router: Router) {
    this._http = http;
    this.currentStepItemName = "";
    this.currentRecipeDtoDescription = "";
    this.steps = [];
  }

  async ngOnInit(): Promise<void> {}

  async addRecipe(recipeDto: RecipeDto): Promise<void>{
    await this._http.post<void>('/api/Recipe', recipeDto).toPromise()
  }

  async deleteFormStep()
  {
    this.steps.pop();
  }

  async deleteStep(){
    this.steps.pop();
  }

  async addStepItem() {
    this.currentStepItemNumber = this.steps.length + 1;
    let newStep: StepItem = new StepItem(this.currentStepItemName, this.currentStepItemNumber);

    this.steps.push( newStep );
  }

  async addTagItem() {
    let i = 0;
    this.StringTags = this.currentTagItemName.split(' ');
    while (i < this.StringTags.length) { 
      this.currentTagItemName = this.StringTags[i];
      let newTag: TagItem = new TagItem(this.currentTagItemName);
      this.tags.push( newTag );
      i++;
    }
  }

  async addIngredientItem() {
    let newIngredientItem: IngredientItem = new IngredientItem(
    this.currentIngredientItemName,
    this.currentIngredientItemProducts);

    this.ingredientItems.push( newIngredientItem );
  }

  async addRecipeDto()
  {
    if (this.currentRecipeDtoName.length > 0 &&
      this.currentRecipeDtoDescription.length > 0 &&
      this.currentRecipeDtoPersonNumber > 0 &&
      this.currentRecipeDtoCookingTime > 0 &&
      this.steps.length > 0 &&
      this.ingredientItems.length > 0)
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
            
        this.addRecipe(newRecipeDto);        
        this.router.navigate(['/'])
        this.currentRecipeDtoId = 0;
        this.currentRecipeDtoName = '';
        this.currentRecipeDtoDescription = '';
        this.currentRecipeDtoPersonNumber = 0;
        this.currentRecipeDtoCookingTime = 0;
        this.steps = [];
        this.tags = [];
        this.ingredientItems = [];
      }
      else
      {
        alert("Не все поля заполнены!")
      }
     
  }
}
