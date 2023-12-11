using Entities.App;

namespace Logic.App
{
    public class LCategory : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public LCategory(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// gets all list of Categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetAllCategorys() =>
          await _context.Categories.ToListAsync();

        /// <summary>
        /// get Category by id Category
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryById(int CategoryId) =>
          await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == CategoryId);

        /// <summary>
        /// save new Category
        /// </summary>
        /// <param name="Category"></param>
        public async Task AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// update Category by id
        /// </summary>
        /// <param name="updatedCategory"></param>
        public async Task UpdCategoryById(Category updatedCategory)
        {
            var Category = _context.Categories.Find(updatedCategory.CategoryId);

            if (Category != null)
            {
                Category.Name = updatedCategory.Name;
                Category.Image = updatedCategory.Image;
                Category.Active = updatedCategory.Active;

                _context.Entry(Category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// delete Category by id Category
        /// </summary>
        /// <param name="CategoryId"></param>
        public async Task DeleteCategoryById(int CategoryId)
        {
            var Category = _context.Categories.Find(CategoryId);

            if (Category != null)
            {
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
