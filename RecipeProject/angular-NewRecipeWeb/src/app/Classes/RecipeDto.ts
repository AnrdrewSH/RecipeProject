import { StepItem } from './StepItem';
import { TagItem } from './TagItem';
import { IngredientItem } from './IngredientItem';

export class RecipeDto {
  public recipeId: number;
  public recipeName: string;
  public recipeDescription: string;
  public personNumber: number;
  public cookingTime: number;
  public likes: number;
  public isLiked: string = "../../../assets/like.svg";
  public stars: number;
  public recipeImage: string;
  public steps: StepItem[];
  public tags: TagItem[];
  public ingredientItems: IngredientItem[];

  constructor(
    recipeId: number,
    recipeName: string,
    recipeDescription: string,
    personNumber: number,
    cookingTime: number,
    likes: number,
    isLiked: string,
    stars: number,
    recipeImage: string,
    steps: StepItem[],
    tags: TagItem[],
    ingredientItems: IngredientItem[])
  {
    this.recipeId = recipeId;
    this.recipeName = recipeName;
    this.recipeDescription = recipeDescription;
    this.personNumber = personNumber;
    this.cookingTime = cookingTime;
    this.likes = likes;
    this.isLiked = isLiked;
    this.stars = stars;
    this.recipeImage = recipeImage;
    this.steps = steps;
    this.tags = tags;
    this.ingredientItems = ingredientItems;
  }
}
