using Entities.App;

namespace Logic.App
{
    public class LChefs : IChefService
    {
        private readonly ApplicationDbContext _context;

        public LChefs(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// gets all list of Chefs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Chef>> GetAllChefs() =>
          await _context.Chefs.ToListAsync();

        /// <summary>
        /// get Chef by id Chef
        /// </summary>
        /// <param name="ChefId"></param>
        /// <returns></returns>
        public async Task<Chef> GetChefById(int ChefId) =>
          await _context.Chefs.FirstOrDefaultAsync(p => p.ChefId == ChefId);

        /// <summary>
        /// save new Chef
        /// </summary>
        /// <param name="Chef"></param>
        public async Task AddChef(Chef Chef)
        {
            _context.Chefs.Add(Chef);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// update Chef by id
        /// </summary>
        /// <param name="updatedChef"></param>
        public async Task UpdChefById(Chef updatedChef)
        {
            var Chef = _context.Chefs.Find(updatedChef.ChefId);

            if (Chef != null)
            {
                Chef.Name = updatedChef.Name;
                Chef.Phone = updatedChef.Phone;
                Chef.Cellphone = updatedChef.Cellphone;
                Chef.Email = updatedChef.Email;
                Chef.Image = updatedChef.Image;
                Chef.Cover = updatedChef.Cover;
                Chef.Gender = updatedChef.Gender;
                Chef.Nationality = updatedChef.Nationality;
                Chef.Country = updatedChef.Country;
                Chef.Department = updatedChef.Department;
                Chef.Status = updatedChef.Status;
                Chef.Certified = updatedChef.Certified;
                Chef.CertifiedMessage = updatedChef.CertifiedMessage;
                Chef.Description = updatedChef.Description;
                Chef.Active = updatedChef.Active;

                _context.Entry(Chef).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// delete Chef by id Chef
        /// </summary>
        /// <param name="ChefId"></param>
        public async Task DeleteChefById(int ChefId)
        {
            var Chef = _context.Chefs.Find(ChefId);

            if (Chef != null)
            {
                _context.Chefs.Remove(Chef);
                await _context.SaveChangesAsync();
            }
        }
    }
}
