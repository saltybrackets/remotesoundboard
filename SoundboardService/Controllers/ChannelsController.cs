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
using Soundboard.Service.Models;


namespace Soundboard.Service.Controllers
{
	public class ChannelsController : ApiController
	{
		#region Fields
		private SoundboardServiceContext db = new SoundboardServiceContext();
		#endregion


		// DELETE: api/Channels/5
		[ResponseType(typeof (Channel))]
		public async Task<IHttpActionResult> DeleteChannel(int id)
		{
			Channel channel = await this.db.Channels.FindAsync(id);
			if (channel == null)
				return NotFound();

			this.db.Channels.Remove(channel);
			await this.db.SaveChangesAsync();

			return Ok(channel);
		}


		// GET: api/Channels/5
		[ResponseType(typeof (Channel))]
		public async Task<IHttpActionResult> GetChannel(int id)
		{
			Channel channel = await this.db.Channels.FindAsync(id);
			if (channel == null)
				return NotFound();

			return Ok(channel);
		}


		// GET: api/Channels
		public IQueryable<Channel> GetChannels()
		{
			return this.db.Channels;
		}


		// POST: api/Channels
		[ResponseType(typeof (Channel))]
		public async Task<IHttpActionResult> PostChannel(Channel channel)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			this.db.Channels.Add(channel);
			await this.db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new {id = channel.Id}, channel);
		}


		// PUT: api/Channels/5
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


		protected override void Dispose(bool disposing)
		{
			if (disposing)
				this.db.Dispose();
			base.Dispose(disposing);
		}


		private bool ChannelExists(int id)
		{
			return this.db.Channels.Count(e => e.Id == id) > 0;
		}
	}
}