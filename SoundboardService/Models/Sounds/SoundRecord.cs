using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Soundboard.Service.Models.Sounds
{
	[Table("SoundRecord")]
	public class SoundRecord
	{
		#region Fields
		private int id;
		private int channelId;
		private int soundFileId;
		private string name;
		private int? soundCategoryId;
		private Channel channel;
		private SoundCategory soundCategory;
		private SoundFile soundFile;
		#endregion


		#region Properties
		/// <summary>
		/// Soundboard channel this sound exists on.
		/// </summary>
		[ForeignKey("ChannelId")]
		public Channel Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}

		
		/// <summary>
		/// Foreign key for Channel.
		/// </summary>
		public int ChannelId
		{
			get { return this.channelId; }
			set { this.channelId = value; }
		}


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
		/// Display name of the sound within the channel.
		/// </summary>
		[Required]
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}


		/// <summary>
		/// Category this sound is displayed under.
		/// </summary>
		[ForeignKey("SoundCategoryId")]
		public SoundCategory SoundCategory
		{
			get { return this.soundCategory; }
			set { this.soundCategory = value; }
		}

		
		/// <summary>
		/// Foreign key for SoundCategory.
		/// </summary>
		public int? SoundCategoryId
		{
			get { return this.soundCategoryId; }
			set { this.soundCategoryId = value; }
		}


		/// <summary>
		/// Sound file this record points to.
		/// </summary>
		[ForeignKey("SoundFileId")]
		public SoundFile SoundFile
		{
			get { return this.soundFile; }
			set { this.soundFile = value; }
		}

		
		/// <summary>
		/// Foreign key for SoundFile.
		/// </summary>
		public int SoundFileId
		{
			get { return this.soundFileId; }
			set { this.soundFileId = value; }
		}
		#endregion
	}
}