using Microsoft.AspNetCore.Mvc;
using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Interfaces;


namespace Recipe_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _repositoryTag;

        public TagController(ITagRepository iRecipeTag)
        {
            _repositoryTag = iRecipeTag;
        }

        [HttpGet]

        public TagDto[] Get()
        {
            return _repositoryTag.GetAllTags();
        }
    }
}


