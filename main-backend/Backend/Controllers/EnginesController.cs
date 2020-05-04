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
    [ApiController]
    public class EnginesController : ControllerBase
    {
        private readonly FireContext context;

        public EnginesController(FireContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all Engines
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /Engines
        /// </remarks>
        /// <returns>All Engines</returns>
        /// <response code="200">Returns all Engines</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Engine>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Engine>>> GetEngine()
        {
            List<Engine> engines;
            try
            {
                engines = await context.Engine.Include(e => e.Crew)
                                              .Include(e => e.Classification)
                                              .ToListAsync();
            }
            catch (SqlException)
            {
                throw;
            }

            // remove back link cause json loop
            foreach (Engine engine in engines)
            {
                engine.Crew.Engines = null;
                engine.Classification.Engines = null;
            }

            engines = engines.OrderBy(sorter => sorter.EngineId).ToList();

            return Ok(engines);
        }

        /// <summary>
        /// Get a specific Engines
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /Engines/5
        /// </remarks>
        /// <param name="id">Engines ID</param>
        /// <returns>Specific Engines</returns>
        /// <response code="200">Returns specific Engines</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Engine), StatusCodes.Status200OK)]
        public async Task<ActionResult<Engine>> GetEngine(int id)
        {
            Engine engine;

            try
            {
                engine = await context.Engine.Include(engine => engine.Crew)
                                             .Include(engine => engine.Classification)
                                             .FirstOrDefaultAsync(engine => engine.EngineId == id);
            }
            catch (SqlException)
            {
                throw;
            }

            if (engine == null)
            {
                return NotFound(ResponseMessage.GetMessage(message: $"No Engines found!", statusCode: StatusCodes.Status404NotFound));
            }

            // remove back link cause json loop
            engine.Crew.Engines = null;
            engine.Classification.Engines = null;
            return Ok(engine);
        }

        /// <summary>
        /// Updates a specific Engines
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     PUT /Engines/5
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <param name="id">Engines ID</param>
        /// <param name="classification">Engines values</param>
        /// <response code="204">No content, the Engines was updated successfully</response>
        /// <response code="404">If the given Engines doesn' excist.</response>
        /// <response code="400">If the given Engines ID is invalid.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutEngine(int id, Engine engine)
        {
            if (id != engine.EngineId)
            {
                return BadRequest(ResponseMessage.GetMessage(message: $"Invalid Engines IDs!", statusCode: StatusCodes.Status400BadRequest));
            }

            context.Entry(engine).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineExists(id))
                {
                    return NotFound(ResponseMessage.GetMessage(message: $"No Engines found!", statusCode: StatusCodes.Status404NotFound));
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a new Engines
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     Post /Engines/Add
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <returns>Newly created Engines</returns>
        /// <response code="201">Returns the newly created Engines</response>
        /// <response code="409">If a parameter Conflict occurrs</response>
        [HttpPost]
        [ProducesResponseType(typeof(Engine), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Engine>> PostEngine(Engine engine)
        {
            if (engine.EngineId != null)
                return Conflict(ResponseMessage.GetMessage(message: $"Illegal parameter {nameof(Engine.EngineId)}! Parameter is set automaticly by Database!", statusCode: StatusCodes.Status409Conflict));

            if (string.IsNullOrWhiteSpace(engine.EngineLicensePlate))
                return Conflict(ResponseMessage.GetMessage(message: $"Illegal parameter {nameof(Engine.EngineLicensePlate)}! Parameter is emty or Null!", statusCode: StatusCodes.Status409Conflict));


            context.Engine.Add(engine);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EngineExists((int)engine.CrewId))
                {
                    return Conflict(ResponseMessage.GetMessage(message: $"Engines already exists!", statusCode: StatusCodes.Status409Conflict));
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEngine", new { id = engine.EngineId }, engine);
        }

        /// <summary>
        /// Deletes a specific Engines
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     DELETE /Engines/5
        /// </remarks>
        /// <param name="id">Engines ID</param>
        /// <response code="200">Engines, which was deleted successfully</response>
        /// <response code="404">If the Engines was not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Engine>> DeleteEngine(int id)
        {
            Engine engine = await context.Engine.FindAsync(id);
            if (engine == null)
            {
                return NotFound(ResponseMessage.GetMessage(message: $"Engines not found!", statusCode: StatusCodes.Status404NotFound));
            }

            context.Engine.Remove(engine);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok($"Deleted Engines {engine.Classification.ClassificationType} {engine.EngineNumber} (ID: {engine.EngineId}) successfull");
        }

        private bool EngineExists(int id)
        {
            return context.Engine.Any(e => e.EngineId == id);
        }
    }
}
