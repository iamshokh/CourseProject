using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.Repositories.Collection;

namespace CourseProject.DataLayer.Repositories
{
    public interface ICollectionsRepository : ICommandContext<Collections>
    {
        IQueryable<Collections> GetAll();
        void CreateCollection(CollectionsDlDto dto);
    }
}
