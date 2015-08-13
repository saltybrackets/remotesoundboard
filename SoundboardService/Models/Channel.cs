using System.ComponentModel.DataAnnotations;


namespace Soundboard.Service.Models
{
	public class Channel
	{
		#region Fields
		private int id;
		private string name;
		private int queuedSoundFileId;
		private long lockExpiration;
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
		#endregion
	}
}