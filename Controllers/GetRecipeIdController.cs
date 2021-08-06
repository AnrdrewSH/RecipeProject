using Microsoft.AspNetCore.Mvc;
using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetRecipeIdController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipeIdController(IRecipeRepository irecipeRepository)
        {
            _recipeRepository = irecipeRepository;
        }

        [HttpGet]
        public int Get()
        {
            return _recipeRepository.GetRecipeId();
        }
    }
}
