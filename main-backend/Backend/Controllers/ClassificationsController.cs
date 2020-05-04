using Backend.Common;
using Backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClassificationsController : ControllerBase
    {
        private readonly FireContext context;

        public ClassificationsController(FireContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all Classifications
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /Classifications
        /// </remarks>
        /// <returns>All Classification</returns>
        /// <response code="200">Returns all classifications</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Classification>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Classification>>> GetClassification()
        {
            try
            {
                return Ok(await context.Classification.ToListAsync());
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a specific Classification
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /Classifications/5
        /// </remarks>
        /// <param name="id">Classification ID</param>
        /// <returns>Specific Classification</returns>
        /// <response code="200">Returns specific Classification</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Classification), StatusCodes.Status200OK)]
        public async Task<ActionResult<Classification>> GetClassification(int id)
        {
            Classification classification;

            try
            {
                classification = await context.Classification.FindAsync(id);
            }
            catch (SqlException)
            {
                throw;
            }

            if (classification == null)
            {
                return NotFound(ResponseMessage.GetMessage(message: $"No Classification found!", statusCode: StatusCodes.Status404NotFound));
            }

            return Ok(classification);
        }

        /// <summary>
        /// Updates a specific Classification
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     PUT /Classifications/5
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <param name="id">Classification ID</param>
        /// <param name="classification">Classification values</param>
        /// <response code="204">No content, the classification was updated successfully</response>
        /// <response code="404">If the given classification doesn' excist.</response>
        /// <response code="400">If the given classification ID is invalid.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutClassification(int id, Classification classification)
        {
            if (id != classification.ClassificationId)
            {
                return BadRequest(ResponseMessage.GetMessage(message: $"Invalid Classification IDs!", statusCode: StatusCodes.Status400BadRequest));
            }

            context.Entry(classification).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassificationExists(id))
                {
                    return NotFound(ResponseMessage.GetMessage(message: $"No classification found!", statusCode: StatusCodes.Status404NotFound));
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a new Classification
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     Post /Classifications/Add
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <returns>Newly created Classification</returns>
        /// <response code="201">Returns the newly created Classification</response>
        /// <response code="409">If a parameter Conflict occurrs</response>
        [HttpPost]
        [ProducesResponseType(typeof(Classification), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Classification>> PostClassification(Classification classification)
        {
            if (classification.ClassificationId != null)
                return Conflict(ResponseMessage.GetMessage(message: $"Illegal parameter {nameof(Classification.ClassificationId)}! Parameter is set automaticly by Database!", statusCode: StatusCodes.Status409Conflict));
            if (string.IsNullOrWhiteSpace(classification.ClassificationArt))
                return Conflict(ResponseMessage.GetMessage(message: $"Illegal parameter {nameof(Classification.ClassificationArt)}! Parameter is emty or Null!", statusCode: StatusCodes.Status409Conflict));
            if (string.IsNullOrWhiteSpace(classification.ClassificationType))
                return Conflict(ResponseMessage.GetMessage(message: $"Illegal parameter {nameof(Classification.ClassificationType)}! Parameter is emty or Null!", statusCode: StatusCodes.Status409Conflict));


            context.Classification.Add(classification);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClassificationExists((int)classification.ClassificationId))
                {
                    return Conflict(ResponseMessage.GetMessage(message: $"Classification already exists!", statusCode: StatusCodes.Status409Conflict));
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClassification", new { id = classification.ClassificationId }, classification);
        }

        /// <summary>
        /// Deletes a specific Classification
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     DELETE /Classifications/5
        /// </remarks>
        /// <param name="id">Classification ID</param>
        /// <response code="200">Classification, which was deleted successfully</response>
        /// <response code="404">If the Classification was not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Classification>> DeleteClassification(int id)
        {
            var classification = await context.Classification.FindAsync(id);
            if (classification == null)
            {
                return NotFound(ResponseMessage.GetMessage(message: $"Classification not found!", statusCode: StatusCodes.Status404NotFound));
            }

            context.Classification.Remove(classification);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok($"Deleted Classification {classification.ClassificationArt} (ID: {classification.ClassificationId}) successfull");
        }

        private bool ClassificationExists(int id)
        {
            return context.Classification.Any(e => e.ClassificationId == id);
        }
    }
}
