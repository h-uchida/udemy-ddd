namespace DDD.Domain.ValueObjects
{
    public sealed class Condition : ValueObject<Condition>
    {
        public Condition(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                if (Value == 1) return "晴れ";
                if (Value == 2) return "曇り";
                if (Value == 3) return "雨";
                return "不明";
            }
        }

        protected override bool EqualsCore(Condition other)
        {
            return Value == other.Value;
        }
    }
}
