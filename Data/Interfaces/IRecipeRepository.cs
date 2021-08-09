using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Api.Data.Interfaces
{
    public interface IRecipeRepository
    {
        void Add(Recipe recipe);

    }
}
