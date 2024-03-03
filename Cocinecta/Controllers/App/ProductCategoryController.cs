using Entities.App;

namespace Cocinecta.Controllers.App
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ICategoryService ICategoryService;

        public ProductCategoryController(ICategoryService iCategoryService)
        {
            ICategoryService = iCategoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        [ProducesResponseType(typeof(List<Category>), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await ICategoryService.GetAllCategoriesAsync());
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Category), 200)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await ICategoryService.GetCategoryByIdAsync(id));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await ICategoryService.AddCategoryAsync(product);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Category product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await ICategoryService.UpdateCategoryAsync(product);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await ICategoryService.DeleteCategoryAsync(id);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Logout) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }


        #region Detail category product

        // GET: api/<CategoryController>/ProductCategory/ProductId/5
        [HttpGet("ProductCategoryDetail/ProductId/{productId}")]
        [ProducesResponseType(typeof(List<ProductCategory>), 200)]
        public async Task<IActionResult> GetProductCategoryByProductId([FromRoute] int productId)
        {
            try
            {
                return Ok(await ICategoryService.GetAllProductCategoriesByProductIdAsync(productId));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<CategoryController>/ProductCategory/5
        [HttpGet("ProductCategoryDetail/{id}")]
        [ProducesResponseType(typeof(ProductCategory), 200)]
        public async Task<IActionResult> GetProductCategory([FromRoute] int id)
        {
            try
            {
                return Ok(await ICategoryService.GetProductCategoryByIdAsync(id));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST api/<CategoryController>/ProductCategory
        [HttpPost("ProductCategoryDetail")]
        public async Task<IActionResult> PostProductCategory([FromBody] ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await ICategoryService.AddProductCategoryAsync(productCategory);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // PUT api/<CategoryController>/ProductCategory/5
        [HttpPut("ProductCategoryDetail")]
        public async Task<IActionResult> PutProductCategory([FromBody] ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await ICategoryService.UpdateProductCategoryAsync(productCategory);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // DELETE api/<CategoryController>/ProductCategory/5
        [HttpDelete("ProductCategoryDetail/{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            try
            {
                await ICategoryService.DeleteProductCategoryAsync(id);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Logout) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // DELETE api/<CategoryController>/ProductCategory/5
        [HttpDelete("ProductCategoryDetail/ProductId/{productId}")]
        public async Task<IActionResult> DeleteProductCategoryByProductId(int productId)
        {
            try
            {
                await ICategoryService.DeleteProductCategoryByProductIdAsync(productId);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Logout) });
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
