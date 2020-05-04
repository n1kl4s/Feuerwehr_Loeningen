using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Backend.Common;
using Backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly FireContext context;

        public ClientsController(FireContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all Clients
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /Clients
        /// </remarks>
        /// <returns>All Clients</returns>
        /// <response code="200">Returns all users</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Client>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            try
            {
                return Ok(await context.Client.ToListAsync());
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a specific Clients
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /Clients/5
        /// </remarks>
        /// <param name="id">Clients ID</param>
        /// <returns>Specific Clients Clients</returns>
        /// <response code="200">Returns specific users</response>
        /// <response code="404">If the given user doesn' excist.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            Client user;

            try
            {
                user = await context.Client.FindAsync(id);
            }
            catch (SqlException)
            {
                throw;
            }

            if (user == null)
            {
                return NotFound(ResponseMessage.GetMessage(message: $"No Clients found!", statusCode: StatusCodes.Status404NotFound));
            }

            return Ok(user);
        }

        /// <summary>
        /// Updates a specific Clients
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     PUT /Clients/5
        ///     {
        ///         "userName": "New ClientName",
        ///         "userPrename": "New Prename",
        ///         "userSurname": "New Surname",
        ///         "userPasswordHash": "New Password",
        ///         "userPasswordSalt": "New Password Hash",
        ///         "positionId": "New position assignment",
        ///         "roleId": "New Role assignment"
        ///     }
        /// </remarks>
        /// <param name="id">Clients ID</param>
        /// <param name="client">Clients to Update</param>
        /// <response code="204">No content, the user was updated successfully</response>
        /// <response code="404">If the given user doesn' excist.</response>
        /// <response code="400">If the given user ID is invalid.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest(ResponseMessage.GetMessage(message: $"Invalid Clients IDs!", statusCode: StatusCodes.Status400BadRequest));
            }

            context.Entry(client).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound(ResponseMessage.GetMessage(message: $"No Clients found!", statusCode: StatusCodes.Status404NotFound));
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Clients
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     DELETE /Clients/5
        /// </remarks>
        /// <param name="id">Clients ID</param>
        /// <response code="200">Clients, which was deleted successfully</response>
        /// <response code="404">If the Clients was not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var user = await context.Client.FindAsync(id);
            if (user == null)
            {
                return NotFound(ResponseMessage.GetMessage(message: $"No Clients found!", statusCode: StatusCodes.Status404NotFound));
            }

            context.Client.Remove(user);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return Ok($"Deleted Clients {user.ClientName} (ID: {user.ClientId}) successfull");
        }

        private bool ClientExists(int id)
        {
            return context.Client.Any(e => e.ClientId == id);
        }
    }
}
