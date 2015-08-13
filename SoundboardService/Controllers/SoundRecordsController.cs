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


namespace Soundboard.Service.Controllers
{
	public class SoundRecordsController : ApiController
	{
		#region Fields
		private SoundboardServiceContext db = new SoundboardServiceContext();
		#endregion


		// DELETE: api/SoundRecords/5
		[ResponseType(typeof (SoundRecord))]
		public async Task<IHttpActionResult> DeleteSoundRecord(int id)
		{
			SoundRecord soundRecord = await this.db.SoundRecords.FindAsync(id);
			if (soundRecord == null)
				return NotFound();

			this.db.SoundRecords.Remove(soundRecord);
			await this.db.SaveChangesAsync();

			return Ok(soundRecord);
		}


		// GET: api/SoundRecords/5
		[ResponseType(typeof (SoundRecord))]
		public async Task<IHttpActionResult> GetSoundRecord(int id)
		{
			SoundRecord soundRecord = await this.db.SoundRecords.FindAsync(id);
			if (soundRecord == null)
				return NotFound();

			return Ok(soundRecord);
		}


		// GET: api/SoundRecords
		public IQueryable<SoundRecord> GetSoundRecords()
		{
			return this.db.SoundRecords;
		}


		// POST: api/SoundRecords
		[ResponseType(typeof (SoundRecord))]
		public async Task<IHttpActionResult> PostSoundRecord(SoundRecord soundRecord)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			this.db.SoundRecords.Add(soundRecord);
			await this.db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new {id = soundRecord.Id}, soundRecord);
		}


		// PUT: api/SoundRecords/5
		[ResponseType(typeof (void))]
		public async Task<IHttpActionResult> PutSoundRecord(int id, SoundRecord soundRecord)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			if (id != soundRecord.Id)
				return BadRequest();

			this.db.Entry(soundRecord).State = EntityState.Modified;

			try
			{
				await this.db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SoundRecordExists(id))
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


		private bool SoundRecordExists(int id)
		{
			return this.db.SoundRecords.Count(e => e.Id == id) > 0;
		}

	}
}