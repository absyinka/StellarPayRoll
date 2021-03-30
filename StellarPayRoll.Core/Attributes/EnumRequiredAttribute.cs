using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace StellarPayRoll.Core.Attributes
{
    public class EnumRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            var type = value.GetType();
            return type.IsEnum && Enum.IsDefined(type, value); ;
        }
    }
}
