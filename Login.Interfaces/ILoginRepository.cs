using Login.Models.Entities;
using System.Threading.Tasks;

namespace Login.Interfaces
{
    public interface ILoginRepository
    {
        UserAuth UserAuthenticate(string userName, string password, string hno, string requesttype, string fullnameinputfromtc);

        Task<UserAuth> UserAuthenticateAsync(string userName, string password, string hno, string requesttype, string fullnameinputfromtc);
    }
}
