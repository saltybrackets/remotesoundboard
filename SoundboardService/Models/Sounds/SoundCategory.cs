using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Soundboard.Service.Models.Sounds
{
	public class SoundCategory
	{
		#region Fields
		private int id;
		private string name;
		private int channelId;
		private Channel channel;
		private IList<SoundRecord> soundRecords;
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


		// Collection navigation property.
		public IList<SoundRecord> SoundRecords
		{
			get { return this.soundRecords; }
			set { this.soundRecords = value; }
		}
		#endregion
	}
}