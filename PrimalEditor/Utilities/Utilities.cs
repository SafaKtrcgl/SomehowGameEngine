using System;
using System.Collections.Generic;
using System.Text;

namespace PrimalEditor.Utilities
{
    public static class MathUtil
    {
        public static float Epsilon => 0.00001f;

        public static bool IsTheSameAs(this float value, float other)
        {
            return MathF.Abs(value - other) < Epsilon;
        }

        public static bool IsTheSameAs(this float? value, float? other)
        {
            if (!value.HasValue || !other.HasValue) return false;
            return MathF.Abs(value.Value - other.Value) < Epsilon;
        }
    }
}
