﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Recognizers.DataTypes.DateTime.Tests
{
    [TestClass]
    public class TestTimexCreator
    {
        [TestMethod]
        public void Creator_Today()
        {
            var d = System.DateTime.Now;
            var expected = TimexFormat.Format(new Timex
            {
                Year = d.Year,
                Month = d.Month,
                DayOfMonth = d.Day
            });
            Assert.AreEqual(expected, TimexCreator.Today());
        }

        [TestMethod]
        public void Creator_Today_Relative()
        {
            Assert.AreEqual("2017-10-05", TimexCreator.Today(new System.DateTime(2017, 10, 5)));
        }

        [TestMethod]
        public void Creator_Tomorrow()
        {
            var d = System.DateTime.Now;
            d = d.AddDays(1);
            var expected = TimexFormat.Format(new Timex
            {
                Year = d.Year,
                Month = d.Month,
                DayOfMonth = d.Day
            });
            Assert.AreEqual(expected, TimexCreator.Tomorrow());
        }

        [TestMethod]
        public void Creator_Tomorrow_Relative()
        {
            Assert.AreEqual("2017-10-06", TimexCreator.Tomorrow(new System.DateTime(2017, 10, 5)));
        }

        [TestMethod]
        public void Creator_Yesterday()
        {
            var d = System.DateTime.Now;
            d = d.AddDays(-1);
            var expected = TimexFormat.Format(new Timex
            {
                Year = d.Year,
                Month = d.Month,
                DayOfMonth = d.Day
            });
            Assert.AreEqual(expected, TimexCreator.Yesterday());
        }

        [TestMethod]
        public void Creator_Yesterday_Relative()
        {
            Assert.AreEqual("2017-10-04", TimexCreator.Yesterday(new System.DateTime(2017, 10, 5)));
        }

        [TestMethod]
        public void Creator_WeekFromToday()
        {
            var d = System.DateTime.Now;
            var expected = TimexFormat.Format(new Timex
            {
                Year = d.Year,
                Month = d.Month,
                DayOfMonth = d.Day,
                Days = 7
            });
            Assert.AreEqual(expected, TimexCreator.WeekFromToday());
        }

        [TestMethod]
        public void Creator_WeekFromToday_Relative()
        {
            Assert.AreEqual("(2017-10-05,2017-10-12,P7D)", TimexCreator.WeekFromToday(new System.DateTime(2017, 10, 5)));
        }

        [TestMethod]
        public void Creator_WeekBackFromToday()
        {
            var d = System.DateTime.Now;
            d = d.AddDays(-7);
            var expected = TimexFormat.Format(new Timex
            {
                Year = d.Year,
                Month = d.Month,
                DayOfMonth = d.Day,
                Days = 7
            });
            Assert.AreEqual(expected, TimexCreator.WeekBackFromToday());
        }

        [TestMethod]
        public void Creator_WeekBackFromToday_Relative()
        {
            Assert.AreEqual("(2017-09-28,2017-10-05,P7D)", TimexCreator.WeekBackFromToday(new System.DateTime(2017, 10, 5)));
        }

        [TestMethod]
        public void Creator_nextWeek()
        {
            var start = TimexDateHelpers.DateOfNextDay(DayOfWeek.Monday, System.DateTime.Now);
            var t = Timex.FromDate(start);
            t.Days = 7;
            var expected = t.TimexValue;
            Assert.AreEqual(expected, TimexCreator.NextWeek());
        }

        [TestMethod]
        public void Creator_NextWeek_Relative()
        {
            Assert.AreEqual("(2017-10-09,2017-10-16,P7D)", TimexCreator.NextWeek(new System.DateTime(2017, 10, 5)));
        }
        
        [TestMethod]
        public void Creator_lastWeek()
        {
            var start = TimexDateHelpers.DateOfLastDay(DayOfWeek.Monday, System.DateTime.Now);
            start = start.AddDays(-7);
            var t = Timex.FromDate(start);
            t.Days = 7;
            var expected = t.TimexValue;
            Assert.AreEqual(expected, TimexCreator.LastWeek());
        }

        [TestMethod]
        public void Creator_LastWeek_Relative()
        {
            Assert.AreEqual("(2017-09-25,2017-10-02,P7D)", TimexCreator.LastWeek(new System.DateTime(2017, 10, 5)));
        }

        [TestMethod]
        public void Creator_NextWeeksFromToday()
        {
            var d = System.DateTime.Now;
            var expected = TimexFormat.Format(new Timex
            {
                Year = d.Year,
                Month = d.Month,
                DayOfMonth = d.Day,
                Days = 14
            });
            Assert.AreEqual(expected, TimexCreator.NextWeeksFromToday(2));
        }

        [TestMethod]
        public void Creator_NextWeeksFromToday_Relative()
        {
            Assert.AreEqual("(2017-10-05,2017-10-19,P14D)", TimexCreator.NextWeeksFromToday(2, new System.DateTime(2017, 10, 5)));
        }
    }
}
