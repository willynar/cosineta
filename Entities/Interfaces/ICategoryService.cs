namespace Entities.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// gets all list of Categories
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GetAllCategorys();

        /// <summary>
        /// get Category by id Category
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        Task<Category> GetCategoryById(int CategoryId);

        /// <summary>
        /// save new Category
        /// </summary>
        /// <param name="Category"></param>
        Task AddCategory(Category Category);

        /// <summary>
        /// update Category by id
        /// </summary>
        /// <param name="updatedCategory"></param>
        Task UpdCategoryById(Category updatedCategory);

        /// <summary>
        /// delete Category by id Category
        /// </summary>
        /// <param name="CategoryId"></param>
        Task DeleteCategoryById(int CategoryId);
    }
}
