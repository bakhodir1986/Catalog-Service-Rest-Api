using Catalog_Service_BLL;

namespace Catalog_Service_DAL
{
    public class ItemRepository : IItemRepository
    {
        public void Add(Item item)
        {
            using (var context = new CatalogDbContext())
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(Item item)
        {
            using (var context = new CatalogDbContext())
            {
                context.Items.Remove(item);
                context.SaveChanges();
            }
        }

        public IEnumerable<Item> GetAllItemsByCategory(Guid categoryId)
        {
            using (var context = new CatalogDbContext())
            {
                return context.Items.Where(x => x.Category.Id == categoryId);
            }
        }

        public void Update(Item item)
        {
            using (var context = new CatalogDbContext())
            {
                context.Items.Update(item);
                context.SaveChanges();
            }
        }
    }
}
