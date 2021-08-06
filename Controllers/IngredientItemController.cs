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
    public class IngredientItemController : ControllerBase
    {

        private readonly IIngredientItemRepository _IngredientItemrepository;

        public IngredientItemController(IIngredientItemRepository iIngredientItemProduct)
        {
            _IngredientItemrepository = iIngredientItemProduct;
        }

        [HttpGet]

        public IngredientItemDto[] Get()
        {
            return _IngredientItemrepository.GetAllIngredientItems();
        }

        [HttpPost]
        public void Post([FromBody] IngredientItemDto value)
        {
            _IngredientItemrepository.Add(value);
        }
    }
}
