using Microsoft.EntityFrameworkCore;
using SanSoftInfoTech.Data;
using SanSoftInfoTech.Models;
using SanSoftInfoTech.Services;

namespace SanSoftInfoTech.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _dbContext;


        public UsersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddUserAsync(User newUser)
        {
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }
        public IEnumerable<User> GetUsersByName(string userName)
        {
            var targetUser = _dbContext.Users.Where(us => us.UserName == userName).ToList();
            return targetUser;
        }
        public async Task<User?> GetUserAsync(string userName,string password)
        {
            var targetUser = await _dbContext.Users
                                    .FirstOrDefaultAsync(us => us.UserName == userName && us.Password == password);

            return targetUser;
        }
		public async Task<User?> GetUserIdAsync(int Id)
		{
			var targetUser = await _dbContext.Users
									.FirstOrDefaultAsync(us => us.UserId == Id);

			return targetUser;
		}

	}
}
