namespace Entities.Interfaces
{
    public interface IChefService
    {
        /// <summary>
        /// gets all list of Chefs
        /// </summary>
        /// <returns></returns>
        Task<List<Chef>> GetAllChefs();

        /// <summary>
        /// get Chef by id Chef
        /// </summary>
        /// <param name="ChefId"></param>
        /// <returns></returns>
        Task<Chef> GetChefById(int ChefId);

        /// <summary>
        /// save new Chef
        /// </summary>
        /// <param name="Chef"></param>
        Task AddChef(Chef Chef);

        /// <summary>
        /// update Chef by id
        /// </summary>
        /// <param name="updatedChef"></param>
        Task UpdChefById(Chef updatedChef);

        /// <summary>
        /// delete Chef by id Chef
        /// </summary>
        /// <param name="ChefId"></param>
        Task DeleteChefById(int ChefId);
    }
}
