using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Soundboard.Service.Models.Sounds
{
	[Table("SoundCategory")]
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
		/// <summary>
		/// Channel this category exists on.
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
		/// Display name of the sound category.
		/// </summary>
		[Required]
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}


		/// <summary>
		/// Collection navigation property.
		/// </summary>
		public IList<SoundRecord> SoundRecords
		{
			get { return this.soundRecords; }
			set { this.soundRecords = value; }
		}
		#endregion
	}
}