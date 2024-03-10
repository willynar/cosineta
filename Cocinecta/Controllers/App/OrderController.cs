using Entities.App;

namespace Cocinecta.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService IOrderService;

        public OrderController(IOrderService IOrderService)
        {
            this.IOrderService = IOrderService;
        }

        #region Order

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Order), 200)]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await IOrderService.GetOrderByIdAsync(id));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<OrderController>/Purchase/5
        [HttpGet("Purchase/{aplicationUserId}")]
        [ProducesResponseType(typeof(List<Order>), 200)]

        public async Task<IActionResult> GetPurchase([FromRoute] string aplicationUserId)
        {
            try
            {
                return Ok(await IOrderService.GetAllOrdersByAplicationUserPurchaseAsync(aplicationUserId));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<OrderController>/Seller/5
        [HttpGet("Seller/{aplicationUserId}")]
        [ProducesResponseType(typeof(List<Order>), 200)]

        public async Task<IActionResult> GetSeller([FromRoute] string aplicationUserId)
        {
            try
            {
                return Ok(await IOrderService.GetAllOrdersByApplicationUserSellerAsync(aplicationUserId));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] Order Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IOrderService.AddOrderAsync(Order);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Order Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IOrderService.UpdateOrderAsync(Order);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        #endregion
    }
}
