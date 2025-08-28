using System;
using Xunit;
using ModelLib;

namespace ModelLib.Tests
{
    public class MeetingScheduleTests
    {
        [Fact]
        public void Can_add_meeting_when_room_is_free()
        {
            var schedule = new MeetingSchedule();
            var interval = new DateTimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

            schedule.Add("M1", interval);

            Assert.True(schedule.IsBusy(interval));
        }

        [Fact]
        public void Cannot_add_meeting_that_ends_in_the_past()
        {
            var schedule = new MeetingSchedule();
            var pastInterval = new DateTimeInterval(DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1));

            Assert.Throws<InvalidOperationException>(() => schedule.Add("Past", pastInterval));
        }

        [Fact]
        public void Cannot_add_meeting_that_overlaps_existing()
        {
            var schedule = new MeetingSchedule();
            var interval1 = new DateTimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            var interval2 = new DateTimeInterval(DateTime.Now.AddHours(1.5), DateTime.Now.AddHours(2.5));

            schedule.Add("M1", interval1);

            Assert.Throws<InvalidOperationException>(() => schedule.Add("M2", interval2));
        }

        [Fact]
        public void Adding_same_meetingId_does_nothing()
        {
            var schedule = new MeetingSchedule();
            var interval1 = new DateTimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            var interval2 = new DateTimeInterval(DateTime.Now.AddHours(3), DateTime.Now.AddHours(4));

            schedule.Add("M1", interval1);
            schedule.Add("M1", interval2); // должно игнорироваться

            Assert.True(schedule.IsBusy(interval1));
            Assert.False(schedule.IsBusy(interval2));
        }

        [Fact]
        public void IsBusy_returns_false_if_no_overlap()
        {
            var schedule = new MeetingSchedule();
            var interval1 = new DateTimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
            var interval2 = new DateTimeInterval(DateTime.Now.AddHours(3), DateTime.Now.AddHours(4));

            schedule.Add("M1", interval1);

            Assert.False(schedule.IsBusy(interval2));
        }
    }
}
