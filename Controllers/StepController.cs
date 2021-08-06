using Microsoft.AspNetCore.Mvc;
using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Interfaces;


namespace Recipe_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {

        private readonly IStepRepository _repositoryStep;

        public StepController(IStepRepository iRecipeStep)
        {
            _repositoryStep = iRecipeStep;
        }

        [HttpGet]

        public StepDto[] Get()
        {
            return _repositoryStep.GetAllSteps();
        }

        [HttpPost]
        public void Post([FromBody] StepDto value)
        {
            _repositoryStep.Add(value);
        }
    }
}
