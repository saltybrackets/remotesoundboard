using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Soundboard.Service.Models.Sounds;


namespace Soundboard.Service.Models
{
	[Table("Channel")]
	public class Channel
	{
		#region Fields
		private int id;
		private string name;
		private long lockExpiration;
		private int? queuedSoundFileId;
		private SoundFile queuedSoundFile;
		private IList<SoundCategory> soundCategories;
		private IList<SoundRecord> soundRecords;
		#endregion


		#region Constructors
		
		#endregion


		#region Properties
		/// <summary>
		/// Primary key.
		/// </summary>
		[Key]
		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}


		/// <summary>
		/// When local timestamp exceeds this timestamp, channel becoems unlocked.
		/// </summary>
		public long LockExpiration
		{
			get { return this.lockExpiration; }
			set { this.lockExpiration = value; }
		}


		/// <summary>
		/// Name of the channel.
		/// </summary>
		[Index(IsUnique = true)]
		[StringLength(128)]
		[Required]
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}


		/// <summary>
		/// Next file to play on this channel's soundboard.
		/// </summary>
		[ForeignKey("QueuedSoundFileId")]
		public SoundFile QueuedSoundFile
		{
			get { return this.queuedSoundFile; }
			set { this.queuedSoundFile = value; }
		}


		/// <summary>
		/// Foreign key for QueuedSoundFile.
		/// </summary>
		public int? QueuedSoundFileId
		{
			get { return this.queuedSoundFileId; }
			set { this.queuedSoundFileId = value; }
		}


		/// <summary>
		/// Navigational property.
		/// </summary>
		public IList<SoundCategory> SoundCategories
		{
			get { return this.soundCategories; }
			set { this.soundCategories = value; }
		}


		/// <summary>
		/// Navigational property.
		/// </summary>
		public IList<SoundRecord> SoundRecords
		{
			get { return this.soundRecords; }
			set { this.soundRecords = value; }
		}
		#endregion
	}
}