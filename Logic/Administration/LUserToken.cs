namespace Logic.Administration
{
    public class LUserToken : ILUserTokenService
    {
        private readonly ApplicationDbContext _context;

        public LUserToken(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserToken?> GetById(string userId) =>
            await _context.UserToken.FirstOrDefaultAsync(x => x.UserId == userId);

        public async Task Save(UserToken entity)
        {
            await _context.UserToken.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(UserToken entity)
        {
            _context.UserToken.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
