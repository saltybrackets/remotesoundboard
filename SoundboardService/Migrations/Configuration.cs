using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using Soundboard.Service.Models;
using Soundboard.Service.Models.Sounds;


namespace Soundboard.Service.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<Models.SoundboardServiceContext>
	{
		#region Constructors
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
		}
		#endregion


		protected override void Seed(Models.SoundboardServiceContext context)
		{
			context.Channels.AddOrUpdate(channel => channel.Id,
				new Channel() { Id = 0, Name = "default" }
				);

			context.SoundFiles.AddOrUpdate(soundFile => soundFile.Id,
				new SoundFile() { Id = 0, }
				);
		}

	}
}