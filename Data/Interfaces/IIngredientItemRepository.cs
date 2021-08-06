using Recipe_Api.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Api.Data.Interfaces
{
    public interface IIngredientItemRepository
    {
        IngredientItemDto[] GetAllIngredientItems();
        int Add(IngredientItemDto IngredientItemDto);
    }
}
