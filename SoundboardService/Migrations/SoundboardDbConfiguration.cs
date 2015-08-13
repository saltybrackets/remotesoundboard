using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using Soundboard.Service.Models;
using Soundboard.Service.Models.Sounds;


namespace Soundboard.Service.Migrations
{
	internal sealed class SoundboardDbConfiguration :CreateDatabaseIfNotExists<SoundboardServiceContext>
	{

		protected override void Seed(SoundboardServiceContext context)
		{
			context.Channels.AddOrUpdate(channel => channel.Id,
				new Channel() { Id = 0, Name = "None" },
				new Channel() { Id = 1, Name = "Global" }
				);

			context.SoundCategories.AddOrUpdate(soundCategory => soundCategory.Id, 
				new SoundCategory() { Id = 0, Name = "None" }
				);

			context.SoundFiles.AddOrUpdate(soundFile => soundFile.Id,
				new SoundFile() { Id = 0, }
				);
		}

	}
}