using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Soundboard.Service.Migrations;


namespace Soundboard.Service.Models
{
	[DbConfigurationType(typeof (MySql.Data.Entity.MySqlEFConfiguration))]
	public class SoundboardServiceContext : DbContext
	{
		#region Constructors
		public SoundboardServiceContext()
			: this(DBCreationMethod.CreateIfNotExists) {}


		public SoundboardServiceContext(DBCreationMethod creationMethod =
			DBCreationMethod.CreateIfNotExists)
			: base("name=SoundboardConnectionString")
		{
			switch (creationMethod)
			{
				case DBCreationMethod.CreateIfNotExists:
					Database.SetInitializer(new CreateSoundboardDbIfNotExists());
					break;
				case DBCreationMethod.DropCreateIfModelChanges:
					Database.SetInitializer(new DropCreateSoundboardDbIfModelChanges());
					break;
				case DBCreationMethod.DropCreateAlways:
					Database.SetInitializer(new DropCreateSoundboardDbAlways());
					break;
			}
		}
		#endregion


		#region Enums
		public enum DBCreationMethod
		{
			CreateIfNotExists,
			DropCreateIfModelChanges,
			DropCreateAlways
		}
		#endregion


		#region Properties
		public DbSet<Channel> Channels { get; set; }
		public DbSet<Sounds.SoundCategory> SoundCategories { get; set; }
		public DbSet<Sounds.SoundFile> SoundFiles { get; set; }
		public DbSet<Sounds.SoundRecord> SoundRecords { get; set; }
		#endregion
	}
}