using System;

namespace FinanceBook.Finance.Domain.ValueObjects
{
    public sealed class Amount
    {

        private decimal _value;

        public Amount(decimal value)
        {
            _value = value;
        }

        public static implicit operator decimal(Amount value) => value?._value ?? 0;

        public static implicit operator Amount(decimal value) => new(value);
        public static Amount operator -(Amount value) => new(Math.Abs(value._value) * -1);

        public static Amount operator --(Amount value) => --value._value;

        public static Amount operator ++(Amount value) => ++value._value;

        public static Amount operator +(Amount first, Amount second) => new(first._value + second._value);

        public static Amount operator -(Amount first, Amount second) => new(first._value - second._value);

        public static bool operator <(Amount first, Amount second) => first._value < second._value;

        public static bool operator >(Amount first, Amount second) => first._value > second._value;

        public static bool operator <=(Amount first, Amount second) => first._value <= second._value;

        public static bool operator >=(Amount first, Amount second) => first._value >= second._value;

        public static bool operator ==(Amount first, Amount second) => first._value == second._value;

        public static bool operator !=(Amount first, Amount second) => first._value != second._value;

        public override string ToString() => _value.ToString();


        public override int GetHashCode() => _value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            return obj is decimal value ? value == _value : ((Amount)obj)._value == _value;
        }
    }
}