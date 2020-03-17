using System;
using System.Collections.Generic;
using ERMPowerTest.Models;
using Xunit;
using FluentAssertions;
using FluentAssertions.Extensions;

namespace ERMPowerTestUnitTest
{
    public class UnitTest
	{
		private static List<LPDTO> MockDataLP()
		{
			List<LPDTO> lLP = new List<LPDTO>
			{
                new LPDTO
				{
					DataValue = 1,
					Date = DateTime.Today.AddDays(1)
				},
				new LPDTO
				{
					DataValue = 1.6,
					Date = DateTime.Today.AddDays(1)
				},
				new LPDTO
				{
					DataValue = 2,
					Date = DateTime.Today.AddDays(2)
				},
				new LPDTO
				{
					DataValue = 2.4,
					Date = DateTime.Today.AddDays(1)
				},
				new LPDTO
				{
					DataValue = 3,
					Date = DateTime.Today.AddDays(-3)
				},
			};
			return lLP;
		}

		private static List<TOUDTO> MockDataTOU()
		{
			List<TOUDTO> touData = new List<TOUDTO>
			{
				new TOUDTO
                {
					Energy = 3.6,
					Date = DateTime.Today.AddDays(-2)

				},
				new TOUDTO
				{
					Energy = 3.72,
					Date = DateTime.Today.AddDays(-2)
				},
				new TOUDTO
				{
					Energy = 4.3,
					Date = DateTime.Today.AddDays(2)
				},
				new TOUDTO
				{
					Energy = 5,
					Date = DateTime.Today.AddDays(-3)
				},
				new TOUDTO
				{
					Energy = 5.58,
					Date = DateTime.Today.AddDays(5)
				},
				new TOUDTO
				{
					Energy = 8,
					Date = DateTime.Today.AddDays(-6)
				},
			};
			return touData;
		}

		[Fact]
		public void LPGetMedianTest()
		{
			double expected = 2;
			var lpData = MockDataLP();
			var result = ERMPowerTest.Services.LPService.GetMedian(lpData);
			Assert.Equal(result, expected);
		}

		[Fact]
		public void GetToPrintLPTest()
		{
			List<LPDTO> expected = new List<LPDTO>
			{
				new LPDTO
				{
					DataValue = 1,
					Date = DateTime.Today.AddDays(1)
				},
				new LPDTO
				{
					DataValue = 1.6,
					Date = DateTime.Today.AddDays(1)
				},
				new LPDTO
				{
					DataValue = 2.4,
					Date = DateTime.Today.AddDays(1)
				},
				new LPDTO
				{
					DataValue = 3,
					Date = DateTime.Today.AddDays(-3)
				},
			};
			var lpData = MockDataLP();
			var result = ERMPowerTest.Services.LPService.GetToPrintLP(lpData, 2);
			expected.Should().Equal(result, (c1, c2) => c1.Date == c2.Date);
			expected.Should().Equal(result, (c1, c2) => c1.DataValue == c2.DataValue);
		}

		[Fact]
		public void ToUGetMedianTest()
		{
			double expected = 4.65;
			var touData = MockDataTOU();
			var result = ERMPowerTest.Services.TOUService.GetMedian(touData);
			Assert.Equal(result, expected);
		}

		[Fact]
		public void GetToPrintTOUTest()
		{
			List<TOUDTO> expected = new List<TOUDTO>
			{
				new TOUDTO
				{
					Energy = 3.6,
					Date = DateTime.Today.AddDays(-2)

				},
				new TOUDTO
				{
					Energy = 3.72,
					Date = DateTime.Today.AddDays(-2)
				},
				new TOUDTO
				{
					Energy = 5.58,
					Date = DateTime.Today.AddDays(5)
				},
				new TOUDTO
				{
					Energy = 8,
					Date = DateTime.Today.AddDays(-6)
				},
			};
			var touData = MockDataTOU();
			var result = ERMPowerTest.Services.TOUService.GetToPrintTOU(touData, 4.65);
			expected.Should().Equal(result, (c1, c2) => c1.Date == c2.Date);
			expected.Should().Equal(result, (c1, c2) => c1.Energy == c2.Energy);
		}
	}
}
