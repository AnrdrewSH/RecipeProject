using Recipe_Api.Data.Dto;

namespace Recipe_Api.Data.Interfaces
{
    public interface IStepRepository
    {
        StepDto[] GetAllSteps();
        int Add(StepDto stepDto);

    }
}
