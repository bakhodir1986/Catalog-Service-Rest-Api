using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Service_BLL
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IItemRepository itemRepository;

        public CategoryService(ICategoryRepository categoryRepository, 
            IItemRepository itemRepository)
        {
            this.categoryRepository = categoryRepository;
            this.itemRepository = itemRepository;
        }

        /*
            List of categories
            List of Items (filtration by category id and pagination)
            Add category
            Add item
            Update category
            Update item
            Delete Item
            Delete category (with the related items)
        */

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }

        public IEnumerable<Item> GetItems(Guid categoryId)
        {
            if (categoryId == Guid.Empty) throw new ArgumentNullException("categoryId");
            return itemRepository.GetAllItemsByCategory(categoryId);
        }

        public void AddCategory(string name, Guid parentId)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            
            Category category = new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Parent = categoryRepository.Get(parentId)
            };

            categoryRepository.Add(category);
        }

        public void AddItem(Guid categotyId, Item item)
        {
            item.Id = Guid.NewGuid();
            item.Category = categoryRepository.Get(categotyId);

            itemRepository.Add(item);
        }

        public void UpdateCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException("category");
            var selectedCategory = categoryRepository.Get(category.Id);
            selectedCategory.Name = category.Name;
            selectedCategory.Parent = category.Parent;

            categoryRepository.Update(selectedCategory);
        }
    }
}
