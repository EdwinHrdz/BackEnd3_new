using Microsoft.AspNetCore.Mvc;
using primeraAPI.DataBase;
using primeraAPI.Models;
using primeraAPI.Services;

namespace primeraAPI.Controllers
{
    public class AccessController : Controller
    {
        private readonly AccessDB _accessDB;
        public AccessController(AccessDB accessDB)
        {
            _accessDB = accessDB;
        }

        [HttpPost]
        [Route("login")]

        public LoginResponse login ([FromBody] LoginRequest loginRequest)
        {
            var response = _accessDB.Login(loginRequest);
            if (response.IsSuccess == 1)
            {
                return (response);
            }
            return (response);
        }


    }
}
