using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IEP.BusinessLogic.Contracts;
using IEP.BusinessLogic.Entities;
using IEP.Services.Contracts;

namespace IEP.Services.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        private static string GetHash(HashAlgorithm md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.

            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public async Task<bool> Authorize(User user)
        {
            using (var hashAlgorithm = MD5.Create())
            {
                var passwordHash = GetHash(hashAlgorithm, user.Password);
                return await _userRepository.GetAll(x => x.Login == user.Login && x.Password == passwordHash).AnyAsync();
            }
        }

        public void Create(User user)
        {
            using (var hashAlgorithm = MD5.Create())
            {
                user.Password = GetHash(hashAlgorithm, user.Password);
            }
            _userRepository.Add(user);
        }
    }
}
