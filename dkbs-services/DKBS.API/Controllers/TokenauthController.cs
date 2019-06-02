//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DKBS.API.Controllers
//{
//    public class TokenauthController
//    {
//    }
//}


using DKBS.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.API.Controllers
{
    //public class LoginController
    //{
    //}

    /// <summary>
    /// Creating TokenauthController
    /// </summary>
    public class TokenauthController : ControllerBase
    {
        private IConfiguration _config;
        /// <summary>
        /// Creating TokenauthController
        /// </summary>
        public TokenauthController(IConfiguration config)
        {
            _config = config;
        }


         /// <summary>
        /// Creating TokenauthController
        /// </summary>

        [HttpGet("[action]")]
        [Route("api/TokenAuth/GenerateJSONWebTokenauth")]      
        public IActionResult GenerateJSONWebTokenauth(PartnerDTO userInfo)
        {
            IActionResult response = Unauthorized();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var AppIDKey = _config["Jwt:APPID"];
            var ClientSecretKey= _config["Jwt:CLIENTSECRET"];
          
            var claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Sub, "DKBS"),
                new Claim("APPID", AppIDKey.ToString()),
                new Claim("ClientSecret", ClientSecretKey.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);


            var tokenString = token;
            response = Ok(new { token = tokenString });
            return response;
        }



    }
}

