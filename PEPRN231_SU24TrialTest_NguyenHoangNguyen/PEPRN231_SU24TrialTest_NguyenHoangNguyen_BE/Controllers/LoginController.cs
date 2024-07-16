using BPEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Controllers;
using BusinessObjects.Entities;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PEPRN231_SU24TrialTest_NguyenHoangNguyen_BE.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly ServiceBase<UserAccount> _userAccount;
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _userAccount = new ServiceBase<UserAccount>();
            _config = config;

        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            IActionResult response = Unauthorized();
            var user = _userAccount.GetAll()
                .Where(x => x.UserEmail == request.Email).FirstOrDefault();

            if (user != null && user.UserPassword == request.Password)
            {
                var tokenString = GenerateJWT(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }



        private string GenerateJWT(UserAccount userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              new Claim[]
              {
                  new(ClaimTypes.Email, userInfo.UserEmail),
                  new(ClaimTypes.Role, userInfo.Role.ToString()),
                  new("userId", userInfo.UserAccountId.ToString()),
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
