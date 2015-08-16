using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using Soundboard.Service.Models;
using Soundboard.Service.Models.Sounds;


namespace Soundboard.Service.Migrations
{
	internal sealed class DropCreateSoundboardDbAlways : DropCreateDatabaseAlways<SoundboardServiceContext>
	{

		protected override void Seed(SoundboardServiceContext context)
		{
			base.Seed(context);
			context.Channels.AddOrUpdate(channel => channel.Id,
				new Channel() { Name = "Global" }
				);
		}

	}
}