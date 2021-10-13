using System;

namespace FinanceBook.Finance.Domain.ValueObjects
{
    public sealed class MonthDate : IComparable
    {
        private DateTime? _date;

        public static MonthDate Now
        {
            get
            {
                DateTime now = DateTime.Now;
                return new MonthDate(now.Year, now.Month);
            }
        }

        public MonthDate(int year, int month)
        {
            _date = new DateTime(year, month, 1);
        }

        public static implicit operator MonthDate(DateTime date) => new(date.Year, date.Month);

        public static implicit operator DateTime?(MonthDate date) => date?._date;
        public static implicit operator DateTime(MonthDate date) => date._date.GetValueOrDefault();


        public static bool operator >(MonthDate first, MonthDate second) => first?.CompareTo(second) > 0;
        public static bool operator <(MonthDate first, MonthDate second) => first?.CompareTo(second) < 0;

        public static bool operator >=(MonthDate first, MonthDate second) => first?.CompareTo(second) >= 0;

        public static bool operator <=(MonthDate first, MonthDate second) => first?.CompareTo(second) <= 0;

        public static bool operator ==(MonthDate first, MonthDate second) => first?.CompareTo(second) == 0;

        public static bool operator !=(MonthDate first, MonthDate second) => first?.CompareTo(second) != 0;

        public override string ToString() => _date?.ToShortDateString();

        public override int GetHashCode() => _date.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            return CompareTo(obj) == 0;
        }
        public int CompareTo(object obj)
        {
            if (obj is MonthDate monthDate)
                return _date.GetValueOrDefault().CompareTo(monthDate?._date);

            if (obj is DateTime date)
                return _date.GetValueOrDefault().CompareTo(new(date.Year, date.Month, 1));

            throw new ArgumentException("obj is not the same type as this istance");

        }
    }
}
