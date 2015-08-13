using System.ComponentModel.DataAnnotations;


namespace Soundboard.Service.Models.Sounds
{
	public class SoundRecord
	{
		#region Fields
		private int id;
		private int channelId;
		private int soundFileId;
		private string name;
		private int soundCategoryId;
		private Channel channel;
		private SoundCategory soundCategory;
		private SoundFile soundFile;
		#endregion


		#region Properties
		public Channel Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}


		// Foreign key for Channel
		public int ChannelId
		{
			get { return this.channelId; }
			set { this.channelId = value; }
		}


		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}


		[Required]
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}


		// Foreign key for SoundCategory
		public SoundCategory SoundCategory
		{
			get { return this.soundCategory; }
			set { this.soundCategory = value; }
		}


		public int SoundCategoryId
		{
			get { return this.soundCategoryId; }
			set { this.soundCategoryId = value; }
		}


		public SoundFile SoundFile
		{
			get { return this.soundFile; }
			set { this.soundFile = value; }
		}


		// Foreign key for SoundFile
		public int SoundFileId
		{
			get { return this.soundFileId; }
			set { this.soundFileId = value; }
		}
		#endregion
	}
}