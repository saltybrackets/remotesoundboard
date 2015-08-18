using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Soundboard.Service.Models;


namespace Soundboard.Service.Controllers
{
	public class ChannelsController : ApiController
	{
		#region Fields
		private SoundboardServiceContext db = new SoundboardServiceContext();
		#endregion


		/// <summary>
		/// Endpoint to delete a channel by Id.
		/// DELETE: api/channels/#
		/// </summary>
		/// <param name="id">Id of channel to delete.</param>
		/// <returns>Channel that was deleted, if found.</returns>
		[ResponseType(typeof (Channel))]
		public async Task<IHttpActionResult> DeleteChannel(int id)
		{
			Channel result = await this.db.Channels.FindAsync(id);
			if (result == null)
				return NotFound();

			this.db.Channels.Remove(result);
			await this.db.SaveChangesAsync();

			return Ok(result);
		}


		/// <summary>
		/// Retrieve a channel by Id.
		/// GET: api/channels/#
		/// </summary>
		/// <param name="id">Id of channel to retrieve.</param>
		/// <returns>Channel, if found.</returns>
		[ResponseType(typeof (Channel))]
		public async Task<IHttpActionResult> GetChannel(int id)
		{
			Channel result = await this.db.Channels.FindAsync(id);
			if (result == null)
				return NotFound();

			return Ok(result);
		}


		/// <summary>
		/// Retrieve a channel by Name.
		/// GET: api/channels/?name=string
		/// </summary>
		/// <param name="name">Name of channel to retrieve.</param>
		/// <returns>Channel, if found.</returns>
		[ResponseType(typeof (Channel))]
		public async Task<IHttpActionResult> GetChannel(string name)
		{
			Channel result = await Task.Run(() =>
			{
				return this.db.Channels
					.FirstOrDefault(channel => channel.Name == name);
			});

			if (result == null)
				return NotFound();

			return Ok(result);
		}

		
		// POST: api/Channels
		/// <summary>
		/// Create a new channel.
		/// </summary>
		/// <param name="channel">Channel to create.</param>
		/// <returns></returns>
		[ResponseType(typeof (Channel))]
		public async Task<IHttpActionResult> PostChannel(Channel channel)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			// TODO: Check if channel name already exists.
			if (ChannelExists(channel.Name))
				return Content(HttpStatusCode.Conflict, "Channel by that name already exists.");

			this.db.Channels.Add(channel);
			await this.db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new {id = channel.Id}, channel);
		}


		/// <summary>
		/// Update an existing channel by Id.
		/// PUT: api/channels/#
		/// </summary>
		/// <param name="id">Id of channel to update.</param>
		/// <param name="channel">Updated Channel object.</param>
		/// <returns>Nothing if successful.</returns>
		[ResponseType(typeof (void))]
		public async Task<IHttpActionResult> PutChannel(int id, Channel channel)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			if (id != channel.Id)
				return BadRequest();

			this.db.Entry(channel).State = EntityState.Modified;

			try
			{
				await this.db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ChannelExists(id))
					return NotFound();
				else
					throw;
			}

			return StatusCode(HttpStatusCode.NoContent);
		}


		/// <summary>
		/// Update an existing channel by Name.
		/// PUT: api/channels/?name=string
		/// </summary>
		/// <param name="name">Name of channel to update.</param>
		/// <param name="channel">Updated Channel object.</param>
		/// <returns>Nothing if successful.</returns>
		[ResponseType(typeof (void))]
		public async Task<IHttpActionResult> PutChannel(string name, Channel channel)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			if (name.ToLower() != channel.Name.ToLower())
				return BadRequest();

			this.db.Entry(channel).State = EntityState.Modified;

			try
			{
				await this.db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ChannelExists(name))
					return NotFound();
				else
					throw;
			}

			return StatusCode(HttpStatusCode.NoContent);
		}


		// Dispose of controller instance.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				this.db.Dispose();
			base.Dispose(disposing);
		}


		// Check if a channel exists with specified Id.
		private bool ChannelExists(int id)
		{
			return this.db.Channels.Count(e => e.Id == id) > 0;
		}


		// Check if a channel exists with specified Name.
		private bool ChannelExists(string name)
		{
			Channel result = this.db.Channels
				.FirstOrDefault(channel => channel.Name == name);
			return result != null;
		}


		/// <summary>
		/// Get a list of all existing channels.
		/// </summary>
		/// <returns></returns>
		public IQueryable<Channel> GetChannels()
		{
			// Uncomment below to implement this method.
			// Not suggest, this could easily be exploited.
			//return this.db.Channels;

			return null;
		}
	}
}