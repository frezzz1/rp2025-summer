using System;
using Xunit;
using ModelLib;

namespace ModelLib.Tests
{
    public class MeetingRoomTests
    {
        [Fact]
        public void Can_create_meeting_room_with_name()
        {
            var room = new MeetingRoom("Alpha");

            Assert.Equal("Alpha", room.Name);
        }

        [Fact]
        public void Cannot_create_meeting_room_with_empty_name()
        {
            Assert.Throws<ArgumentException>(() => new MeetingRoom(""));
        }

        [Fact]
        public void Add_meeting_delegates_to_schedule()
        {
            var room = new MeetingRoom("Bravo");
            var interval = new DateTimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

            room.Add("M1", interval);

            Assert.True(room.IsBusy(interval));
        }

        [Fact]
        public void IsBusy_returns_false_for_free_slot()
        {
            var room = new MeetingRoom("Charlie");
            var interval = new DateTimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

            Assert.False(room.IsBusy(interval));
        }
    }
}
