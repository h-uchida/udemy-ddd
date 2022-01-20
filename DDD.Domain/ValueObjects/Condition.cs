namespace DDD.Domain.ValueObjects
{
    public sealed class Condition : ValueObject<Condition>
    {
        public static readonly Condition None = new Condition(0);
        public static readonly Condition Sunny = new Condition(1);
        public static readonly Condition Cloudy = new Condition(2);
        public static readonly Condition Rain = new Condition(3);

        public Condition(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                if (this == Sunny) return "晴れ";
                if (this == Cloudy) return "曇り";
                if (this == Rain) return "雨";
                return "不明";
            }
        }

        protected override bool EqualsCore(Condition other)
        {
            return Value == other.Value;
        }
    }
}
