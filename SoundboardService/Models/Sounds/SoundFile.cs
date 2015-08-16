using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Soundboard.Service.Models.Sounds
{
	[Table("SoundFile")]
	public class SoundFile
	{
		#region Fields
		private int id;
		private string hash;
		private SoundFormat format;
		private int length;
		#endregion


		#region Enums
		public enum SoundFormat
		{

			None = 0,
			WAV,
			MP3

		}
		#endregion


		#region Properties
		/// <summary>
		/// Name of local audio file.
		/// Name is hash + . + format.
		/// </summary>
		public string Filename
		{
			get { return this.hash + "." + this.format; }
		}


		/// <summary>
		/// Audio format and extension of the sound file.
		/// </summary>
		[Required]
		public SoundFormat Format
		{
			get { return this.format; }
			set { this.format = value; }
		}


		/// <summary>
		/// Generated from the file contents.
		/// Used to determine if two uploaded files are equivalent.
		/// </summary>
		[Required]
		[Index(IsUnique = true)]
		[StringLength(32)]
		public string Hash
		{
			get { return this.hash; }
			set { this.hash = value; }
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
		/// Duration of audio in milliseconds.
		/// </summary>
		public int Length
		{
			get { return this.length; }
			set { this.length = value; }
		}
		#endregion
	}
}