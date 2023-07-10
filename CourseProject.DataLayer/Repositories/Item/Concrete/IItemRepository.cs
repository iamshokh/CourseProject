using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.Repositories.Item;

namespace CourseProject.DataLayer.Repositories
{
    public interface IItemRepository : ICommandContext<CourseProject.DataLayer.EfClasses.Item>
    {
        IQueryable<CourseProject.DataLayer.EfClasses.Item> GetAll();
        void CreateItem(ItemDlDto dto);
    }
}
