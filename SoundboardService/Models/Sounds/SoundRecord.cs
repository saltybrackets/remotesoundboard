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
		private int categoryId;
		#endregion


		#region Properties
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


		public int SoundFileId
		{
			get { return this.soundFileId; }
			set { this.soundFileId = value; }
		}
		#endregion
	}
}