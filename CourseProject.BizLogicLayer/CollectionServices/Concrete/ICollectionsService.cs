using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.Repositories.Collection;
using StatusGeneric;

namespace CourseProject.BizLogicLayer.CollectionServices
{
    public interface ICollectionsService : IStatusGeneric
    {
        IQueryable<Collections> GetAll();
        Collections GetById(int id);
        void Create(CollectionsDlDto dto);
        void Update(CollectionsDlDto dto);
        void Delete(int id);
    }
}
