using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Soundboard.Service.Models.Sounds;


namespace Soundboard.Service.Models
{
	public class Channel
	{
		#region Fields
		private int id;
		private string name;
		private int queuedSoundFileId;
		private long lockExpiration;
		private IList<SoundCategory> soundCategories;
		private IList<SoundRecord> soundRecords;
		#endregion


		#region Properties
		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}


		public long LockExpiration
		{
			get { return this.lockExpiration; }
			set { this.lockExpiration = value; }
		}


		[Required]
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}


		public int QueuedSoundFileId
		{
			get { return this.queuedSoundFileId; }
			set { this.queuedSoundFileId = value; }
		}


		public IList<SoundCategory> SoundCategories
		{
			get { return this.soundCategories; }
			set { this.soundCategories = value; }
		}


		public IList<SoundRecord> SoundRecords
		{
			get { return this.soundRecords; }
			set { this.soundRecords = value; }
		}
		#endregion
	}
}