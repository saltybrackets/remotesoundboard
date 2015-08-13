using System.ComponentModel.DataAnnotations;


namespace Soundboard.Service.Models.Sounds
{
	public class SoundFile
	{
		#region Fields
		private int id;
		private string hash;
		private SoundFormat format;
		private int length;
		#endregion


		public enum SoundFormat
		{
			None = 0,
			WAV,
			MP3
		}


		#region Properties
		public string Filename
		{
			get { return this.hash + "." + this.format; }
		}


		[Required]
		public SoundFormat Format
		{
			get { return this.format; }
			set { this.format = value; }
		}


		[Required]
		public string Hash
		{
			get { return this.hash; }
			set { this.hash = value; }
		}


		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}


		public int Length
		{
			get { return this.length; }
			set { this.length = value; }
		}
		#endregion
	}
}