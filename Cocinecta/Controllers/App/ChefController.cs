using Entities.App;

namespace Cocinecta.Controllers.App
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly IChefService IChefService;

        public ChefController(IChefService iChefService)
        {
            IChefService = iChefService;
        }

        // GET: api/<ChefController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await IChefService.GetAllChefs());
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<ChefController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await IChefService.GetChefById(id));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST api/<ChefController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Chef product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IChefService.AddChef(product);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // PUT api/<ChefController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Chef product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IChefService.UpdChefById(product);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // DELETE api/<ChefController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await IChefService.DeleteChefById(id);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Logout) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }
    }
}
