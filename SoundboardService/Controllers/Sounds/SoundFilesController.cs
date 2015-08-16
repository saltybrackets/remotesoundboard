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
using Soundboard.Service.Models.Sounds;


namespace Soundboard.Service.Controllers.Sounds
{
	public class SoundFilesController : ApiController
	{
		#region Fields
		private SoundboardServiceContext db = new SoundboardServiceContext();
		#endregion


		// DELETE: api/SoundFiles/5
		[ResponseType(typeof (SoundFile))]
		public async Task<IHttpActionResult> DeleteSoundFile(int id)
		{
			SoundFile soundFile = await this.db.SoundFiles.FindAsync(id);
			if (soundFile == null)
				return NotFound();

			this.db.SoundFiles.Remove(soundFile);
			await this.db.SaveChangesAsync();

			return Ok(soundFile);
		}


		// GET: api/SoundFiles/5
		[ResponseType(typeof (SoundFile))]
		public async Task<IHttpActionResult> GetSoundFile(int id)
		{
			SoundFile soundFile = await this.db.SoundFiles.FindAsync(id);
			if (soundFile == null)
				return NotFound();

			return Ok(soundFile);
		}


		// GET: api/SoundFiles
		public IQueryable<SoundFile> GetSoundFiles()
		{
			return this.db.SoundFiles;
		}


		// POST: api/SoundFiles
		[ResponseType(typeof (SoundFile))]
		public async Task<IHttpActionResult> PostSoundFile(SoundFile soundFile)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			this.db.SoundFiles.Add(soundFile);
			await this.db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new {id = soundFile.Id}, soundFile);
		}


		// PUT: api/SoundFiles/5
		[ResponseType(typeof (void))]
		public async Task<IHttpActionResult> PutSoundFile(int id, SoundFile soundFile)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			if (id != soundFile.Id)
				return BadRequest();

			this.db.Entry(soundFile).State = EntityState.Modified;

			try
			{
				await this.db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SoundFileExists(id))
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


		private bool SoundFileExists(int id)
		{
			return this.db.SoundFiles.Count(e => e.Id == id) > 0;
		}
	}
}