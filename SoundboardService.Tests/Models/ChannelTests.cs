using System;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soundboard.Service.Models;
using Soundboard.Service.Models.Sounds;


namespace SoundboardService.Tests
{
	[TestClass]
	public class ChannelTests
	{

		[TestClass]
		public class TypeConstraints
		{
			[TestMethod]
			[ExpectedException(typeof(DbEntityValidationException))]
			public void DisallowNullNames()
			{
				using (SoundboardServiceContext context =
					new SoundboardServiceContext())
				{
					Channel nullNameChannel = new Channel()
					{
						Name = null
					};
					context.Channels.Add(nullNameChannel);
					context.SaveChanges();
				}
			}

		}
		
	}
}
