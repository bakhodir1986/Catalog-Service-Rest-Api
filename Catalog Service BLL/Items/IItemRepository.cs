using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Service_BLL
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItemsByCategory(Guid categoryId);
        Item GetById(Guid id);
        void Add(Item item);
        void Update(Item item);
        void Delete(Item item);
    }
}
