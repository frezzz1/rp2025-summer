using System;
using Xunit;
using ModelLib;

namespace ModelLib.Tests
{
    public class DateTimeIntervalTests
    {
        [Fact]
        public void Can_create_interval_with_valid_times()
        {
            DateTime start = new(2025, 1, 1, 10, 0, 0);
            DateTime end = new(2025, 1, 1, 12, 0, 0);

            var interval = new DateTimeInterval(start, end);

            Assert.Equal(start, interval.Start);
            Assert.Equal(end, interval.End);
            Assert.Equal(TimeSpan.FromHours(2), interval.Duration);
        }

        [Fact]
        public void Cannot_create_interval_with_end_equal_to_start()
        {
            DateTime start = DateTime.Now;
            Assert.Throws<ArgumentException>(() => new DateTimeInterval(start, start));
        }

        [Fact]
        public void Cannot_create_interval_with_end_before_start()
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(-1);
            Assert.Throws<ArgumentException>(() => new DateTimeInterval(start, end));
        }

        [Fact]
        public void Overlaps_returns_true_for_overlapping_intervals()
        {
            var i1 = new DateTimeInterval(DateTime.Today.AddHours(9), DateTime.Today.AddHours(11));
            var i2 = new DateTimeInterval(DateTime.Today.AddHours(10), DateTime.Today.AddHours(12));

            Assert.True(i1.Overlaps(i2));
        }

        [Fact]
        public void Overlaps_returns_false_for_adjacent_intervals()
        {
            var i1 = new DateTimeInterval(DateTime.Today.AddHours(9), DateTime.Today.AddHours(10));
            var i2 = new DateTimeInterval(DateTime.Today.AddHours(10), DateTime.Today.AddHours(11));

            Assert.False(i1.Overlaps(i2));
        }

        [Fact]
        public void CompareTo_sorts_by_start_time()
        {
            var earlier = new DateTimeInterval(DateTime.Today.AddHours(8), DateTime.Today.AddHours(9));
            var later = new DateTimeInterval(DateTime.Today.AddHours(10), DateTime.Today.AddHours(11));

            Assert.True(earlier.CompareTo(later) < 0);
            Assert.True(later.CompareTo(earlier) > 0);
        }
    }
}
