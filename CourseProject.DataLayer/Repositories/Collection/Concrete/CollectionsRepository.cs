using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.Repositories.Collection;

namespace CourseProject.DataLayer.Repositories
{
    public class CollectionsRepository : CommandContext<Collections>, ICollectionsRepository
    {
        private readonly EfCoreContext _context;
        public CollectionsRepository(EfCoreContext context)
        {
            _context = context;
        }

        public IQueryable<Collections> GetAll()
        {
            return _context.Collections.AsQueryable();
        }

        public void CreateCollection(CollectionsDlDto dto)
        {
            var result = new Collections
            {
                FullName = dto.FullName,
                Details = dto.Details,
                ImageUrl = dto.ImageUrl
            };
            _context.Collections.Add(result);
        }
    }
}
