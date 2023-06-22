using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.Repositories;
using CourseProject.DataLayer.Repositories.Collection;
using StatusGeneric;

namespace CourseProject.BizLogicLayer.CollectionServices
{
    public class CollectionsService : StatusGenericHandler, ICollectionsService
    {
        private readonly ICollectionsRepository _repository;

        public CollectionsService(
            ICollectionsRepository repository
            )
        {
            _repository = repository;
        }

        public IQueryable<Collections> GetAll()
        {
            return _repository.GetAll();
        }

        public Collections GetById(int id)
        {
            var result = _repository.GetById(id);
            return result;
        }

        public void Create(CollectionsDlDto dto)
        {
            _repository.CreateCollection(dto);
            if (IsValid)
                _repository.Save();
        }

        public void Update(CollectionsDlDto dto)
        {
            _repository.CreateCollection(dto);
            if (IsValid)
                _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            if (IsValid)
                _repository.Save();
        }
    }
}
