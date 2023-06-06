using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Microsoft.Data.SqlClient;
using DataEntities.Entities;
using Microsoft.AspNetCore.Http;
using Models;
using System.Data.Common;

namespace ProductManagement.Controllers
{

    [Route("api/controller")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryLogic _categoryLogic;
       public CategoryController(ICategoryLogic categoryLogic) 
        {
            _categoryLogic = categoryLogic;
        }

        [HttpGet("getallCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {

                var cs = _categoryLogic.GetAllCategories();
                if (cs != null)
                {
                    return Ok(cs);
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
        [HttpGet("GetCategoriesByCategoryId")]
        public ActionResult GetCategoriesByCategoryId([FromHeader] int  CategoryId)
        {
            try
            {

                var ps = _categoryLogic.GetCategoryByCategoryId(CategoryId);
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

        [HttpPost("AddCategory")] // Trying to create a resource on the server
        public ActionResult AddCategory([FromBody] Models.Category a)
        {
            try
            {
                

                var result = _categoryLogic.AddCategory(a);
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
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory([FromHeader]int CategoryId, [FromBody] Models.Category c)
        {
            try
            {

                var result = _categoryLogic.UpdateCategory( CategoryId, c);
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
        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory([FromHeader]int CategoryId)
        {
            try
            {

                var result = _categoryLogic.DeleteCategory(CategoryId);
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

    }
}
