using Entities.Administration;
using Entities.Interfaces;

namespace Cocinecta.Controllers.Administration
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILUserService _lUser;

        public UserController(ILUserService lUser)
        {
            _lUser = lUser ?? throw new ArgumentNullException(nameof(lUser));
        }


        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ApplicationUser>), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _lUser.GetAll());
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET: api/<UserController>
        [HttpGet("Id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                return Ok(await _lUser.GetById(id));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET: api/<UserController>/Role
        [HttpGet("Role")]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                return Ok(await _lUser.GetAllRole());
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET: api/User/Modules/{userId}
        [HttpGet("Modules/{userId}")]
        public async Task<IActionResult> GetModulesByUserId(string id)
        {
            try
            {
                var modules = await _lUser.GetModulesByUserId(id);
                return Ok(modules);
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // GET: api/User/Rols/{userId}
        [HttpGet("Rols/{userId}")]
        public async Task<IActionResult> GetRolsByUserId(string userId)
        {
            try
            {
                var roles = await _lUser.GetRolsByUserId(userId);
                return Ok(roles);
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // GET: api/<UserController>/Roles
        [HttpGet("Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                return Ok(await _lUser.GetAllRoles());
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException?.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // GET: api/<UserController>/Links
        [HttpGet("Links")]
        public async Task<IActionResult> GetAllLinks()
        {
            try
            {
                return Ok(await _lUser.GetAllLinks());
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException?.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // GET: api/<UserController>/RolLinks
        [HttpGet("RolLinks")]
        public async Task<IActionResult> GetAllRolLinks()
        {
            try
            {
                return Ok(await _lUser.GetAllRolLinks());
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException?.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // GET: api/<UserController>/Modules
        [HttpGet("Modules")]
        public async Task<IActionResult> GetAllModules()
        {
            try
            {
                return Ok(await _lUser.GetAllModules());
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException?.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // GET: api/<UserController>/UsersRoles
        [HttpGet("UsersRoles")]
        public async Task<IActionResult> GetAllUsersRoles()
        {
            try
            {
                return Ok(await _lUser.GetAllUsersRoles());
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException?.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }

            try
            {
                var result = await _lUser.Save(user);
                if (result.Succeeded)
                {
                    await _lUser.AssignRoleAsync(user.Id, user.UsersRoles.ToList());
                    return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
                }
                else
                {
                    return BadRequest(new { success = false, message = result.Errors });
                }

            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST: api/<UserController>/Role
        [HttpPost("Role")]
        public async Task<IActionResult> PostRole([FromBody] ApplicationRole role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }

            try
            {
                var result = await _lUser.SaveRole(role);
                if (result.Succeeded)
                {
                    return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
                }
                else
                {
                    return BadRequest(new { success = false, message = result.Errors });
                }

            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST: api/User/SaveModule
        [HttpPost("Module")]
        public async Task<IActionResult> SaveModule([FromBody] Module module)
        {
            try
            {
                await _lUser.SaveModule(module);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/User/SaveUserRole
        [HttpPost("UserRole")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveUserRole([FromBody] UserRole userRole)
        {
            try
            {
                await _lUser.SaveUserRole(userRole);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/User/SaveRolLink
        [HttpPost("RolLink")]
        public async Task<IActionResult> SaveRolLink([FromBody] RolLink rolLink)
        {
            try
            {
                await _lUser.SaveRolLink(rolLink);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/User/SaveLink
        [HttpPost("Link")]
        public async Task<IActionResult> SaveLink([FromBody] Link link)
        {
            try
            {
                await _lUser.SaveLink(link);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/User/SaveApplicationRole
        [HttpPost("ApplicationRole")]
        public async Task<IActionResult> SaveApplicationRole([FromBody] ApplicationRole role)
        {
            try
            {
                await _lUser.SaveApplicationRole(role);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)

            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }



        // POST: api/User/SaveModule
        [HttpPut("Module")]
        public async Task<IActionResult> UpdModule([FromBody] Module module)
        {
            try
            {
                await _lUser.SaveModule(module);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/User/SaveUserRole
        [HttpPut("UserRole")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdUserRole([FromBody] UserRole userRole)
        {
            try
            {
                await _lUser.SaveUserRole(userRole);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/User/SaveRolLink
        [HttpPut("RolLink")]
        public async Task<IActionResult> UpdRolLink([FromBody] RolLink rolLink)
        {
            try
            {
                await _lUser.SaveRolLink(rolLink);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/User/SaveLink
        [HttpPut("Link")]
        public async Task<IActionResult> UpdLink([FromBody] Link link)
        {
            try
            {
                await _lUser.SaveLink(link);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }

        // POST: api/User/SaveApplicationRole
        [HttpPut("ApplicationRole")]
        public async Task<IActionResult> UpdApplicationRole([FromBody] ApplicationRole role)
        {
            try
            {
                await _lUser.SaveApplicationRole(role);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)

            {
                var errorMsg = exc.GetBaseException().InnerException != null
                    ? exc.GetBaseException().InnerException.Message
                    : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = errorMsg });
            }
        }
        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await _lUser.Edit(user);

                await _lUser.AssignRoleAsync(user.Id, user.UsersRoles.ToList());
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });

            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }


        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await _lUser.DeleteUserById(id);
        //        return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Logout) });
        //    }
        //    catch (Exception exc)
        //    {
        //        var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
        //    }
        //}
    }
}
