using Assingment1.Models;

namespace Assingment1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}

