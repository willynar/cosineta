using Entities.Administration;
using Entities.App;

namespace Cocinecta.Controllers.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureController : ControllerBase
    {
        private readonly IProductFeatureService IProductFeatureService;

        public ProductFeatureController(IProductFeatureService iProductFeatureService)
        {
            IProductFeatureService = iProductFeatureService ?? throw new ArgumentNullException(nameof(iProductFeatureService));
        }
        #region ProductFeacture

      
        // GET: api/<ProductFeatureController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductFeature>), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await IProductFeatureService.GetAllProductFeaturesAsync());
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<ProductFeatureController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductFeature), 200)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await IProductFeatureService.GetProductFeatureByIdAsync(id));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<ProductFeatureController>/Additional/User/5
        [HttpGet("Additional/User/{applicationUserId}")]
        [ProducesResponseType(typeof(ProductFeature), 200)]
        public async Task<IActionResult> GetAdditionalUser([FromRoute] string applicationUserId)
        {
            try
            {
                return Ok(await IProductFeatureService.GetAllAdditionalProductFeaturesByUserAsync(applicationUserId));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }


        // POST api/<ProductFeatureController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductFeature product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IProductFeatureService.AddProductFeatureAsync(product);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // PUT api/<ProductFeatureController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductFeature product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IProductFeatureService.UpdateProductFeatureAsync(product);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // DELETE api/<ProductFeatureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await IProductFeatureService.DeleteProductFeatureAsync(id);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Logout) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        #endregion
        #region Detail ProductFeature product

        // GET: api/<ProductFeatureController>/ProductFeature/ProductId/5
        [HttpGet("ProductFeatureDetail/ProductId/{productId}")]
        [ProducesResponseType(typeof(List<ProductFeaturesDetail>), 200)]
        public async Task<IActionResult> GetProductFeatureDetailsByProductId([FromRoute] int productId)
        {
            try
            {
                return Ok(await IProductFeatureService.GetAllProductFeaturesDetailsByProductIdAsync(productId));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // GET api/<ProductFeatureController>/ProductFeature/5
        [HttpGet("ProductFeatureDetail/{id}")]
        [ProducesResponseType(typeof(ProductFeaturesDetail), 200)]
        public async Task<IActionResult> GetProductFeatureDetail([FromRoute] int id)
        {
            try
            {
                return Ok(await IProductFeatureService.GetProductFeaturesDetailByIdAsync(id));
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST api/<ProductFeatureController>/ProductFeature
        [HttpPost("ProductFeatureDetail")]
        public async Task<IActionResult> PostProductFeatureDetail([FromBody] ProductFeaturesDetail ProductFeaturesDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IProductFeatureService.AddProductFeaturesDetailAsync(ProductFeaturesDetail);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // POST api/<ProductFeatureController>/ProductFeatureCategoryDetail
        [HttpPost("ProductFeatureCategoryDetail")]
        public async Task<IActionResult> PostProductFeaturesCategoryDetail([FromBody] ProductCategoryFeactureModel ProductFeaturesDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IProductFeatureService.AddProductFeaturesCategoryAsync(ProductFeaturesDetail);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Saved) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // PUT api/<ProductFeatureController>/ProductFeature/5
        [HttpPut("ProductFeatureDetail")]
        public async Task<IActionResult> PutProductFeatureDetail([FromBody] ProductFeaturesDetail ProductFeaturesDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = ErrorModelValidation.ShowError(new SerializableError(ModelState).Values) });
            }
            try
            {
                await IProductFeatureService.UpdateProductFeaturesDetailAsync(ProductFeaturesDetail);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Updated) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // DELETE api/<ProductFeatureController>/ProductFeature/5
        [HttpDelete("ProductFeatureDetail/{id}")]
        public async Task<IActionResult> DeleteProductFeatureDetail(int id)
        {
            try
            {
                await IProductFeatureService.DeleteProductFeaturesDetailAsync(id);
                return Ok(new { success = true, message = LErrors.TranslateError(ErrorType.Logout) });
            }
            catch (Exception exc)
            {
                var ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException?.Message : exc.GetBaseException().Message ?? string.Empty;
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ErrorMsg });
            }
        }

        // DELETE api/<ProductFeatureController>/ProductFeature/5
        [HttpDelete("ProductFeatureDetail/ProductId/{productId}")]
        public async Task<IActionResult> DeleteProductFeatureDetailByProductId(int productId)
        {
            try
            {
                await IProductFeatureService.DeleteAllProductFeaturesDetailsByProductIdAsync(productId);
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
