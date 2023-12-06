namespace Cocinecta.Controllers.Administration
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly ILLoginService _lLogin;
        private readonly ILUserService _lUser;

        public LoginController(ILLoginService lLogin, ILUserService lUser)
        {
            _lLogin = lLogin;
            _lUser = lUser;
        }

        // GET: Login/Logout
        [HttpGet("Logout")]
        public async Task<IActionResult> SingOff()
        {
            try
            {
                await _lLogin.CloseSesion(User.GetUserId() ?? string.Empty);
                return Json(new { success = true, message = LErrors.TranslateError(ErrorType.Logout) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return Json(new { success = false, message = ErrorMsg });
            }
        }

        // POST: Login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel entity)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }

            try
            {
                var user = await _lUser.GetUserByUserOrEmail(entity.Email);
                if (user == null)
                {
                    return Json(new { success = false, message = LErrors.TranslateError(ErrorType.PassError) });
                }

                user.Password = entity.Password;
                user.Login = entity.Email;

                var result = await _lUser.ValidPassLogin(user);
                if (!result.Succeeded || !user.Active)
                {
                    return Json(new { success = false, message = LErrors.TranslateError(ErrorType.PassError) });
                }

                if (user.LockoutEnabled)
                {
                    return Json(new { success = false, message = LErrors.TranslateError(ErrorType.LockoutEnabled) });
                }

                return Ok(await _lLogin.BuildToken(user));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return Json(new { success = false, message = ErrorMsg });
            }
        }
    }
}
