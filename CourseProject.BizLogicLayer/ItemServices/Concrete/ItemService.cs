using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.Repositories;
using CourseProject.DataLayer.Repositories.Item;
using StatusGeneric;

namespace CourseProject.BizLogicLayer.ItemServices
{
    public class ItemService : StatusGenericHandler, IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(
            IItemRepository repository
            )
        {
            _repository = repository;
        }

        public IQueryable<Item> GetAll()
        {
            return _repository.GetAll();
        }

        public Item GetById(int id)
        {
            var result = _repository.GetById(id);
            return result;
        }

        public void Create(ItemDlDto dto)
        {
            _repository.CreateItem(dto);
            if (IsValid)
                _repository.Save();
        }

        public void Update(ItemDlDto dto)
        {
            _repository.CreateItem(dto);
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
