﻿using Entities.Administration;

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

        // POST: api/<UserController>
        [HttpPost]
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
