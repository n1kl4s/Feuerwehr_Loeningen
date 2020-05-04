using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Backend.Entities;
using Backend.Common;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CrewsController : ControllerBase
    {
        private readonly FireContext context;

        public CrewsController(FireContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all Crews
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /Crews
        /// </remarks>
        /// <returns>All Crews</returns>
        /// <response code="200">Returns all crew</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Crew>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Crew>>> GetCrew()
        {
            try
            {
                return Ok(await context.Crew.ToListAsync());
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a specific Crew
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /Crews/5
        /// </remarks>
        /// <param name="id">Crew ID</param>
        /// <returns>Specific Crew</returns>
        /// <response code="200">Returns specific Crew</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Crew), StatusCodes.Status200OK)]
        public async Task<ActionResult<Crew>> GetCrew(int id)
        {
            Crew crew;

            try
            {
                crew = await context.Crew.FindAsync(id);
            }
            catch (SqlException)
            {
                throw;
            }

            if (crew == null)
            {
                return NotFound(ResponseMessage.GetMessage(message: $"No Crew found!", statusCode: StatusCodes.Status404NotFound));
            }

            return Ok(crew);
        }

        /// <summary>
        /// Updates a specific Crew
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     PUT /Crews/5
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <param name="id">Crew ID</param>
        /// <param name="classification">Crew values</param>
        /// <response code="204">No content, the crew was updated successfully</response>
        /// <response code="404">If the given crew doesn' excist.</response>
        /// <response code="400">If the given crew ID is invalid.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutCrew(int id, Crew crew)
        {
            if (id != crew.CrewId)
            {
                return BadRequest(ResponseMessage.GetMessage(message: $"Invalid Crew IDs!", statusCode: StatusCodes.Status400BadRequest));
            }

            context.Entry(crew).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrewExists(id))
                {
                    return NotFound(ResponseMessage.GetMessage(message: $"No Crew found!", statusCode: StatusCodes.Status404NotFound));
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a new Crew
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     Post /Crews/Add
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <returns>Newly created Crew</returns>
        /// <response code="201">Returns the newly created Crew</response>
        /// <response code="409">If a parameter Conflict occurrs</response>
        [HttpPost]
        [ProducesResponseType(typeof(Crew), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Crew>> PostCrew(Crew crew)
        {
            if (crew.CrewId != null)
                return Conflict(ResponseMessage.GetMessage(message: $"Illegal parameter {nameof(Crew.CrewId)}! Parameter is set automaticly by Database!", statusCode: StatusCodes.Status409Conflict));

            if (string.IsNullOrWhiteSpace(crew.CrewValue))
                return Conflict(ResponseMessage.GetMessage(message: $"Illegal parameter {nameof(Crew.CrewValue)}! Parameter is emty or Null!", statusCode: StatusCodes.Status409Conflict));


            context.Crew.Add(crew);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CrewExists((int)crew.CrewId))
                {
                    return Conflict(ResponseMessage.GetMessage(message: $"Crew already exists!", statusCode: StatusCodes.Status409Conflict));
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCrew", new { id = crew.CrewId }, crew);
        }

        /// <summary>
        /// Deletes a specific Crew
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     DELETE /Crews/5
        /// </remarks>
        /// <param name="id">Crew ID</param>
        /// <response code="200">Crew, which was deleted successfully</response>
        /// <response code="404">If the Crew was not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Classification>> DeleteCrew(int id)
        {
            Crew crew = await context.Crew.FindAsync(id);
            if (crew == null)
            {
                return NotFound(ResponseMessage.GetMessage(message: $"Crew not found!", statusCode: StatusCodes.Status404NotFound));
            }

            context.Crew.Remove(crew);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok($"Deleted Crew {crew.CrewValue} (ID: {crew.CrewId}) successfull");
        }

        private bool CrewExists(int id)
        {
            return context.Crew.Any(e => e.CrewId == id);
        }
    }
}
