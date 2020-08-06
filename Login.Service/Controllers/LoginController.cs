using Login.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Login.Service.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<IActionResult> UserAuthenticate(string userName, string password, string hno, string requesttype, string fullnameinputfromtc)
        {
            if (string.IsNullOrEmpty(userName))     // TODO: brest{
            {
                return BadRequest("The login parameters are not valid");
            }

            return Ok(await _loginRepository.UserAuthenticateAsync(userName, password, hno, requesttype, fullnameinputfromtc));

        }
    }
}