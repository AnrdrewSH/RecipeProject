using Recipe_Api.Data.Dto;

namespace Recipe_Api.Data.Interfaces
{
    public interface ITagRepository
    {
        TagDto[] GetAllTags();
    }
}
