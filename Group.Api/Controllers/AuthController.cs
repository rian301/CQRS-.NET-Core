using Adm.Infra.CrossCutting.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using NetDevPack.Identity.Model;
using System.Threading.Tasks;

namespace Adm.Api.Controllers
{
    [Route("api/account")]
    public class AuthController : MainController
    {
        #region Intection
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppJwtSettings _appJwtSettings;
        #endregion

        #region Constructor
        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, IOptions<AppJwtSettings> appJwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appJwtSettings = appJwtSettings.Value;
        }
        #endregion

        #region Methods
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new User
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = false,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return CustomResponse(GetUserResponse(user.Email));
            }

            foreach (var error in result.Errors)
            {
                AddError(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                var userResponse = GetUserResponse(loginUser.Email);
                return CustomResponse(userResponse);
            }

            if (result.IsLockedOut)
            {
                AddError("Usuário bloqueado!");
                return CustomResponse();
            }

            AddError("Usuário ou senha incorreto.");
            return CustomResponse();
        }

        private UserResponse<int> GetUserResponse(string email)
        {
            return new JwtBuilder<User, int>()
                .WithUserManager(_userManager)
                .WithJwtSettings(_appJwtSettings)
                .WithEmail(email)
                .WithJwtClaims()
                .WithUserClaims()
                .WithUserRoles()
                .BuildUserResponse();
        }
        #endregion
    }
}
