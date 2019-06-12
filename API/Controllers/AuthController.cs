using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Encryption _enc;

        public AuthController(Encryption enc)
        {
            _enc = enc;
        }

        // POST: api/Auth
        [HttpPost]
        public IActionResult Post()
        {
            //kako bi izgledao kod za logovanje?
            var user = new LoggedUser
            {
                FirstName = "Petar",
                LastName = "Peric",
                Id = 10,
                Role = "Admin",
                Username = "pera123"
            };

            var stringObjekat = JsonConvert.SerializeObject(user);

            var encrypted = _enc.EncryptString(stringObjekat);

            return Ok(new { token = encrypted });
        }

        [HttpGet("decode")]
        public IActionResult Decode(string value)
        {
            var decodedString = _enc.DecryptString(value);
            decodedString = decodedString.Replace("\f", "");
            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }
    }
}
