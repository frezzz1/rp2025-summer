using System;

namespace ModelLib
{
    /// <summary>
    /// Переговорная комната с расписанием.
    /// </summary>
    public class MeetingRoom
    {
        private readonly MeetingSchedule _schedule;

        public string Name { get; }

        public MeetingRoom(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Room name cannot be empty.", nameof(name));

            Name = name;
            _schedule = new MeetingSchedule();
        }

        public bool IsBusy(DateTimeInterval interval)
        {
            return _schedule.IsBusy(interval);
        }

        public void Add(string meetingId, DateTimeInterval interval)
        {
            _schedule.Add(meetingId, interval);
        }
    }
}
