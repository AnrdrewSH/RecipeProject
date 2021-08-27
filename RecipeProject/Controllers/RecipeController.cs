using Application;
using Application.RecipeDtoEntities;
using Application.Services.Converters;
using Application.Services.RecipeServices;
using Domain.Entities;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeDtoConverter _recipeDtoConverter;

        public RecipeController(
            IRecipeRepository recipeRepository,
            IRecipeService recipeService,
            IUnitOfWork unitOfWork,
            IRecipeDtoConverter recipeDtoConverter)
        {
            _recipeRepository = recipeRepository;
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
            _recipeDtoConverter = recipeDtoConverter;
        }

        [HttpGet("{id:int}")]
        public Recipe GetRecipeById(int id)
        {
            Recipe recipe = _recipeRepository.GetById(id);
            return recipe;
        }

        [HttpGet]
        public List<RecipeDto> GetAllFullRecipe()
        {
            List<Recipe> recipes = _recipeRepository.GetAll();
            List<RecipeDto> recipesDtos = new List<RecipeDto>();
            foreach (var recipe in recipes)
            {
                recipesDtos.Add(_recipeDtoConverter.ConvertToRecipeDto(recipe));
            }

            return recipesDtos;
        }

        [HttpGet("findByTag/{nameoftag}")]
        public List<RecipeDto> GetRecipeByTag(string nameoftag)
        {
            List<Recipe> recipes = _recipeRepository.GetAll()
                .Where(item => IsTagsContainsTag(item.Tags, nameoftag))
                .ToList();

            List<RecipeDto> recipesDtos = new List<RecipeDto>();
            foreach (var recipe in recipes)
            {
                recipesDtos.Add(_recipeDtoConverter.ConvertToRecipeDto(recipe));
            }

            return recipesDtos;
        }

        [HttpGet("findByName/{nameofrecipe}")]
        public List<RecipeDto> GetRecipeByName(string nameofrecipe)
        {
            List<Recipe> recipes = _recipeRepository.GetByName(nameofrecipe);

            List<RecipeDto> recipesDtos = new List<RecipeDto>();
            foreach (var recipe in recipes)
            {
                recipesDtos.Add(_recipeDtoConverter.ConvertToRecipeDto(recipe));
            }

            return recipesDtos;
        }

        [HttpPost]
        public void AddRecipe([FromBody] RecipeDto recipeDto)
        {
            _recipeService.AddRecipe(recipeDto);
            _unitOfWork.Commit();
        }

        [HttpDelete("{id}")]
        public void DeleteRecipe(int id)
        {
            _recipeRepository.DeleteRecipe(id);
            _unitOfWork.Commit();
        }

        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] RecipeDto recipeDto)
        {
            _recipeService.Update(recipeDto);
            _unitOfWork.Commit();
        }

        private bool IsTagsContainsTag(List<Tag> tags, string tag)
        {
            return tags
                .Select(item => item.Name)
                .Contains(tag);
        }
    }
}
