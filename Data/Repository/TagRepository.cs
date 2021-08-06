using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Entities;
using Recipe_Api.Data.Interfaces;
using System.Linq;

namespace Recipe_Api.Data.Repository
{
    public class TagRepository : ITagRepository
    {
        private AppDbContext _context;
        public TagRepository(AppDbContext tagcontext)
        {
            _context = tagcontext;
        }
        public TagDto[] GetAllTags()
        {
            return _context.Set<Tag>().ToList()
                .ConvertAll(x => new TagDto { Id = x.Id, Name = x.Name })
                .ToArray();
        }
    }
}
