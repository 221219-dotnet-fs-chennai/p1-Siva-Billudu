using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Microsoft.Data.SqlClient;

namespace ProductManagement.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductLogic _pLogic;

        public ProductController(IProductLogic pLogic)
        {
            _pLogic = pLogic;
        }
        [HttpGet("getproducts")]
        public IActionResult GetProducts()
        {
            try
            {

                var ps = _pLogic.GetProducts();
                if (ps != null)
                {
                    return Ok(ps);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddProduct")] 
        public ActionResult AddProduct([FromBody] Models.Product a)
        {
            try
            {
               

                var result = _pLogic.AddProduct(a);
                return Ok(result);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromHeader] Guid PId, [FromBody] Models.Product p)
        {
            try
            {

                var result = _pLogic.UpdateProduct(PId,p);
                return Ok(result);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct([FromHeader]Guid PId)
        {
            try
            {

                var result = _pLogic.DeleteProduct(PId);
                return Ok(result);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("getproductsbyproductId")]
        public ActionResult GetProductsByProductId([FromHeader] Guid PId)
        {
            try
            {

                var ps = _pLogic.GetProductById(PId);
                if (ps != null)
                {
                    return Ok(ps);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductsByCategoryId")]
        public IActionResult GetByCategoryName([FromHeader] int CategoryId)
        {
            try
            {

                var ps = _pLogic.GetProductdByCategoryId(CategoryId);
                if (ps != null)
                {
                    return Ok(ps);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
