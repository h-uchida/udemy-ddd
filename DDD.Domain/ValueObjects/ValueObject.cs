using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {

        public override bool Equals(object obj)
        {
            var vo = obj as T;
            if (vo == null) return false;
            return EqualsCore(vo);
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !Equals(left, right);
        }

        protected abstract bool EqualsCore(T other);
    }
}
