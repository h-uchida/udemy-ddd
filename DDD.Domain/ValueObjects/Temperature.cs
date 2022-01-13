using DDD.WinForm.Common;
using System;
using System.Collections.Generic;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        public Temperature(float value)
        {
            Value = value;
        }

        public float Value { get; }
        public string DisplayValue => CommonFunc.RoundString(Value, DecimalPoint);
        public string DisplayValueWithUnitSpace => $"{DisplayValue} ℃";

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
