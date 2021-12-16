using DDD.WinForm.Common;
using System;
using System.Collections.Generic;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : IEquatable<Temperature>
    {
        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        public Temperature(float value)
        {
            Value = value;
        }

        public float Value { get; }
        public string DisplayValue
        {
            get
            {
                return CommonFunc.RoundString(Value, DecimalPoint)
                    + UnitName;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Temperature);
        }

        public bool Equals(Temperature other)
        {
            return other != null &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + Value.GetHashCode();
        }

        public static bool operator ==(Temperature left, Temperature right)
        {
            return EqualityComparer<Temperature>.Default.Equals(left, right);
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            return !(left == right);
        }
    }
}
