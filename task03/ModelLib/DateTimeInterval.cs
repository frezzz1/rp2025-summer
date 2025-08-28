using System;

namespace ModelLib
{
    /// <summary>
    /// Временной интервал с началом и концом.
    /// </summary>
    public class DateTimeInterval : IComparable<DateTimeInterval>
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public TimeSpan Duration => End - Start;

        public DateTimeInterval(DateTime start, DateTime end)
        {
            if (end <= start)
            {
                throw new ArgumentException("End time must be greater than start time");
            }

            Start = start;
            End = end;
        }

        /// <summary>
        /// Проверка пересечения интервалов (примыкание не считается пересечением).
        /// </summary>
        public bool Overlaps(DateTimeInterval other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return Start < other.End && End > other.Start;
        }

        /// <summary>
        /// Для сортировки по времени начала.
        /// </summary>
        public int CompareTo(DateTimeInterval other)
        {
            if (other == null) return 1;
            return Start.CompareTo(other.Start);
        }
    }
}
