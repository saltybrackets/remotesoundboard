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
	public class SoundCategoriesController : ApiController
	{
		#region Fields
		private SoundboardServiceContext db = new SoundboardServiceContext();
		#endregion


		// DELETE: api/SoundCategories/5
		[ResponseType(typeof (SoundCategory))]
		public async Task<IHttpActionResult> DeleteSoundCategory(int id)
		{
			SoundCategory soundCategory = await this.db.SoundCategories.FindAsync(id);
			if (soundCategory == null)
				return NotFound();

			this.db.SoundCategories.Remove(soundCategory);
			await this.db.SaveChangesAsync();

			return Ok(soundCategory);
		}


		// GET: api/SoundCategories
		public IQueryable<SoundCategory> GetSoundCategories()
		{
			return this.db.SoundCategories;
		}


		// GET: api/SoundCategories/5
		[ResponseType(typeof (SoundCategory))]
		public async Task<IHttpActionResult> GetSoundCategory(int id)
		{
			SoundCategory soundCategory = await this.db.SoundCategories.FindAsync(id);
			if (soundCategory == null)
				return NotFound();

			return Ok(soundCategory);
		}


		// POST: api/SoundCategories
		[ResponseType(typeof (SoundCategory))]
		public async Task<IHttpActionResult> PostSoundCategory(SoundCategory soundCategory)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			this.db.SoundCategories.Add(soundCategory);
			await this.db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new {id = soundCategory.Id}, soundCategory);
		}


		// PUT: api/SoundCategories/5
		[ResponseType(typeof (void))]
		public async Task<IHttpActionResult> PutSoundCategory(int id, SoundCategory soundCategory)
		{
			if (!this.ModelState.IsValid)
				return BadRequest(this.ModelState);

			if (id != soundCategory.Id)
				return BadRequest();

			this.db.Entry(soundCategory).State = EntityState.Modified;

			try
			{
				await this.db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SoundCategoryExists(id))
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


		private bool SoundCategoryExists(int id)
		{
			return this.db.SoundCategories.Count(e => e.Id == id) > 0;
		}
	}
}