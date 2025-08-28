using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelLib
{
    /// <summary>
    /// Расписание встреч для одной переговорной комнаты.
    /// </summary>
    public class MeetingSchedule
    {
        private readonly Dictionary<string, DateTimeInterval> _meetings = new();

        public MeetingSchedule()
        {
        }

        /// <summary>
        /// Проверяет, занята ли переговорная в указанный интервал.
        /// </summary>
        public bool IsBusy(DateTimeInterval interval)
        {
            if (interval == null) throw new ArgumentNullException(nameof(interval));
            return _meetings.Values.Any(existing => existing.Overlaps(interval));
        }

        /// <summary>
        /// Добавляет встречу в расписание.
        /// </summary>
        public void Add(string meetingId, DateTimeInterval interval)
        {
            if (meetingId == null) throw new ArgumentNullException(nameof(meetingId));
            if (interval == null) throw new ArgumentNullException(nameof(interval));

            if (_meetings.ContainsKey(meetingId))
                return; // уже есть такая встреча

            if (interval.End <= DateTime.Now)
                throw new InvalidOperationException("Cannot add a meeting that has already ended.");

            if (IsBusy(interval))
                throw new InvalidOperationException("Meeting time overlaps with an existing meeting.");

            _meetings.Add(meetingId, interval);
        }
    }
}
