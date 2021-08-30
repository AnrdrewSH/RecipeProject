export class IngredientItem {
  public ingredientItemName: string;
  public products: string;

  constructor(ingredientItemName: string, products: string) {
    this.ingredientItemName = ingredientItemName;
    this.products = products;
  }
}