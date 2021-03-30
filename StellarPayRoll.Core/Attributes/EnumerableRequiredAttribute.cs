using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace StellarPayRoll.Core.Attributes
{
    class EnumerableRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return value is IEnumerable enumerable && enumerable.GetEnumerator().MoveNext();
        }
    }
}
