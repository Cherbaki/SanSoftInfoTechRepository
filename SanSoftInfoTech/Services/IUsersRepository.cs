using SanSoftInfoTech.Models;

namespace SanSoftInfoTech.Services
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetUsersByName(string userName);
        public Task AddUserAsync(User newUser);
        public Task<User?> GetUserAsync(string userName, string password);
        public Task<User?> GetUserIdAsync(int Id);

	}
}
