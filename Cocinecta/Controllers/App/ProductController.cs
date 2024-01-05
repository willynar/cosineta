using Entities.Administration;
using Entities.App;

namespace Cocinecta.Controllers.App
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService IProductService;

        public ProductController(IProductService iProductService)
        {
            IProductService = iProductService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await IProductService.GetAllProducts());
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await IProductService.GetProductById(id));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }


        // Post api/<ProductController>/Paginated/ProductId/1/ProductId/0
        /// <summary>
        /// get paginated products eye the filter and order are the properties in PascalCase
        /// </summary>
        /// <param name="objectParams"></param>
        /// <returns></returns>
        [HttpPost("Paginated")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<ProductStoreProcedure>), 200)]
        public async Task<IActionResult> GetFiltradoAsync([FromBody] ProductPaginatedParams objectParams)
        {
            try
            {
                return Ok(await IProductService.GetAllProductsFromPaginated(objectParams));

            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IProductService.AddProduct(product);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IProductService.UpdProductById(product);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await IProductService.DeleteProductById(id);
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
