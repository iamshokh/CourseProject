using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.Repositories.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataLayer.Repositories
{
    public class ItemRepository : CommandContext<CourseProject.DataLayer.EfClasses.Item>, IItemRepository
    {
        private readonly EfCoreContext _context;
        public ItemRepository(EfCoreContext context)
        {
            _context = context;
        }

        public IQueryable<CourseProject.DataLayer.EfClasses.Item> GetAll()
        {
            return _context.Items.AsQueryable();
        }

        public void CreateItem(ItemDlDto dto)
        {
            var result = new CourseProject.DataLayer.EfClasses.Item
            {
                FullName = dto.FullName,
                Details = dto.Details,
                ImageUrl = dto.ImageUrl
            };
            _context.Items.Add(result);
        }
    }
}
