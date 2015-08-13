using System.ComponentModel.DataAnnotations;


namespace Soundboard.Service.Models.Sounds
{
	public class SoundCategory
	{
		#region Fields
		private int id;
		private string name;
		private int channelId;
		#endregion


		#region Properties
		[Required]
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
		#endregion
	}
}