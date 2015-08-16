using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soundboard.Service.Models;
using Soundboard.Service.Models.Sounds;


namespace SoundboardService.Tests
{
	[TestClass]
	public class SoundboardServiceContextTests
	{

		[TestClass]
		public class DatabaseInitialization
		{
			[TestMethod]
			public void DropCreateNewDatabase()
			{
				using (SoundboardServiceContext context = 
					new SoundboardServiceContext(
						SoundboardServiceContext.DBCreationMethod.DropCreateAlways))
				{
					Channel globalChannel = context.Channels
						.FirstOrDefault(channel => channel.Name == "Global");
					Assert.IsNotNull(globalChannel);
				}
			}

		}
		
	}
}
