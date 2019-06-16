using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands;
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
        private readonly IAuthCommand auth;

        public AuthController(Encryption enc, IAuthCommand auth)
        {
            _enc = enc;
            this.auth = auth;
        }

        // POST: api/Auth
        [HttpPost]
        public ActionResult Post(AuthDTO dto)
        {
            var user = auth.Execute(dto);

            var stringObjekat = JsonConvert.SerializeObject(user);

            var encrypted = _enc.EncryptString(stringObjekat);

            return Ok(new { token = encrypted });
        }

        [HttpGet("decode")]
        public ActionResult Decode(string value)
        {
            var decodedString = _enc.DecryptString(value);
            decodedString = decodedString.Replace("\f", "");
            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }
    }
}
