using CourseProject.DataLayer.EfClasses;
using CourseProject.DataLayer.Repositories.Item;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BizLogicLayer.ItemServices
{
    public interface IItemService : IStatusGeneric
    {
        IQueryable<Item> GetAll();
        Item GetById(int id);
        void Create(ItemDlDto dto);
        void Update(ItemDlDto dto);
        void Delete(int id);
    }
}
