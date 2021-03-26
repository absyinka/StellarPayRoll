using System;
using System.ComponentModel.DataAnnotations;

namespace StellarPayRoll.Core.Attributes
{
    public class GuidRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            return value switch
            {
                Guid guid => guid != Guid.Empty,
                _ => false,
            };
        }
    }
}
